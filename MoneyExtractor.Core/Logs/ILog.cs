using MoneyExtractor.Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyExtractor.Core.Logs {

    public interface ILog {

        void SaveLog(string logInfo);
    }
}
