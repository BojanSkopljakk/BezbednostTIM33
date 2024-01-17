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
        void AddAlarm(Alarm a);
        [OperationContract]
        [FaultContract(typeof(SecurityException))]
        void DeleteAlarm(int id);
        [OperationContract]
        [FaultContract(typeof(SecurityException))]
        void AcceptDelete(string ime);

        [OperationContract]
        [FaultContract(typeof(SecurityException))]
        void Ispisi();

        [OperationContract]
        [FaultContract(typeof(SecurityException))]
        List<Alarm> GetLista();
        [OperationContract]
        [FaultContract(typeof(SecurityException))]
        List<Alarm> OcitavanjeAlarma(DateTime vremeGenerisanja);

        [OperationContract]
        [FaultContract(typeof(SecurityException))]
        void IsprazniBuffer();

        [OperationContract]
        [FaultContract(typeof(SecurityException))]
        int DuzinaListe();
    }
}
