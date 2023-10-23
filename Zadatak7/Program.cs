using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Replikator
{
    class Program
    {
        static void Main(string[] args)
        {
            ChannelFactory<Interface1> cfIzvor = new ChannelFactory<Interface1>("Izvor");
            ChannelFactory<Interface1> cfOdrediste = new ChannelFactory<Interface1>("Odrediste");
            Interface1 kIzvor = cfIzvor.CreateChannel();
            Interface1 kOdrediste = cfOdrediste.CreateChannel();

           /* string text = "Replikator";
            string odgovor = cfOdrediste.Ispisi(text);

            Console.WriteLine(odgovor);*/

        }
    }
}
