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

                paymentDataResponse.TotalAmountInCents = change;

                //TODO: Chamar a factory enquanto houve troco, se o processador retornar nulo parar o loop
                AbstractProcessor processor = null;

                while (change > 0) {
                
                    processor = ProcessorFactory.Create(change);

                    if (processor == null ){
                        break;
                    }

                    Dictionary<long, long> calculateChangeResult = processor.CalculateChange(change);

                    paymentDataResponse.ChangeData.ChangeTotalResult.Add(processor.GetChangeType(), calculateChangeResult);

                    long remainingAmount = calculateChangeResult.Sum(c => c.Key * c.Value);

                    change = change - remainingAmount;
                }

                paymentDataResponse.Success = true;
            }
            catch (Exception) {

                //LOG
                throw;
            }

            // TODO: Log do response.

            //Retorno
            return paymentDataResponse;
        }


    }
}
