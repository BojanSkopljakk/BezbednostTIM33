﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace AGS_Primar
{
    class Servis1 : Interface1, IAGSPrimar
    {
        public void Ispisi()
        {
            Console.WriteLine("Communication established.");

        }
    }
}
