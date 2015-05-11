using System;

namespace MoneyExtractor.Core.Utility {

    public interface IConfigurationUtility {
        
        string FileName { get; }
        
        string FullPath { get; }
        
        string Path { get; }

        int LogType { get; }
    }
}
