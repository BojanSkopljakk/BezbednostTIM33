using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Replikator
{
    class Program
    {
        static void Main(string[] args)
        {
            //bool isFirstTime = true;
            DateTime time = DateTime.Now;

            //ServiceHost host = new ServiceHost(typeof(SecurityService));
            //host.AddServiceEndpoint(typeof(ISecurityService), binding, address);

            NetTcpBinding binding = new NetTcpBinding();

            binding.Security.Mode = SecurityMode.Transport;
            binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows;
            binding.Security.Transport.ProtectionLevel = System.Net.Security.ProtectionLevel.EncryptAndSign;

            while (true)
            {
                try
                {
                    ChannelFactory<IAGSPrimar> cfIzvor = new ChannelFactory<IAGSPrimar>("Izvor");
                    ChannelFactory<IAGSSekundar> cfOdrediste = new ChannelFactory<IAGSSekundar>("Odrediste");
                    IAGSPrimar kIzvor = cfIzvor.CreateChannel();
                    IAGSSekundar kOdrediste = cfOdrediste.CreateChannel();

                    

                    //if (isFirstTime)
                    //{
                    //    kOdrediste.UpisLica(kIzvor.SpisakLica()); // kad prvi put radimo replikaciju moramo da pokupimo sve sto se tamo nalazi
                    //    time = DateTime.Now; // moramo da zabelezimo vreme kada smo poslednji put odradili izmenu
                    //    isFirstTime = false;
                    //}
                    //else
                    //{
                    //    List<FizickoLice> lica = kIzvor.OcitavanjeLica(time);
                    //    time = DateTime.Now; // moramo da zabelezimo vreme kada smo poslednji put odradili izmenu
                    //    kOdrediste.UpisLica(lica);
                    //}

                    Thread.Sleep(5000);
                }
                //catch (FaultException ex)
                //{
                //    Console.WriteLine(ex.Message);
                //}
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
