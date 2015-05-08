using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoneyExtractor.Core.Logs;
using MoneyExtractor.Core.Utility;
using MoneyExtractor.Test.MoneyExtractor.Core.Test.Mocks;

namespace MoneyExtractor.Test.MoneyExtractor.Core.Test {
    [TestClass]
    public class LogManagerTest {
        [TestMethod]
        public void SaveLog_SaveGuid_Test() {

            IConfigurationUtility configurationUtility = new ConfigurationUtilityMock();

            LogManager logManager = new LogManager(configurationUtility);

            logManager.SaveLog(Guid.NewGuid(), LogType.Request, "SaveLog_SaveGuid_Test");

        }
    }
}
