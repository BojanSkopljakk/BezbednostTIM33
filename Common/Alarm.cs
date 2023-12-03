using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common
{

    [DataContract]
    public enum TipRizika
    {
        Low,
        Medium,
        High
    }
    [DataContract]
    public class Alarm : ITipRizika
    {

        private DateTime vremeGenerisanja;
        private string imeKlijenta;
        private string poruka;
        private TipRizika tipRizika;
        public Alarm(DateTime vremeGenerisanja, string imeKlijenta, string poruka)
        {
            this.VremeGenerisanja = vremeGenerisanja;
            this.ImeKlijenta = imeKlijenta;
            this.Poruka = poruka;
            //this.tipRizika = tipRizika;
        }

        [DataMember]
        public DateTime VremeGenerisanja { get => vremeGenerisanja; set => vremeGenerisanja = value; }
        [DataMember]
        public string ImeKlijenta { get => imeKlijenta; set => imeKlijenta = value; }
        [DataMember]
        public string Poruka { get => poruka; set => poruka = value; }
        [DataMember]
        public TipRizika Rizik { get => tipRizika; set => tipRizika = value; }


        public TipRizika IzracunajRizik()
        {
            Random random = new Random();
            int num = random.Next(50);
            if (num < 10)
                return TipRizika.Low;
            else if (num >= 10 && num < 40)
                return TipRizika.Medium;
            else
                return TipRizika.High;
        }

        //pravimo metodu koja će pretvoriti propertije u string!!
    }
}
