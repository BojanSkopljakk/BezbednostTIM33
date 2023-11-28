using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
using System.Security.Principal;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Client
{
	
	public class WCFClient : ChannelFactory<Interface1>, Interface1, IDisposable
    {

		Interface1 factory;
		
		public WCFClient(NetTcpBinding binding, string address)
			: base(binding, address)
		{

			factory = this.CreateChannel();
			
		}

		public void Ispisi()
		{
			try
			{
				factory.Ispisi();
			}
			catch (Exception e)
			{
				Console.WriteLine("[TestCommunication] ERROR = {0}", e.Message);
			}
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
