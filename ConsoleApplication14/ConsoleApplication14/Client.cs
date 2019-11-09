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
    class Client:Networkcomponent
    {
        string data = "";
        byte[] sendBytes = new Byte[1024];
        byte[] rcvPacket = new Byte[1024];
        UdpClient client = new UdpClient();
        IPAddress address = IPAddress.Parse(IPAddress.Broadcast.ToString());
        IPEndPoint remoteIPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 0);
        Serializer Sz = new Serializer();
        Deserializer Dz = new Deserializer();

        public void connect()
        {
            client.Connect(address, 8008);
            Console.WriteLine("Client is Started");
            send();
        }

        public override void send()
        {
            Console.WriteLine("client: send triggered");
            while (true)
            {
                data = Sz.serialize();
                sendBytes = Encoding.ASCII.GetBytes(data);
                client.Send(sendBytes, sendBytes.GetLength(0));
                receive();
            }
        }

        public override void receive()
        {
            Console.WriteLine("client: receive triggered");
            rcvPacket = client.Receive(ref remoteIPEndPoint);
            string rcvData = Encoding.ASCII.GetString(rcvPacket);
            Dz.deserialize(rcvData);
        }

    }
}
