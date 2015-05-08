using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dlp.Framework;
using MoneyExtractor.Core.Utility;

namespace MoneyExtractor.Core.Logs {

    public class LogManager {

        public LogManager(IConfigurationUtility configurationUtility = null) {
            this.ConfigurationUtility = configurationUtility;
        }

        private IConfigurationUtility configurationUtility;
        /// <summary>
        /// Obtém ou define a instancia do utilitário de acesso ao arquivo de configuração.
        /// </summary>
        public IConfigurationUtility ConfigurationUtility {
            get {
                if (this.configurationUtility == null) { this.configurationUtility = new ConfigurationUtility(); }
                return this.configurationUtility;
            }
            set { this.configurationUtility = value; }
        }

        public void SaveLog(object logData, LogType logType, string method) {

            string serializedData = Serializer.JsonSerialize(logData);

            string logInfo = String.Format("Date:{0};LogType:{1};Method:{2};LogData{3}",
                DateTime.UtcNow, logType.ToString(), method, serializedData);

            this.SaveToFile(logInfo);            
        }

        private void SaveToFile(string logInfo) {

            string path = this.ConfigurationUtility.Path;
            string fileName = this.ConfigurationUtility.FileName;

            if (Directory.Exists(path) == false) {
                Directory.CreateDirectory(path);
            }

            string fullFilePath = this.ConfigurationUtility.FullPath;

            StreamWriter sw = new StreamWriter(fullFilePath, true, System.Text.ASCIIEncoding.UTF8);
            sw.WriteLine(logInfo);
            sw.Close();
        }
    }
}
