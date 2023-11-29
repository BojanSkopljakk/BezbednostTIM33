using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace AGS_Sekundar
{
    class Servis2 : ChannelFactory<IAGSSekundar>, IAGSSekundar, IDisposable
    {

        IAGSSekundar factory;

        public Servis2(NetTcpBinding binding, string address)
            : base(binding, address)
        {

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
    }
}
