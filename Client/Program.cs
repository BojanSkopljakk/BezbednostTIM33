using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Common;
using System.Security.Principal;
using System.Security.Cryptography.X509Certificates;

namespace Client
{
    class Program
    {

        static void Main(string[] args)
        {
            /*ChannelFactory<Interface1> channel =
                new ChannelFactory<Interface1>("ServiceName");*/

            // Interface1 proxy = channel.CreateChannel();
            NetTcpBinding binding = new NetTcpBinding();
            string address = "net.tcp://localhost:9999/AGS_Primar";

            /*binding.Security.Mode = SecurityMode.Transport;
            binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows;
            binding.Security.Transport.ProtectionLevel = System.Net.Security.ProtectionLevel.EncryptAndSign;

            Console.WriteLine("Korisnik koji je pokrenuo klijenta je : " + WindowsIdentity.GetCurrent().Name);


            using (ClientProxy proxy = new ClientProxy(binding, address))
            {
                proxy.AddUser("pera", "peric");
                proxy.AddUser("pera", "peric");
            }

            /*  Console.Write("Unesite poruku: ");
              string text = Console.ReadLine();
              string odgovor = proxy.Ispisi(text);

              Console.WriteLine(odgovor);*/

            binding.Security.Mode = SecurityMode.Transport;
            binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows;
            binding.Security.Transport.ProtectionLevel = System.Net.Security.ProtectionLevel.EncryptAndSign;



            using (WCFClient proxy = new WCFClient(binding, address))
            {
                /// 1. Communication test
                //proxy.Ispisi();
                //Console.WriteLine("TestCommunication() finished. Press <enter> to continue ...");
                Console.WriteLine("1. AddAlarm\n");
                Console.WriteLine("2. DeleteAlarm\n");
                Console.WriteLine("3. AcceptDelete\n");
                Console.WriteLine("4. Ispisi\n");
                string opcija;
                
                while (true)
                {
                    opcija = Console.ReadLine();

                    switch (opcija)
                    {
                        case "1":
                            

                            //Alarm a = new Alarm(DateTime.Now, System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToString(), temp);

                            Alarm a = new Alarm();

                            Console.WriteLine("unesite id: ");
                            a.Id = int.Parse(Console.ReadLine());
                            a.Rizik = a.IzracunajRizik();
                            a.ImeKlijenta = System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToString();
                            Console.WriteLine("unesite poruku: ");
                            a.Poruka = Console.ReadLine();
                            Console.WriteLine("");
                            a.VremeGenerisanja = DateTime.Now;

                            proxy.AddAlarm(a);
                            Console.WriteLine("\ndodat alarm\n");
                            break;

                        case "2":
                            proxy.DeleteAlarm();
                            break;

                        case "3":
                            proxy.AcceptDelete();
                            break;

                        case "4":
                            proxy.Ispisi();
                            break;

                        default:
                            Console.WriteLine("pogrešan unos");
                            break;
                    }
                }
            }

        }
    }
}
