using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Global.Models;

namespace Server
{
    class Driver
    {
        static void Main(string[] args)
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry("localhost");
            IPAddress ip = ipHostInfo.AddressList[0];

            Server s = new Server(ip, 8080);
            s.StartServer();
            s.Listen();
        }
    }
}
