using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Common;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            ChannelFactory<Interface1> channel =
                new ChannelFactory<Interface1>("ServiceName");

            Interface1 proxy = channel.CreateChannel();
        }
    }
}
