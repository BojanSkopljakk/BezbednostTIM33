using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace AGS_Primar
{
    public class Servis1 : IAGSPrimar
    {

        //[PrincipalPermission(SecurityAction.Demand, Role = "Read")]
        public void Ispisi()
        {
            Console.WriteLine("Communication established.");

        }

        //[PrincipalPermission(SecurityAction.Demand, Role = "AlarmGenerator")]
        public void AddAlarm(Alarm a)
        {
            ListaAlarma.listaAlarma.Add(a);
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "AlarmAdmin")]
        public void DeleteAlarm()
        {
            //ListaAlarma.listaAlarma.Remove();
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "AlarmAdmin")]
        public void AcceptDelete()
        {

        }
    }
}
