using Dlp.Framework.Container;
using MoneyExtractor.Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyExtractor.Core.Logs {
    public static class LogFactory {

        public static ILog Create(int logId) {

            switch (logId) {
                default:
                    return null;
                case 1:
                    return IocFactory.ResolveByName<ILog>("MoneyExtractor.Core.Logs.FileLog");
                case 2:
                    return IocFactory.ResolveByName<ILog>("MoneyExtractor.Core.Logs.EventViewerLog");
            }
        }

    }
}
