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
        
        [TestInitialize]
        public void RegisterComponents() {
            // Registra os tipos responsáveis por log.
            IocFactory.Register(
                Component.For<ILog>()
                .ImplementedBy<FileLog>("File").IsSingleton()
                .ImplementedBy<EventViewerLog>("EventViewer").IsSingleton()
                );
        }

        [TestCleanup]
        public void ClearContainer() {
            IocFactory.Reset();
        }

        [TestMethod]
        public void SaveLog_SaveGuidToFile_Test() {

            ConfigurationUtilityMock configurationUtility = new ConfigurationUtilityMock();

            configurationUtility.FileName = "LogTest.log";
            configurationUtility.FullPath = @"C:\Logs\LogTest.log";
            configurationUtility.Path = @"C:\Logs";
            configurationUtility.LogType = 1;

            IocFactory.Register(
                Component.For<IConfigurationUtility>()
                .Instance(configurationUtility)
                );

            LogManager logManager = new LogManager();

            logManager.SaveLog(Guid.NewGuid(), LogType.Request, "SaveLog_SaveGuid_Test");
        }

        [TestMethod]
        public void SaveLog_SaveGuidToEventViewer_Test() {

            ConfigurationUtilityMock configurationUtility = new ConfigurationUtilityMock();

            configurationUtility.FileName = "LogTest.log";
            configurationUtility.FullPath = @"C:\Logs\LogTest.log";
            configurationUtility.Path = @"C:\Logs";
            configurationUtility.LogType = 2;

            IocFactory.Register(
                Component.For<IConfigurationUtility>()
                .Instance(configurationUtility)
                );

            LogManager logManager = new LogManager();

            logManager.SaveLog(Guid.NewGuid(), LogType.Request, "SaveLog_SaveGuid_Test");
            
        }
    }
}
