using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AGS_Sekundar
{
    public class ReplikatorEndpointSekundar
    {
        public void KonekcijaSaReplikatoromSekundar()
        {
            NetTcpBinding binding = new NetTcpBinding();
            string address = "net.tcp://localhost:9995/ReplikatorEndpointSekundar";

            binding.Security.Mode = SecurityMode.Transport;
            binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows;
            binding.Security.Transport.ProtectionLevel = System.Net.Security.ProtectionLevel.EncryptAndSign;

            ServiceHost host = new ServiceHost(typeof(Servis2));
            host.AddServiceEndpoint(typeof(IAGSSekundar), binding, address);
            Console.WriteLine("Proba");
            host.Open();

            Console.WriteLine("Otvorena konekcija sa replikatorom");
        }
    }
}
