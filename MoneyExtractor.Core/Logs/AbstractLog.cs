using MoneyExtractor.Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyExtractor.Core.Logs {

    public abstract class AbstractLog {

        public AbstractLog() { }

        public abstract void SaveLog(string logInfo);
    }
}
