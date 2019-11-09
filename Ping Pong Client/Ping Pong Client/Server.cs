﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Xml.Serialization;

namespace Ping_Pong_Client
{
    class Server : Networkcomponent
    {
        UdpClient server = new UdpClient(8008);
        Serializer Sz = new Serializer();
        Deserializer Dz = new Deserializer();
        Form1 f1;
        byte[] sendBytes = new Byte[1024];

        public Server(Form1 form)
        {
            f1 = form;
        }
        IPEndPoint remoteIPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 0);
       public void startTrhead()
       {
           Thread ListeningThreadServer = new Thread(receive);
           ListeningThreadServer.Start();
       }


        public override void receive()
        {
            Console.WriteLine("server: receive triggered");
            string[] array_return = new string[3];
            while (true)
            {
                byte[] receivedBytes = server.Receive(ref remoteIPEndPoint);
                string rcvdata = Encoding.ASCII.GetString(receivedBytes);
                Dz.deserialize(rcvdata);
                for (int i = 0; i < Dz.deserialize(rcvdata).Length; i++)
                {
                    array_return[i] = Dz.deserialize(rcvdata)[i];
                }
                for (int i = 0; i < array_return.Length; i++)
                {
                    Console.WriteLine("data received is: " + array_return[i]);
                }
                Console.WriteLine("server: receive finished");
                f1.callback_receive(array_return);
            }
        }

        public void send(string data)
        {
            Console.WriteLine("server: send triggered");
            sendBytes = Encoding.ASCII.GetBytes(data);
            Thread.Sleep(2000);
            server.Send(sendBytes, sendBytes.GetLength(0));
            Console.WriteLine("Data send to" + remoteIPEndPoint);
        }
    }
    /* class NWServer
     {
         public TcpListener server;
         public TcpClient client;
         public IPAddress localAddr;
         public int localPort;
         public string server_info;
         Form1 f1;
         public NWServer(Form1 form)
         {
             f1 = form;
         }
         public void Communicate()
         {
             localAddr = IPAddress.Parse("127.0.0.1");
             server = new TcpListener(localAddr, localPort);
             server.Start();
             client = server.AcceptTcpClient(); // Perform a blocking call to accept requests. 
             // You could also use server.AcceptSocket() here. 
             NetworkStream stream = client.GetStream(); // Get a stream object for reading and writing. 
             Byte[] bytes = new Byte[256];
             String data = null;
             int i;
             while ((i = stream.Read(bytes, 0, bytes.Length)) != 0) // Read incomming data. 
             {
                 data = System.Text.Encoding.ASCII.GetString(bytes, 0, i); // Translate data bytes to a ASCII string. 
                 Console.WriteLine("Received: {0}", data);
                 data = data.ToUpper(); // Process the data sent by the client. 
                 byte[] msg = System.Text.Encoding.ASCII.GetBytes(data); // Send back a response. 
                 stream.Write(msg, 0, msg.Length);
                 Console.WriteLine("Sent    : {0}", data);
             }
         }
     }*/
}