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
            Console.WriteLine("Inicijalizovan Replikator");
            Audit.ReplicationInitiated();
            while (true)
            {
                
                
                try
                {
                    ChannelFactory<IAGSPrimar> cfIzvor = new ChannelFactory<IAGSPrimar>("Izvor");
                    ChannelFactory<IAGSSekundar> cfOdrediste = new ChannelFactory<IAGSSekundar>("Odrediste");
                    IAGSPrimar kIzvor = cfIzvor.CreateChannel();
                    IAGSSekundar kOdrediste = cfOdrediste.CreateChannel();

                    //Audit.ReplicationInitiated();

                    //if (isFirstTime)
                    //{
                    //    List<Alarm> temp = kIzvor.GetLista();
                    //    if(temp.Count == 3)
                    //    {
                    //        kOdrediste.UpisAlarma(temp);
                    //        time = DateTime.Now;
                    //        isFirstTime = false;
                    //    }

                    //}
                    //else
                    //{
                    //    List<Alarm> alarmi = kIzvor.OcitavanjeAlarma(time);
                    //    time = DateTime.Now;
                    //    List<Alarm> temp = kIzvor.GetLista();
                    //    if(temp.Count == 3)
                    //    {
                    //        kOdrediste.UpisAlarma(alarmi);
                    //        Audit.ReplicationSuccess(alarmi);
                    //    }

                    //}

                    if (kIzvor.DuzinaListe() == 3)
                    {
                        List<Alarm> temp = kIzvor.GetLista();
                        kOdrediste.UpisAlarma(temp);
                        Audit.ReplicationSuccess(temp);
                        time = DateTime.Now;
                        kIzvor.IsprazniBuffer();
                        Console.WriteLine("Izvršena Replikacija");
                    }


                    Thread.Sleep(5000);
                }
                catch (Exception e)
                {
                    Audit.ReplicationFailure(e.Message);
                    Console.WriteLine(e.Message);
                }

                
            }
        }
    }
}
