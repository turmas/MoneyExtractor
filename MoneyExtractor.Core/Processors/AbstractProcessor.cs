using MoneyExtractor.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyExtractor.Core.Processors {

    public abstract class AbstractProcessor {

        public virtual Dictionary<long, long> CalculateChange(long change) {

            Dictionary<long, long> changeTotalResult = new Dictionary<long, long>();

            //Percorrer a lista de cédulas do valor maior para o menor
            foreach (long item in this.MoneyTypeList.OrderByDescending(o => o)) {

                long coinCount = (change / item);

                if (coinCount > 0) {

                    changeTotalResult.Add(item, coinCount);

                    change = change - (coinCount * item);
                }
            }

            return changeTotalResult;

        }
        internal abstract IEnumerable<long> MoneyTypeList { get; }
        public abstract string GetName();

        public abstract ChangeType GetChangeType();
    }
}
