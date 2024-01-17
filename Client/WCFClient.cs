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
		
		public WCFClient(NetTcpBinding binding, string address) : base(binding, address)
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



		public void AddAlarm(Alarm a)
		{
			factory.AddAlarm(a);
			Console.WriteLine(a.Id);
			Console.WriteLine(a.VremeGenerisanja.ToString());
			Console.WriteLine(a.Poruka);
			Console.WriteLine(a.ImeKlijenta);
            Console.WriteLine(a.Rizik.ToString());
		}

		public void DeleteAlarm(int id)
        {
			factory.DeleteAlarm(id);
        }

        public void AcceptDelete(string ime)
        {
			factory.AcceptDelete(ime);
        }


		public void Dispose()
		{
			if (factory != null)
			{
				factory = null;
			}

			this.Close();
		}

        public List<Alarm> GetLista()
        {
            throw new NotImplementedException();
        }

        public List<Alarm> OcitavanjeAlarma(DateTime vremeGenerisanja)
        {
            throw new NotImplementedException();
        }

        public void IsprazniBuffer()
        {
            throw new NotImplementedException();
        }

        public int DuzinaListe()
        {
            throw new NotImplementedException();
        }
    }
}
