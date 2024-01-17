using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common;

namespace AGS_Primar
{
    public class Servis1 : IAGSPrimar
    {

        [PrincipalPermission(SecurityAction.Demand, Role = "Read")]
        public void Ispisi()
        {
            Console.WriteLine("--------------------------------------------");
            foreach (Alarm a in ListaAlarma.listaAlarma)
            {
                Console.WriteLine("Id: " + a.Id);
                Console.WriteLine("Vreme Generisanja: " + a.VremeGenerisanja);
                Console.WriteLine("Ime klijenta: " + a.ImeKlijenta);
                Console.WriteLine("Poruka: " + a.Poruka);
                Console.WriteLine("Rizik: " + a.Rizik);
                Console.WriteLine("");
            }
            Console.WriteLine("--------------------------------------------");

        }

        [PrincipalPermission(SecurityAction.Demand, Role = "AlarmGenerator")]
        public void AddAlarm(Alarm a)
        {
                Console.WriteLine("Uspešno izvršeno");
                ListaAlarma.listaAlarma.Add(a);   
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "AlarmAdmin")]
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

        //možda ne vata dobro ime??????!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        [PrincipalPermission(SecurityAction.Demand, Role = "AlarmAdmin")]
        public void AcceptDelete(string ime)
        {
            //Console.WriteLine(System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToString());
            foreach (Alarm a in ListaAlarma.listaAlarma.ToList())
            {
                if (a.ImeKlijenta == ime)
                {
                    ListaAlarma.listaAlarma.Remove(a);
                }
            }
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
