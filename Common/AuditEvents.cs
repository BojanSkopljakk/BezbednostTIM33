using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Resources;

namespace Common
{
    public enum AuditEventTypes
    {
        AlarmReplicationSuccess = 0,
        AlarmReplicationFailure = 1,
        AlarmReplicationInitiated = 2
    }

    public class AuditEvents
    {
        private static ResourceManager resourceManager;
        private static readonly object resourceLock = new object();

        private static ResourceManager ResourceMgr
        {
            get
            {
                lock (resourceLock)
                {
                    if (resourceManager == null)
                    {
                        resourceManager = new ResourceManager(typeof(AuditEventFile).FullName, Assembly.GetExecutingAssembly());
                    }
                    return resourceManager;
                }
            }
        }

        public static string AlarmReplicationSuccess
        {
            get
            {
                return ResourceMgr.GetString(nameof(AuditEventTypes.AlarmReplicationSuccess));
            }
        }

        public static string AlarmReplicationFailure
        {
            get
            {
                return ResourceMgr.GetString(nameof(AuditEventTypes.AlarmReplicationFailure));
            }
        }

        public static string AlarmReplicationInitiated
        {
            get
            {
                return ResourceMgr.GetString(nameof(AuditEventTypes.AlarmReplicationInitiated));
            }
        }


    }
}
