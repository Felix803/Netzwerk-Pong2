﻿using System;
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
        Socket Server_sock;
        EndPoint ep_local, ep_remote;
        byte[] buffer;
        bool Client_connect = false;
        string saveMessage;
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
            if (Client_connect == true)
            {
                server_info.Text = "connected";
            }
            MessageList.Items.Add("Remote: " + saveMessage);
        }

        public void changeMessageList(string return_data_cleared)
        {
            saveMessage = return_data_cleared;
            SetMessageList(saveMessage);
        }
        private void startlisteningThreadServer()
        {
            Thread Listening_Thread_Server = new Thread(recieve);
            Listening_Thread_Server.Start();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //set up socket
            Server_sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            LocalIPText.Text = GetLocalIP();
            RemoteIPText.Text = GetLocalIP();
        }
        private void buttonListen_Click(object sender, EventArgs e)
        {
            //binding socket
            ep_local = new IPEndPoint(IPAddress.Parse(LocalIPText.Text), Convert.ToInt32(LocalPortText.Text));
            Server_sock.Bind(ep_local);
            //connecting to remoteip
            ep_remote = new IPEndPoint(IPAddress.Parse(RemoteIPText.Text), Convert.ToInt32(RemotePortText.Text));
            startlisteningThreadServer();
        }
        private void recieve()
        {
            string return_data="";
            while(return_data != "ciao")
            {
                buffer = new byte[1024];
                Server_sock.ReceiveFrom(buffer, ref ep_remote);
                MessageCallBack(return_data);
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

        private void buttonSend_Click(object sender, EventArgs e)
        {
            ASCIIEncoding Encoding = new ASCIIEncoding();
            byte[] sendingMessage = new byte[1024];
            sendingMessage = Encoding.GetBytes(MessageText.Text);
            if (Client_connect == true)
            {
                Server_sock.SendTo(sendingMessage, ep_remote);
                MessageList.Items.Add("Local: " + MessageText.Text);
                MessageText.Text = "";
            }
        }

        private void MessageCallBack(string return_data)
        {
            return_data = ASCIIEncoding.ASCII.GetString(buffer).Trim();
            string return_data_cleared = return_data.Replace("\0", string.Empty);
            if (return_data_cleared == "connect")
            {
                Client_connect = true;
            }
            changeMessageList(return_data_cleared);
        }
    }
}
