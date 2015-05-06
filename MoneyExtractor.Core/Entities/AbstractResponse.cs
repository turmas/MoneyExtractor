using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyExtractor.Core.Entities {
    
    public abstract class AbstractResponse {

        public AbstractResponse() {

            this.ErrorReportList = new List<ErrorReport>();
        }

        internal List<ErrorReport> ErrorReportList { get; set; }

        public bool Success { get; set; }
    }
}
