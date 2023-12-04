using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.ServiceModel;
using System.Security.Principal;
using System.ServiceModel.Security;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.Description;
using System.IdentityModel.Policy;

namespace AGS_Primar
{
    class Program
    {
        static void Main(string[] args)
        {
           // string srvCertCN = "wcfservice";
            NetTcpBinding binding = new NetTcpBinding();
            string address = "net.tcp://localhost:9999/AGS_Primar";

            binding.Security.Mode = SecurityMode.Transport;
            binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows;
            binding.Security.Transport.ProtectionLevel = System.Net.Security.ProtectionLevel.EncryptAndSign;

            ServiceHost host = new ServiceHost(typeof(Servis1));
			host.AddServiceEndpoint(typeof(IAGSPrimar), binding, address);

/*
            NetTcpBinding binding1 = new NetTcpBinding();
            string address1 = "net.tcp://localhost:9999/Sertifikat";


            binding1.Security.Mode = SecurityMode.Transport;
            binding1.Security.Transport.ClientCredentialType = TcpClientCredentialType.Certificate;
            binding1.Security.Transport.ProtectionLevel = System.Net.Security.ProtectionLevel.EncryptAndSign;

            ServiceHost host1 = new ServiceHost(typeof(Servis1));
            host1.AddServiceEndpoint(typeof(IAGSPrimar), binding1, address1);


            host1.Credentials.ClientCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.ChainTrust;

            /////If CA doesn't have a CRL associated, WCF blocks every client because it cannot be validated
            host1.Credentials.ClientCertificate.Authentication.RevocationMode = X509RevocationMode.NoCheck;

            /////Set appropriate service's certificate on the host. Use CertManager class to obtain the certificate based on the "srvCertCN"
            host1.Credentials.ServiceCertificate.Certificate = CertManager.GetCertificateFromStorage(StoreName.My, StoreLocation.LocalMachine, srvCertCN);

            // podesavamo da se koristi MyAuthorizationManager umesto ugradjenog
            host1.Authorization.ServiceAuthorizationManager = new CustomAuthorizationManager();*/

            // podesavamo custom polisu, odnosno nas objekat principala
            host.Authorization.PrincipalPermissionMode = PrincipalPermissionMode.Custom;
            List<IAuthorizationPolicy> policies = new List<IAuthorizationPolicy>();
            policies.Add(new CustomAuthorizationPolicy());
            host.Authorization.ExternalAuthorizationPolicies = policies.AsReadOnly();

            host.Open();

            Console.WriteLine($"{nameof(Servis1)} is started.");
            Console.WriteLine("Press <enter> to stop service...");


            sertifikat sertifikat1 = new sertifikat();

            sertifikat1.konekcijaSaSekundarom();


            ReplikatorEndpoint replikatorEndpoint = new ReplikatorEndpoint();

            replikatorEndpoint.KonekcijaSaReplikatorom();

            Console.ReadLine();

            Dispose();

            void Dispose()
            {
                if (host != null)
                {
                    host = null;
                }

                host.Close();
            }

        }
    }
}
