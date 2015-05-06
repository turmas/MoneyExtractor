using MoneyExtractor.Core.Entities;
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

                //se o valor pago = 0 não tem troco

                if (change == 0) {
                    paymentDataResponse.Message = "Pagamento Efetuado. Não há troco.";
                }
                else {
                    //senão, calcula a quantidade de moedas
                    //paymentDataResponse.Message = "Pagamento efetuado com troco.";

                    //TODO: Montar arquivo de configuração de entrada

                    Dictionary<long, long> billCollection = new Bill().CalculateChange(change);

                    //TODO: Ler nas configuraçôes a ordem dos tipos de retorno (Cédula > Moeda > ...)
                    long remainingAmount = change - billCollection.Sum(amount => amount.Key * amount.Value);

                    paymentDataResponse.ChangeData = new ChangeData();

                    paymentDataResponse.ChangeData.ChangeTotalResult.Add(ChangeType.Bill, billCollection);

                    //TODO: Montar loop para os tipos de retorno
                    if (remainingAmount > 0) {

                        Dictionary<long, long> coinCollection = new Coin().CalculateChange(remainingAmount);

                        paymentDataResponse.ChangeData.ChangeTotalResult.Add(ChangeType.Coin, coinCollection);
                    }

                    //TODO: Montar o ChangeData com os valores retornados

                }
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
