using MoneyExtractor.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyExtractor.Core.Processors {

    public sealed class BillProcessor : AbstractProcessor {

        internal override IEnumerable<long> MoneyTypeList {
            get {
                return new long[] { 10000, 5000, 2000, 1000, 500, 200 };
            }
        }

        public override string GetName() {
            return "Bill";
        }

        public override Entities.ChangeType GetChangeType() {
            return ChangeType.Bill;
        }
    }
}
