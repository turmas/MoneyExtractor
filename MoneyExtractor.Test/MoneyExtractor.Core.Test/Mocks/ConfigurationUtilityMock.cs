using MoneyExtractor.Core.Utility;

namespace MoneyExtractor.Test.MoneyExtractor.Core.Test.Mocks {

    public sealed class ConfigurationUtilityMock : IConfigurationUtility {

        public ConfigurationUtilityMock() { }

        public string FileName { get; set; }

        public string FullPath { get; set; }

        public string Path { get; set; }

        public int LogType { get; set; }
    }
}
