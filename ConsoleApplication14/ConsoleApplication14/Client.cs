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
    class Client : Networkcomponent
    {
        byte[] data = Encoding.ASCII.GetBytes("Hello Server here is Client"); //string tosend by client 
        string ipAddress = "127.0.0.1";
        int sendPortClient = 55600; //send on port 55600
        private int listenPortClient = 55601; //listen on port 55601
        bool done = false; //controle while-loop
        string received;
        Deserializer Dz = new Deserializer();

        public void startThreadClientSend()
        {
            Thread ListeningThreadClient = new Thread(send);
            ListeningThreadClient.Start();
        }
        public void startThreadClientReceive()
        {
            Thread SendingThreadServer = new Thread(receive);
            SendingThreadServer.Start();
        }
        public override void receive()
        {
            using (UdpClient ClientListener = new UdpClient(listenPortClient))
            {
                IPEndPoint listenEndPointClient = new IPEndPoint(IPAddress.Any, listenPortClient);
                while (!done)
                {
                    byte[] receivedData = ClientListener.Receive(ref listenEndPointClient);
                    Console.WriteLine("Received broadcast message from server {0}", listenEndPointClient.ToString());
                    Console.WriteLine("Decoded data is:");
                    received = Encoding.ASCII.GetString(receivedData);
                    Dz.deserialize(received);
                    //should be "serialized data from client
                    Console.WriteLine("Client: received data");
                }
            }
        }
        //Methode "start" actually not in use
        public override void start()
        {
            //send();
            //receive();
        }
        public override void send()
        {
            try
            {
                using (var client = new UdpClient())
                {
                    IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ipAddress), sendPortClient);
                    client.Connect(ep);
                    client.Send(data, data.Length);
                    Console.WriteLine("Client: Data sended");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
