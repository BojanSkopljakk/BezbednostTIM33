﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.ServiceModel;
using System.Security.Principal;
using System.ServiceModel.Security;
using System.Security.Cryptography.X509Certificates;

namespace AGS_Primar
{
    class Program
    {
        static void Main(string[] args)
        {
            string srvCertCN = "WCFClient";
            NetTcpBinding binding = new NetTcpBinding();
            string address = "net.tcp://localhost:9999/AGS_Primar";

            binding.Security.Mode = SecurityMode.Transport;
            binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Certificate;
            binding.Security.Transport.ProtectionLevel = System.Net.Security.ProtectionLevel.EncryptAndSign;

			ServiceHost host = new ServiceHost(typeof(Servis1));
			host.AddServiceEndpoint(typeof(IAGSPrimar), binding, address);

			host.Credentials.ClientCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.ChainTrust;

			///If CA doesn't have a CRL associated, WCF blocks every client because it cannot be validated
			host.Credentials.ClientCertificate.Authentication.RevocationMode = X509RevocationMode.NoCheck;

			///Set appropriate service's certificate on the host. Use CertManager class to obtain the certificate based on the "srvCertCN"
			host.Credentials.ServiceCertificate.Certificate = CertManager.GetCertificateFromStorage(StoreName.My, StoreLocation.LocalMachine, srvCertCN);

            host.Open();

            Console.WriteLine($"{nameof(Servis1)} is started.");
            Console.WriteLine("Press <enter> to stop service...");

            Console.ReadLine();

        }
    }
}
