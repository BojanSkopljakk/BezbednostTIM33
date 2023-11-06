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

namespace AGS_Sekundar
{
    class Program
    {
        static void Main(string[] args)
        {
			string srvCertCN = Formatter.ParseName(WindowsIdentity.GetCurrent().Name);
			NetTcpBinding binding = new NetTcpBinding();
			string address = "net.tcp://localhost:15001/AGS_Sekundar";

			binding.Security.Mode = SecurityMode.Transport;
			binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows;
			binding.Security.Transport.ProtectionLevel = System.Net.Security.ProtectionLevel.EncryptAndSign;

			ServiceHost host = new ServiceHost(typeof(Servis2));
			host.AddServiceEndpoint(typeof(IAGSSekundar), binding, address);

			host.Credentials.ClientCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.ChainTrust;

			///If CA doesn't have a CRL associated, WCF blocks every client because it cannot be validated
			host.Credentials.ClientCertificate.Authentication.RevocationMode = X509RevocationMode.NoCheck;

			///Set appropriate service's certificate on the host. Use CertManager class to obtain the certificate based on the "srvCertCN"
			host.Credentials.ServiceCertificate.Certificate = CertManager.GetCertificateFromStorage(StoreName.My, StoreLocation.LocalMachine, srvCertCN);

			host.Open();

			Console.WriteLine($"{nameof(Servis2)} is started.");
			Console.WriteLine("Press <enter> to stop service...");

			Console.ReadLine();

		}
    }
}
