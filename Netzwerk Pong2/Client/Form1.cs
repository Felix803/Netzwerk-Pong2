using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    public partial class Form1 : Form
    {
        private Socket sock_client; 
        public Form1()
        {
            InitializeComponent();
            sock_client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        private void Client_Button_Click(object sender, EventArgs e)
        {
            Connect();
            if (sock_client.Connected) {
                String req = "connected";
                Send_Request(req); //TODO: Implement TextField.
            };

        }
        public void Connect()
        {
            //IPEndPoint repräsentiert einen Netzwerk Endpunkt bestehend aus einer IP-Adresse und einer Port-Nummer.
            IPEndPoint ipe = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);
            //Client verbindet sich mit IPEndPoint
            sock_client.Connect(ipe);
            //Abfrage ob Verbindung hergestellt wurde
            if (sock_client.Connected)
            {
                Client_Info.Text = "Verbindung wurde hergestellt";
            }
            else
            {
                Client_Info.Text = "Fehler bei der Herstellung der Verbindung";
            }
        }

        public bool Send_Request(String request) {
            //Daten eingeben die gesendet werden sollen
            // Client_Info.Text = "Bitte geben Sie die zu sendenden Daten ein"; - TODO: Move to other label
            //eingegebenen String in Bytes umwandeln und in Array speichern
            if (request != "")
            {
                byte[] buffer_to_send = ASCIIEncoding.ASCII.GetBytes(request);
                sock_client.Send(buffer_to_send);
                Client_Info.Text = "Die Daten wurden versendet";
                sock_client.Close();
                return true;
            } else
            {
                return false;
            }
        }
    }
}
