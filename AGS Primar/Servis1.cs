using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace AGS_Primar
{
    class Servis1 : Interface1
    {
        public string Ispisi(string text)
        {
            Console.WriteLine($"Client connected: {text}");
            return $"Service received: {text}";
        }
    }
}
