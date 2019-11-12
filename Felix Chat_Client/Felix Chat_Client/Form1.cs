using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Felix_Chat
{
    public partial class Form1 : Form
    {
        Socket Client_sock;
        EndPoint ep_local, ep_remote;
        byte[] buffer;
        string saveMessage;
        

        public void changeMessageList(string Message_cleared)
        {
            saveMessage = Message_cleared;
            SetMessageList(saveMessage);
        }
            

        public Form1()
        {
            InitializeComponent();
        }

        public void SetMessageList(String saveMessage)
        {
            if (InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate () { SetMessageList(saveMessage); });
                return;
            }
            MessageList.Items.Add("Remote: " + saveMessage);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //set up socket
            Client_sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            LocalIPText.Text = GetLocalIP();
            RemoteIPText.Text = GetLocalIP();
        }
        private void startlisteningThreadClient()
        {
            Thread listeningThreadClient = new Thread(recieve);
            listeningThreadClient.Start();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            //binding socket
            ep_local = new IPEndPoint(IPAddress.Parse(LocalIPText.Text), Convert.ToInt32(LocalPortText.Text));
            Client_sock.Bind(ep_local);
            //connecting to remoteip
            ep_remote = new IPEndPoint(IPAddress.Parse(RemoteIPText.Text), Convert.ToInt32(RemotePortText.Text));
            Client_sock.Connect(ep_remote);
            send_handshake();
        }
        private void recieve()
        {
            string Message = "";
            while (Message != "ciao")
            {
                //listening on specific port
                buffer = new byte[1024];
                Client_sock.Receive(buffer);
                MessageCallBack(buffer,Message);
            }
        }

        private string GetLocalIP()
        {
            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if(ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "127.0.0.1";
        }
        private void send_handshake()
        {
            ASCIIEncoding Encoding = new ASCIIEncoding();
            byte[] handshake = new byte[1024];
            handshake = Encoding.GetBytes("connect");
            client_info.Text = "connected";
            Client_sock.Send(handshake);
            startlisteningThreadClient();
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            ASCIIEncoding Encoding = new ASCIIEncoding();
            byte[] sendingMesage = new byte[1024];
            sendingMesage = Encoding.GetBytes(MessageText.Text);
            Client_sock.Send(sendingMesage);
            MessageList.Items.Add("Local: " + MessageText.Text);
            

            MessageText.Text = "";
        }

        private void MessageCallBack(byte[]buffer,string Message)
        {
          Message = ASCIIEncoding.ASCII.GetString(buffer).Trim();
          string Message_cleared = Message.Replace("\0", string.Empty);
            changeMessageList(Message_cleared);
        }

    }
}
