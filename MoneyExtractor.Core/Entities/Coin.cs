using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyExtractor.Core.Entities {
    public class Coin {
        public Coin() {
            this.CoinCollection = new List<long>{
               100,50,25,10,5,1
           };

        }
        public List<long> CoinCollection { get; set; }

        public Dictionary<long, long> CalculateChange(long change) {

            //ChangeData changeData = new ChangeData();

            //changeData.TotalAmountInCents = change;

            Dictionary<long, long> changeTotalResult = new Dictionary<long, long>();

            //Percorrer a lista de moedas do valor maior para o menor
            foreach (long item in this.CoinCollection) {

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
