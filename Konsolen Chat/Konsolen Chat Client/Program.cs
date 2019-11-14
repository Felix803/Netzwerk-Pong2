using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace Konsolen_Chat_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            client.startClient();

        }
    }
    class Client
    {
        Socket client_sock;
        IPEndPoint local_ipe, remote_ipe;
        string ip_adress;
        int port_remote;
        int port_local;
        byte[] buffer_receive;
        byte[] buffer_send;
        string received_message;
        string to_send;

        public void startClient()
        {
            ip_adress = "127.0.0.1";
            port_local = 12345;
            port_remote = 12346;
            client_sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            local_ipe = new IPEndPoint(IPAddress.Parse(ip_adress), port_local);
            remote_ipe = new IPEndPoint(IPAddress.Parse(ip_adress), port_remote);
            client_sock.Bind(local_ipe);
            client_sock.Connect(remote_ipe);
            Thread listening_thread = new Thread(receive);
            listening_thread.Start();
            Thread sending_thread = new Thread(send);
            sending_thread.Start();
        }
        private void receive()
        {
            while (true)
            {
                buffer_receive = new byte[64];
                client_sock.Receive(buffer_receive, buffer_receive.Length, SocketFlags.None);
                Callback();
            }
        }
        private void Callback()
        {
            received_message = ASCIIEncoding.ASCII.GetString(buffer_receive);
            Console.WriteLine("Received Message is: " + received_message);
        }
        private void send()
        {
            while (true)
            {
                buffer_send = new byte[64];
                Console.WriteLine("type Message here: ");
                to_send = Console.ReadLine();
                buffer_send = ASCIIEncoding.ASCII.GetBytes(to_send);
                client_sock.SendTo(buffer_send, 0, buffer_send.Length, SocketFlags.None, remote_ipe);
            }
            
        }
    }
}
