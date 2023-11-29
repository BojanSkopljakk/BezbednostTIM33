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
	
	public class WCFClient : ChannelFactory<IAGSPrimar>, IAGSPrimar, IDisposable
    {

		IAGSPrimar factory;
		
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



        public void AddAlarm()
        {
            throw new NotImplementedException();
        }

        public void DeleteAlarm()
        {
            throw new NotImplementedException();
        }

        public void AcceptDelete()
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
