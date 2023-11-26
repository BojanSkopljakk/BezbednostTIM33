using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common
{   
    [ServiceContract]
    public interface IAGSPrimar
    {
        [OperationContract]
        [FaultContract(typeof(SecurityException))]
        void AddAlarm();
        [OperationContract]
        [FaultContract(typeof(SecurityException))]
        void DeleteAlarm();
        [OperationContract]
        [FaultContract(typeof(SecurityException))]
        void AcceptDelete();

    }
}
