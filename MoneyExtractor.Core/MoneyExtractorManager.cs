using MoneyExtractor.Core.Entities;
using MoneyExtractor.Core.Processors;
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

        /// <summary>
        /// Processa o pagamento
        /// </summary>
        /// <param name="paymentData">Dados de pagamento</param>
        /// <returns>Resultado do processamento</returns>
        public PaymentDataResponse SellProduct(PaymentDataRequest paymentData) {

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
            catch (Exception) {

                //LOG
                paymentDataResponse.Message = "Ocorreu um erro ao processar sua compra.";
            }

            // TODO: Log do response.

            //Retorno
            return paymentDataResponse;
        }


    }
}
