using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyExtractor.Core.Entities {

    /// <summary>
    /// Dados de pagamento
    /// </summary>
    public class PaymentDataRequest : AbstractRequest {

        /// <summary>
        /// Valor do produto
        /// </summary>
        public long ProductAmountInCents { get; set; }

        /// <summary>
        /// Valor pago
        /// </summary>
        public long PaidAmountInCents { get; set; }

        protected override void Validate() {

            // Verifica se o valor pago é maior que zero.
            if (this.PaidAmountInCents <= 0) {
                this.AddError("PaidAmountInCents", "Paid amount must be greater than zero.");
            }

            // Verifica se o valor do produto é maior que zero.
            if (this.ProductAmountInCents <= 0) {
                this.AddError("ProductAmountInCents", "Product amount must be greater than zero.");
            }

            // Verifica se o valor informado é suficiente para pagar o produto.
            if (this.PaidAmountInCents < this.ProductAmountInCents) {
                this.AddError("PaidAmountInCents", "The paid amount must be grater or equal than the product amount.");
            }
        }
    }
}
