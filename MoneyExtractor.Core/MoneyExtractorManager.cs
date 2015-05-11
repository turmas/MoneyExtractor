using Dlp.Framework.Container;
using MoneyExtractor.Core.Entities;
using MoneyExtractor.Core.Logs;
using MoneyExtractor.Core.Processors;
using MoneyExtractor.Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyExtractor.Core {

    /// <summary>
    /// Gerenciador do pagamento
    /// </summary>
    public class MoneyExtractorManager {

        public MoneyExtractorManager() {

            IocFactory.Register(
                Component.For<IConfigurationUtility>()
                .ImplementedBy<ConfigurationUtility>()
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
