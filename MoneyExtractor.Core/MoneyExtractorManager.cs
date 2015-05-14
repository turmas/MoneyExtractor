using Dlp.Framework.Container;
using MoneyExtractor.Core.Entities;
using MoneyExtractor.Core.Interceptors;
using MoneyExtractor.Core.Logs;
using MoneyExtractor.Core.Processors;
using MoneyExtractor.Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyExtractor.Core {

    public delegate void ProcessorCompletedEventHandler(object sender, string e);

    /// <summary>
    /// Gerenciador do pagamento
    /// </summary>
    public class MoneyExtractorManager {

        /// <summary>
        /// Evento a ser disparado após a execução de um processador.
        /// </summary>
        public event ProcessorCompletedEventHandler OnProcessorExecuted;

        public MoneyExtractorManager() {

            // Registra a interface para ser utilizada pela classe concreta especificada.
            IocFactory.Register(
                Component.For<IConfigurationUtility>()
                .ImplementedBy<ConfigurationUtility>().IsSingleton()
                );

            // Registra os tipos responsáveis por log.
            //IocFactory.Register(
            //    Component.For<ILog>()
            //    .ResolveDependencies()
            //    .ImplementedBy<FileLog>("File").IsSingleton()
            //    .ImplementedBy<EventViewerLog>("EventViewer").IsSingleton()
            //    .Interceptor<LogInterceptor>()
            //    );

            IocFactory.Register(                

                Component.For<ILog>().ImplementedBy<FileLog>().IsDefault(),

                Component.FromThisAssembly("MoneyExtractor.Core.Logs")
                );
        }

        /// <summary>
        /// Processa o pagamento
        /// </summary>
        /// <param name="paymentData">Dados de pagamento</param>
        /// <returns>Resultado do processamento</returns>
        public PaymentDataResponse SellProduct(PaymentDataRequest paymentData) {

            // LOG dos valores de entrada
            LogManager logManager = new LogManager();

            logManager.SaveLog(paymentData, LogType.Request, "SellProduct");

            //Armazena o resultado
            PaymentDataResponse paymentDataResponse = new PaymentDataResponse();

            try {
                // Executa a validação dos dados recebidos.
                if (paymentData.IsValid == false) {
                    paymentDataResponse.ErrorReportList = paymentData.ValidationMessageList;
                    return paymentDataResponse;
                }

                // Calculando troco
                long change = paymentData.PaidAmountInCents - paymentData.ProductAmountInCents;
                long totalAmountInCents = change;

                //TODO: Chamar a factory enquanto houve troco, se o processador retornar nulo parar o loop
                AbstractProcessor processor = null;

                Dictionary<ChangeType, Dictionary<long, long>> changeTotalResult = new Dictionary<ChangeType, Dictionary<long, long>>();

                while (change > 0) {

                    processor = ProcessorFactory.Create(change);

                    if (processor == null) {

                        paymentDataResponse.Message = "Não foi possível efetuar sua compra.";
                        break;
                    }

                    Dictionary<long, long> calculateChangeResult = processor.CalculateChange(change);

                    // Dispara o evento.
                    if (this.OnProcessorExecuted != null) { this.OnProcessorExecuted(this, processor.GetName()); }

                    changeTotalResult.Add(processor.GetChangeType(), calculateChangeResult);

                    long remainingAmount = calculateChangeResult.Sum(c => c.Key * c.Value);

                    change = change - remainingAmount;
                }

                if (change == 0) {

                    paymentDataResponse.Success = true;

                    paymentDataResponse.TotalAmountInCents = totalAmountInCents;
                    paymentDataResponse.ChangeData.ChangeTotalResult = changeTotalResult;
                }
            }
            catch (Exception ex) {

                //LOG
                paymentDataResponse.Message = "Ocorreu um erro ao processar sua compra.";

                logManager.SaveLog(ex.ToString(), LogType.Exception, "SellProduct");
            }

            // Log do response.

            logManager.SaveLog(paymentDataResponse, LogType.Response, "SellProduct");

            //Retorno
            return paymentDataResponse;
        }


    }
}
