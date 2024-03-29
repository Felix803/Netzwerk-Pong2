﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Ping_Pong_Client
{


    public class Client : Networkcomponent
    {
        byte[] sendBytes = new Byte[1024];
        byte[] rcvPacket = new Byte[1024];
        UdpClient client = new UdpClient();
        IPAddress address = IPAddress.Parse("127.0.0.1");
        IPEndPoint remoteIPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 0);
        Deserializer Dz = new Deserializer();
        Form1 f1;

        public Client(Form1 form)
        {
            f1 = form;
        }

        public Client()
        {
        }

        public void addForm(Form1 form)
        {
            f1 = form;
        }

        public bool start()
        {
            try
            {
                client.Connect(address, 8008);
                send("Connect");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return false;
        }

        public void startThreadClient()
        {
            client.Connect(address, 8008);
            send("Connect");
            Thread ListeningThreadClient = new Thread(receive);
            ListeningThreadClient.Start();
        }

        public void send(string data)
        {
            //Console.WriteLine("@Client: Send data + " + data);
            try
            {
                sendBytes = Encoding.ASCII.GetBytes(data);
                client.Send(sendBytes, sendBytes.GetLength(0));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public override void receive()
        {
            while (true)
            {
                rcvPacket = client.Receive(ref remoteIPEndPoint);
                string rcvData = Encoding.ASCII.GetString(rcvPacket);
                Dz.deserialize(rcvData);
                //Console.WriteLine("@Client: recieved data " + rcvData);
                string[] array_return_client = Dz.deserialize(rcvData);

                for (int i = 0; i < array_return_client.Length; i++)
                {
                    //Console.WriteLine("@Client: received data " + array_return_client[i]);
                }
                f1.callback_receive_client(array_return_client);
            }
        }
    }

    /*  class NWClient
      {
          Form1 f1;
          public TcpClient client;
          public string client_info;
          public NWClient(Form1 form)
          {
              f1 = form;
          }
          public void Communicate(string targetIP, int targetPort)
          {
              client = new TcpClient(targetIP, targetPort);
              string message = "Verbunden";
              Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
              // Translate the message into ASCII and store it as a Byte array. 
              NetworkStream stream = client.GetStream(); // Get a client stream for reading and writing. 
              stream.Write(data, 0, data.Length); // Send the message to the connected TcpServer. 
              Console.WriteLine("Sent    : {0}", message);
              data = new Byte[256]; // Receive the TcpServer.response. 
              String responseData = String.Empty; // String to store the response ASCII representation. 
              Int32 bytes = stream.Read(data, 0, data.Length); // Read the first batch of the TcpServer response bytes. 
              responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
              Console.WriteLine("Received: {0}", responseData);
              stream.Close(); // Close everything. 
              client.Close();
          }
      }*/
}
