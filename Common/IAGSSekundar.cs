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
    public interface IAGSSekundar
    {
        [OperationContract]
        [FaultContract(typeof(SecurityException))]
        void testMethod();

        [OperationContract]
        [FaultContract(typeof(SecurityException))]
        void IspisNaKonzolu();

        [OperationContract]
        [FaultContract(typeof(SecurityException))]
        void WriteInFile(Alarm a);

        [OperationContract]
        [FaultContract(typeof(SecurityException))]
        void UpisAlarma(List<Alarm> a);
    }
}
