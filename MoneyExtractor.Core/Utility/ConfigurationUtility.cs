using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyExtractor.Core.Utility {

    public sealed class ConfigurationUtility : IConfigurationUtility {

        public ConfigurationUtility() { }

        public string Path { get { return ConfigurationManager.AppSettings["Path"]; } }

        public string FileName { get { return ConfigurationManager.AppSettings["FileName"]; } }

        public string FullPath { get { return System.IO.Path.Combine(this.Path, this.FileName); } }

        public int LogType { get { return Convert.ToInt32(ConfigurationManager.AppSettings["LogType"]); } }
    }
}
