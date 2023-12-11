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

        [PrincipalPermission(SecurityAction.Demand, Role = "Read")]
        public void Ispisi()
        {
            Console.WriteLine("Communication established.");

        }

        //[PrincipalPermission(SecurityAction.Demand, Role = "AlarmGenerator")]
        public void AddAlarm(Alarm a)
        {
            ListaAlarma.listaAlarma.Add(a);
        }

        //[PrincipalPermission(SecurityAction.Demand, Role = "AlarmAdmin")]
        public void DeleteAlarm(int id)
        {
            bool postoji = false;
            foreach(Alarm a in ListaAlarma.listaAlarma)
            {
                if (a.Id == id)
                {
                    ListaAlarma.listaAlarma.Remove(a);
                    postoji = true;
                    break;
                }
            }
            if (postoji)
            {
                Console.WriteLine("Uspešno izbrisan\n");
            }
            else
            {
                Console.WriteLine("Alarm ne postoji\n");
            }
            
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "AlarmAdmin")]
        public void AcceptDelete()
        {

        }

        public List<Alarm> GetLista()
        {
            return ListaAlarma.listaAlarma;
        }

        public List<Alarm> OcitavanjeAlarma(DateTime vremeGenerisanja)
        {
            Console.WriteLine(DateTime.Now.ToString() + " - Ocitavanje alarma inicirano.");

            List<Alarm> alarmi = new List<Alarm>();

            foreach (Alarm a in ListaAlarma.listaAlarma)
            {
                if (a.VremeGenerisanja >= vremeGenerisanja)
                {
                    alarmi.Add(a);
                }
            }

            return alarmi;
        }

        public void IsprazniBuffer()
        {
            ListaAlarma.listaAlarma.Clear();
        }

        public int DuzinaListe()
        {
            return ListaAlarma.listaAlarma.Count();
        }
    }
}
