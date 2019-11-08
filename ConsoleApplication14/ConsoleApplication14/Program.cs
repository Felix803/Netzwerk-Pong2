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
            Server server = new Server();
            Client client = new Client();
            server.startThreadServerReceive();
            client.startThreadClientSend();
            client.startThreadClientReceive();
            server.startThreadServerSend();       
        }
    }
    

    





   
    

}
