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
        [PrincipalPermission(SecurityAction.Demand, Role = "AlarmAdmin")]
        [PrincipalPermission(SecurityAction.Demand, Role = "AlarmGenerator")]
        [PrincipalPermission(SecurityAction.Demand, Role = "Read")]
        public void Ispisi()
        {
            Console.WriteLine("Communication established.");

        }

        public void AddAlarm()
        {

        }
    }
}
