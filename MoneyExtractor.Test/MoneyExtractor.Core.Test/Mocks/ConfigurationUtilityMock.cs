using MoneyExtractor.Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyExtractor.Test.MoneyExtractor.Core.Test.Mocks {
    
    public sealed class ConfigurationUtilityMock : IConfigurationUtility {

        public string FileName {
            get { return "FileLogTest.log"; }
        }

        public string FullPath {
            get { return System.IO.Path.Combine(this.Path, this.FileName); }
        }

        public string Path {
            get { return @"C:\Logs"; }
        }

        public int LogType {
            get { return 1; }
        }
    }
}
