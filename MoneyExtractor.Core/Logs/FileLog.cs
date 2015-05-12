using Dlp.Framework.Container;
using MoneyExtractor.Core.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyExtractor.Core.Logs {
    public class FileLog : ILog {

        public FileLog() { }

        public void SaveLog(string logInfo) {

            IConfigurationUtility configuration = IocFactory.Resolve<IConfigurationUtility>();

            string path = configuration.Path;
            string fileName = configuration.FileName;

            if (Directory.Exists(path) == false) {
                Directory.CreateDirectory(path);
            }

            string fullFilePath = configuration.FullPath;

            StreamWriter sw = new StreamWriter(fullFilePath, true, System.Text.ASCIIEncoding.UTF8);
            sw.WriteLine(logInfo);
            sw.Close();
        }
    }
}
