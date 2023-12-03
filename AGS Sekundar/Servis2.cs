using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace AGS_Sekundar
{
    class Servis2 : ChannelFactory<IAGSSekundar>, IAGSSekundar, IDisposable
    {

        IAGSSekundar factory;

        public Servis2(NetTcpBinding binding, EndpointAddress address) : base(binding, address)
        {
            string cltCertCN = "wcfservice2";

            this.Credentials.ServiceCertificate.Authentication.CertificateValidationMode = System.ServiceModel.Security.X509CertificateValidationMode.ChainTrust;
            this.Credentials.ServiceCertificate.Authentication.RevocationMode = X509RevocationMode.NoCheck;

            /// Set appropriate client's certificate on the channel. Use CertManager class to obtain the certificate based on the "cltCertCN"
            this.Credentials.ClientCertificate.Certificate = CertManager.GetCertificateFromStorage(StoreName.My, StoreLocation.LocalMachine, cltCertCN);


            factory = this.CreateChannel();

        }
        public void testMethod()
        {
            Console.WriteLine("radi");
        }

        public void WriteInFile(Alarm a)
        {
            throw new NotImplementedException();
        }
        //stream reader koji ide lajnu po lajnu i parsira tekst u string i od tog stringa alarme
        //SreamReader kad naleti na razmak zna da je sledeći properti alarma, kada je novi red onda je novi alarm
        public void IspisNaKonzolu()
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            if (factory != null)
            {
                factory = null;
            }

            this.Close();
        }

    }
}
