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

namespace Felix_Chat
{
    public partial class Form1 : Form
    {
        Socket sock;
        EndPoint ep_local, ep_remote;
        byte[] buffer;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //set up socket
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            sock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            LocalIPText.Text = GetLocalIP();
            RemoteIPText.Text = GetLocalIP();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            //binding socket
            ep_local = new IPEndPoint(IPAddress.Parse(LocalIPText.Text), Convert.ToInt32(LocalPortText.Text));
            sock.Bind(ep_local);
            //connecting to remoteip
            ep_remote = new IPEndPoint(IPAddress.Parse(RemoteIPText.Text), Convert.ToInt32(RemotePortText.Text));
            sock.Connect(ep_remote);
            //listening on specific port
            buffer = new byte[1024];
            sock.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref ep_remote, new AsyncCallback(MessageCallBack),buffer);
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

        private void buttonSend_Click(object sender, EventArgs e)
        {
            ASCIIEncoding Encoding = new ASCIIEncoding();
            byte[] sendingMesage = new byte[1024];
            sendingMesage = Encoding.GetBytes(MessageText.Text);
            sock.Send(sendingMesage);
            MessageList.Items.Add("Local: " + MessageText.Text);
            MessageText.Text = "";
        }

        private void MessageCallBack(IAsyncResult Result)
        {
            try
            {
                byte[] recieved_data = new byte[1024];
                recieved_data = (byte[])Result.AsyncState;
                //Converting Byte to string
                ASCIIEncoding Encoding = new ASCIIEncoding();
                string recievedMessage = Encoding.GetString(recieved_data);

                //Adding this Message to List
                MessageList.Items.Add("Remote: " + recievedMessage);

                buffer = new byte[1024];
                sock.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref ep_remote, new AsyncCallback(MessageCallBack), buffer);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            

        }

    }
}
