using MoneyExtractor.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyExtractor.Core.Processors {
    public class SilverProcessor : AbstractProcessor{
        internal override IEnumerable<long> MoneyTypeList {
            get {
                return new long[] {
                    200000, 150000, 100000, 50000
                };
            }
        }

        public override string GetName() {
            return "Silver";
        }

        public override Entities.ChangeType GetChangeType() {
            return ChangeType.Silver;
        }
    }
}
