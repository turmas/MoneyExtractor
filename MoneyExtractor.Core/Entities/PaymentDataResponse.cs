using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyExtractor.Core.Entities {

    public class PaymentDataResponse : AbstractResponse {

        public PaymentDataResponse() {
            this.ChangeData = new ChangeData();
        }

        public Nullable<long> TotalAmountInCents { get; set; }

        public ChangeData ChangeData { get; set; }

        public string Message { get; set; }
    }
}
