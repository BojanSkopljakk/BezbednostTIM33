using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Common
{
    public class Audit : IDisposable
    {
        public static void ReplicationSuccess(List<Alarm> alarmi)
        {
            using (var customLog = EventLogFactory.CreateNew())
            {
                string temp = "";
                foreach(Alarm a in alarmi)
                {
                    temp += a.Id.ToString() + " ";
                }


                string message = string.Format(AuditEvents.AlarmReplicationSuccess, temp);
                customLog.WriteEntry(message, EventLogEntryType.Information);
            }
        }

        public static void ReplicationFailure(string reason = "")
        {
            using (var customLog = EventLogFactory.CreateNew())
            {
                string message = string.Format(AuditEvents.AlarmReplicationFailure, reason);
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
