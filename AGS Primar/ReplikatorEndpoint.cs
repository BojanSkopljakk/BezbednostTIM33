using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AGS_Primar
{
    public class ReplikatorEndpoint
    {

        public void KonekcijaSaReplikatorom()
        {
            NetTcpBinding binding = new NetTcpBinding();
            string address = "net.tcp://localhost:9997/ReplikatorEndpoint";

            binding.Security.Mode = SecurityMode.Transport;
            binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows;
            binding.Security.Transport.ProtectionLevel = System.Net.Security.ProtectionLevel.EncryptAndSign;

            ServiceHost host = new ServiceHost(typeof(Servis1));
            host.AddServiceEndpoint(typeof(IAGSPrimar), binding, address);

            host.Open();

            Console.WriteLine("Otvorena konekcija sa replikatorom");
        }

    }
}
