using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace AGS_Primar
{
    class Servis1 : Interface1, IAGSPrimar
    {

        [PrincipalPermission(SecurityAction.Demand, Role = "Read")]
        public void Ispisi()
        {
            Console.WriteLine("Communication established.");

        }

        [PrincipalPermission(SecurityAction.Demand, Role = "AlarmGenerator")]
        public void AddAlarm()
        {

        }

        [PrincipalPermission(SecurityAction.Demand, Role = "AlarmAdmin")]
        public void DeleteAlarm()
        {

        }

        [PrincipalPermission(SecurityAction.Demand, Role = "AlarmAdmin")]
        public void AcceptDelete()
        {

        }

        
    }
}
