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
    class Server : Networkcomponent
    {
        bool done = false;
        private int listenPortServer = 55600;
        string ipAddress = "127.0.0.1";
        int sendPortServer = 55601; //send on port 55601
        byte[] data;  //string tosend by Server
        Serializer Sz = new Serializer();

        public void startThreadServerSend()
        {
            Thread ListeningThreadServer = new Thread(send);
            ListeningThreadServer.Start();
        }
        public void startThreadServerReceive()
        {
            Thread SendingThreadServer = new Thread(receive);
            SendingThreadServer.Start();
        }

        //Methode "start" actually not in use
        public override void start()
        {
            Console.WriteLine("Server gestartet");
            //send();
            //receive();

        }
        public override void receive()
        {
            using (UdpClient listener = new UdpClient(listenPortServer))
            {
                IPEndPoint listenEndPoint = new IPEndPoint(IPAddress.Any, listenPortServer);
                while (!done)
                {
                    byte[] receivedData = listener.Receive(ref listenEndPoint);
                    Console.WriteLine("Received broadcast message from client {0}", listenEndPoint.ToString());
                    Console.WriteLine("Decoded data is:");
                    Console.WriteLine(Encoding.ASCII.GetString(receivedData)); //should be "Hello World" sent from above client
                    Console.WriteLine("Server: received data");
                }
            }
        }
        public override void send()
        {
            try
            {
                using (var server = new UdpClient())
                {
                    data = Encoding.ASCII.GetBytes(Sz.serialize());
                    IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ipAddress), sendPortServer);
                    server.Connect(ep);
                    server.Send(data, data.Length);
                    Console.WriteLine("Server: data sended");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
