using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;

namespace AGS_Primar
{
    public class sertifikat
    {
        public void konekcijaSaSekundarom()
        {
            string srvCertCN = "wcfservice";
            NetTcpBinding binding1 = new NetTcpBinding();
            string address1 = "net.tcp://localhost:9998/Sertifikat";

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
            host1.Authorization.ServiceAuthorizationManager = new CustomAuthorizationManager();

            host1.Open();

            Console.WriteLine("Otvorena konekcija sa sekundarom");
        }
    }
}
