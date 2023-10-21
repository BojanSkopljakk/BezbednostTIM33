using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace AGS_Sekundar
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(Servis2)))
            {
                host.Open();
                Console.WriteLine("Servis 2 je uspesno pokrenut");
                Console.ReadKey();
            }
        }
    }
}
