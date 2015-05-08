using MoneyExtractor.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyExtractor.Core.Processors {

    public sealed class CoinProcessor : AbstractProcessor {

        /// <summary>
        /// Lista com os valores de moeda
        /// </summary>
        internal override IEnumerable<long> MoneyTypeList {
            get {
                return new long[] { 100, 50, 25, 10, 5, 1 };
            }
        }
        
        public override string GetName() {
            return "Coin";
        }

        public override Entities.ChangeType GetChangeType() {
            return ChangeType.Coin;
        }
    }
}
