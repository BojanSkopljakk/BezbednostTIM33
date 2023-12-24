using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Security.Principal;
using System.ServiceModel.Security;
using System.Security.Cryptography.X509Certificates;
using Common;
using System.Threading;

namespace AGS_Sekundar
{
    class Program
    {
        static void Main(string[] args)
        {
            /// Define the expected service certificate. It is required to establish cmmunication using certificates.
            string srvCertCN = "wcfservice";

            NetTcpBinding binding = new NetTcpBinding();
            binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Certificate;

            /// Use CertManager class to obtain the certificate based on the "srvCertCN" representing the expected service identity.
            X509Certificate2 srvCert = CertManager.GetCertificateFromStorage(StoreName.TrustedPeople, StoreLocation.LocalMachine, srvCertCN);
            EndpointAddress address = new EndpointAddress(new Uri("net.tcp://localhost:9998/Sertifikat"),
                                      new X509CertificateEndpointIdentity(srvCert));
            ReplikatorEndpointSekundar replikatorEndpointSekundar = new ReplikatorEndpointSekundar();
            replikatorEndpointSekundar.KonekcijaSaReplikatoromSekundar();
            using (Servis2 proxy = new Servis2(binding, address))
			{
				/// 1. Communication test
				proxy.testMethod();
				Console.WriteLine("TestCommunication() finished. Press <enter> to continue ...");
                int i = 0;
                while (true)
                {
                    //if (KopijaListe.listaAlarma2.Count > i + 2)
                    //{
                    //    proxy.WriteInFile(KopijaListe.listaAlarma2[i]);
                    //    proxy.WriteInFile(KopijaListe.listaAlarma2[i + 1]);
                    //    proxy.WriteInFile(KopijaListe.listaAlarma2[i + 2]);
                    //    i += 3;
                    //}
                    //else if (KopijaListe.listaAlarma2.Count > i + 1)
                    //{
                    //    proxy.WriteInFile(KopijaListe.listaAlarma2[i]);
                    //    proxy.WriteInFile(KopijaListe.listaAlarma2[i + 1]);
                    //    i += 2;
                    //}
                    //else if (KopijaListe.listaAlarma2.Count > i)
                    //{
                    //    proxy.WriteInFile(KopijaListe.listaAlarma2[i]);
                    //    i += 1;
                    //}

                    if(KopijaListe.listaAlarma2.Count > i)
                    {
                        proxy.WriteInFile(KopijaListe.listaAlarma2[i]);
                        i++;
                    }

                    Thread.Sleep(1000);
                }
                //while (true)
                //{
                //    if (KopijaListe.listaAlarma2.Count() > 0)
                //    {
                //        proxy.IspisNaKonzolu();
                //    }
                //    Thread.Sleep(5000);
                //}


                //Console.ReadLine();
            }
		}
    }
}
