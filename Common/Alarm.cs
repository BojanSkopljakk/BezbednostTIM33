using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [DataContract]
    public class Alarm
    {

        private DateTime vremeGenerisanja;
        private string imeKlijenta;
        private string poruka;
        //private TipRizika rizik;
        public Alarm(DateTime vremeGenerisanja, string imeKlijenta, string poruka)
        {
            this.VremeGenerisanja = vremeGenerisanja;
            this.ImeKlijenta = imeKlijenta;
            this.Poruka = poruka;
        }

        [DataMember]
        public DateTime VremeGenerisanja { get => vremeGenerisanja; set => vremeGenerisanja = value; }
        [DataMember]
        public string ImeKlijenta { get => imeKlijenta; set => imeKlijenta = value; }
        [DataMember]
        public string Poruka { get => poruka; set => poruka = value; }
    }
}
