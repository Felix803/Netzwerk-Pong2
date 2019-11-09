using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;


namespace ConsoleApplication14
{

    class Program
    {
        
        static void Main(string[] args)
        {
            Client client = new Client();
            Server server = new Server();
            server.startTrhead();
            client.connect();

        }
    }
    

    





   
    

}
