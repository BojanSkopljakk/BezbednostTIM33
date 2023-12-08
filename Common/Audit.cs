using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Common
{
    public class Audit : IDisposable
    {
        public static void ReplicationSuccess(List<Alarm> alarm)
        {
            using (var customLog = EventLogFactory.CreateNew())
            {
                string message = string.Format(AuditEvents.AlarmReplicationSuccess, alarm);
                customLog.WriteEntry(message, EventLogEntryType.Information);
            }
        }

        public static void ReplicationFailure(Alarm alarm, string reason = "")
        {
            using (var customLog = EventLogFactory.CreateNew())
            {
                string message = string.Format(AuditEvents.AlarmReplicationFailure, alarm, reason);
                customLog.WriteEntry(message, EventLogEntryType.Error);
            }
        }

        public static void ReplicationInitiated()
        {
            using (var customLog = EventLogFactory.CreateNew())
            {
                string message = string.Format(AuditEvents.AlarmReplicationInitiated, DateTime.Now);
                customLog.WriteEntry(message, EventLogEntryType.Information);
            }
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
