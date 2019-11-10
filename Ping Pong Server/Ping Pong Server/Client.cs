using System;
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


    class Client : Networkcomponent
    {
        byte[] sendBytes = new Byte[1024];
        byte[] rcvPacket = new Byte[1024];
        UdpClient client = new UdpClient();
        IPAddress address = IPAddress.Parse("127.0.0.1");
        IPEndPoint remoteIPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 0);
        Serializer Sz = new Serializer();
        Deserializer Dz = new Deserializer();
        Form1 f1;

        public Client(Form1 form)
        {
            f1 = form;
        }
        public void startThreadClient()
        {
            Thread ListeningThreadClient = new Thread(connect);
            ListeningThreadClient.Start();
        }

        public void connect()
        {
            client.Connect(address, 8008);
            Console.WriteLine("Client is Started");
            receive();
        }

        public void send(string data)
        {
            Console.WriteLine("client: send triggered");
            sendBytes = Encoding.ASCII.GetBytes(data);
            client.Send(sendBytes, sendBytes.GetLength(0));
        }

        public override void receive()
        {
            string[] array_return_client = new string[2];
            Console.WriteLine("client: receive triggered");
            while (true)
            {
                rcvPacket = client.Receive(ref remoteIPEndPoint);
                string rcvData = Encoding.ASCII.GetString(rcvPacket);
                Dz.deserialize(rcvData);
                for (int i = 0; i < Dz.deserialize(rcvData).Length; i++)
                {
                    array_return_client[i] = Dz.deserialize(rcvData)[i];
                }
                for (int i = 0; i < array_return_client.Length; i++)
                {
                    Console.WriteLine("client: data received is: " + array_return_client[i]);
                }
                Console.WriteLine("client: receive finished");
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
