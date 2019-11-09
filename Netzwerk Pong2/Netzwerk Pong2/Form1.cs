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
using System.Threading;

namespace Netzwerk_Pong2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Server_Button_Click(object sender, EventArgs e)
        {
            Server_Info.Text = "Alles ok.";
            Server_Start();
        }
        public void Server_Start()
        {
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Server_Info.Text = "Socket open, attemptin connection.";

            //IPEndPoint repräsentiert einen Netzwerk Endpunkt bestehend aus einer IP-Adresse und einer Port-Nummer.
            IPEndPoint ipe = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);

            //der Socket sock wartet nun auf eine eingehende Verbindung
            Server_Info.Text = "Hier gibt es nichts zu sehen.";
            try {
                //Binding und Erfolgsmeldung
                sock.Bind(ipe);
                Server_Info.Text = "Der Server wurde an den Endpunkt gebunden";

                // hier wird die eingehende Verbindung aktzeptiert
                sock.Listen(1);
                Socket client_sock = sock.Accept();
                Server_Info.Text = "Client connected";
    
                // lese die Daten, die der Client schickt, die Methode Receive benötigt einen Buffer der die Daten enthält
                byte[] buffer = new byte[64];
                int received_bytes = client_sock.Receive(buffer);
                Server_Info.Text = "Es wurden" + received_bytes + "Bytes empfangen";
                // Decodiert die empfangenen Daten aus dem buffer startet bei 0 und endet bei der Größe der übertragenen Daten (received bytes)
                Server_Info.Text = ASCIIEncoding.ASCII.GetString(buffer, 0, received_bytes);
            }
            catch (SocketException e) { Server_Info.Text = "Hier gibt es was zu sehen."; };
        }
    }
}
