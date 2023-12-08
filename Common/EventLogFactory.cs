using System;
using System.Diagnostics;
using System.Security;


namespace Common
{
    internal static class EventLogFactory
    {
        public static EventLog CreateNew(string logName = "Replikacija", string sourceName = "Common.Audit")
        {
           
            if (!EventLog.SourceExists(sourceName))
            {
                EventLog.CreateEventSource(sourceName, logName);
            }

            return new EventLog(logName, Environment.MachineName, sourceName);
        }
    }
}
