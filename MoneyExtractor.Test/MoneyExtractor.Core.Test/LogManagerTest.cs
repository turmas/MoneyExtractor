using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoneyExtractor.Core.Logs;
using MoneyExtractor.Core.Utility;
using MoneyExtractor.Test.MoneyExtractor.Core.Test.Mocks;
using Dlp.Framework.Container;
using MoneyExtractor.Core;
using MoneyExtractor.Core.Entities;

namespace MoneyExtractor.Test.MoneyExtractor.Core.Test {
    [TestClass]
    public class LogManagerTest {
        [TestMethod]
        public void SaveLog_SaveGuid_Test() {

            IocFactory.Register(
                Component.For<IConfigurationUtility>()
                .ImplementedBy<ConfigurationUtilityMock>()
                );

            LogManager logManager = new LogManager();

            logManager.SaveLog(Guid.NewGuid(), LogType.Request, "SaveLog_SaveGuid_Test");
        }
    }
}
