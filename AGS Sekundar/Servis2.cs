using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace AGS_Sekundar
{
    class Servis2 : Interface1, IAGSSekundar
    {
        public void Ispisi()
        {
            Console.WriteLine("Communication established.");
        }

        public void testMethod()
        {
            throw new NotImplementedException();
        }

     
    }
}
