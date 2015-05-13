using MoneyExtractor.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyExtractor.Core.Processors {
    public sealed class CandyProcessor : AbstractProcessor{

        internal override IEnumerable<long> MoneyTypeList {
            get { return new long[] { 3,1 }; }
        }

        public override string GetName() {
            return "Candy";
        }

        public override Entities.ChangeType GetChangeType() {
            return ChangeType.Candy;
        }
    }
}
