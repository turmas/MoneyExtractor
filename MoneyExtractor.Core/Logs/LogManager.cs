using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dlp.Framework;
using MoneyExtractor.Core.Utility;
using Dlp.Framework.Container;

namespace MoneyExtractor.Core.Logs {

    public class LogManager {

        public LogManager() { }

        public void SaveLog(object logData, LogType logType, string method) {

            string serializedData = Serializer.JsonSerialize(logData);

            string logInfo = String.Format("Date:{0};LogType:{1};Method:{2};LogData{3}",
                DateTime.UtcNow, logType.ToString(), method, serializedData);

            IConfigurationUtility configuration = IocFactory.Resolve<IConfigurationUtility>();

            AbstractLog abstractLog = LogFactory.Create(configuration.LogType);

            if (abstractLog == null) { throw new Exception(); }

            abstractLog.SaveLog(logInfo);
        }
    }
}
