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
           // string address = "net.tcp://localhost:9999/SecurityService";

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

            string srvCertCN = "wcfservice";

            binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Certificate;

            /// Use CertManager class to obtain the certificate based on the "srvCertCN" representing the expected service identity.
            X509Certificate2 srvCert = CertManager.GetCertificateFromStorage(StoreName.TrustedPeople, StoreLocation.LocalMachine, srvCertCN);
            EndpointAddress address = new EndpointAddress(new Uri("net.tcp://localhost:9999/Receiver"),
                                      new X509CertificateEndpointIdentity(srvCert));

            using (WCFClient proxy = new WCFClient(binding, address))
            {
                /// 1. Communication test
                proxy.Ispisi();
                Console.WriteLine("TestCommunication() finished. Press <enter> to continue ...");
                Console.ReadLine();
            }

        }
    }
}
