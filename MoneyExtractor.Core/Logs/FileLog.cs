using Dlp.Framework.Container;
using MoneyExtractor.Core.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyExtractor.Core.Logs {
    class FileLog : AbstractLog {

        public FileLog() { }

        public override void SaveLog(string logInfo) {

            IConfigurationUtility configurationUtility = IocFactory.Resolve<IConfigurationUtility>();

            string path = configurationUtility.Path;
            string fileName = configurationUtility.FileName;

            if (Directory.Exists(path) == false) {
                Directory.CreateDirectory(path);
            }

            string fullFilePath = configurationUtility.FullPath;

            StreamWriter sw = new StreamWriter(fullFilePath, true, System.Text.ASCIIEncoding.UTF8);
            sw.WriteLine(logInfo);
            sw.Close();
        }
    }
}
