using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyExtractor.Core.Entities {
    public class Bill {
        public Bill() {
            this.BillCollection = new List<long>{
               10000,5000,2000,1000,500,200
           };
        }
        public List<long> BillCollection { get; set; }

        public Dictionary<long, long> CalculateChange(long change) {

            //ChangeData changeData = new ChangeData();

            //changeData.TotalAmountInCents = change;

            Dictionary<long, long> changeTotalResult = new Dictionary<long, long>();

            //Percorrer a lista de cédulas do valor maior para o menor
            foreach (long item in this.BillCollection) {

                long coinCount = (change / item);

                if (coinCount > 0) {

                    changeTotalResult.Add(item, coinCount);

                    change = change - (coinCount * item);
                }
            }

            return changeTotalResult;
        }
    }
}
