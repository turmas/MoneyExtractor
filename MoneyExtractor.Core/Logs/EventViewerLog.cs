using MoneyExtractor.Core.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyExtractor.Core.Logs {

    public class EventViewerLog : ILog {

        public EventViewerLog() { }

        public void SaveLog(string logInfo) {

            // Create an EventLog instance and assign its source.
            EventLog eventLog = new EventLog();
            eventLog.Source = "Money Extractor";

            // Write an entry in the event log.
            eventLog.WriteEntry(logInfo, EventLogEntryType.Information, 1001);
        }
    }
}
