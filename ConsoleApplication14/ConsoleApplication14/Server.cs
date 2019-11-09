﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace ConsoleApplication14
{
    class Server:Networkcomponent
    {
        string data = "";

        UdpClient server = new UdpClient(8008);
        Serializer Sz = new Serializer();
        Deserializer Dz = new Deserializer();

        IPEndPoint remoteIPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 0);
        public void startTrhead()
        {
            Thread ListeningThreadServer = new Thread(receive);
            ListeningThreadServer.Start();
        }


        public override void receive()
        {
            Console.WriteLine("Server started");
            Console.WriteLine("server: receive triggered");
            while (true)
            {
                byte[] receivedBytes = server.Receive(ref remoteIPEndPoint);
                data = Encoding.ASCII.GetString(receivedBytes);
                Dz.deserialize(data);
                Console.WriteLine(data);
                send();
            }
        }

        public override void send()
        {
            Console.WriteLine("server: send triggered");
            server.Send(Encoding.ASCII.GetBytes(Sz.serialize()), Sz.serialize().Length, remoteIPEndPoint);
            Console.WriteLine("Data send to" + remoteIPEndPoint);
        }
    }
}
