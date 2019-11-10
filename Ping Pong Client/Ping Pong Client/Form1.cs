﻿using System;
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
using System.Xml.Serialization;




namespace Ping_Pong_Client
{
    public partial class Form1 : Form
    {
        Client client;
        Server server;
        Player player1 = new Player(false, false, 0);
        Player player2 = new Player(false, false, 0);
        int ballx = 5;//horizontale Geschwindigkeit (Vektor)
        int bally = 5;//vertikale Geschwindigkeit (Vektor)
        public string serialized;
        public string[] array_data_received_server = new string[3];
        public string[] array_data_received_client = new string[3];


        public Form1()
        {
            InitializeComponent();
        }

        public void change_Client_Info(string client_info)
        {
            Client_info.Text = client_info;
        }
        private void Client_Button_Click(object sender, EventArgs e)
        {
            client = new Client(this);
            client.startThreadClient();
        }
        private void Server_Button_Click(object sender, EventArgs e)
        {
            server = new Server(this);

            Server_Info.Text = "Server bereit.";
            server.startTrheadServer();
        }

        public void change_Server_Info(string server_info)
        {
            Server_Info.Text = server_info;
        }


        //sorgt dafür dass die Key eingabe an die Steuerelement der UI übergeben werden trotz fehlendem focus
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == Keys.Up)
            {
                player1.go_down = false;
                player1.go_up = true;
            }
            if (keyData == Keys.Down)
            {
                player1.go_down = true;
                player1.go_up = false;
            }
            if (keyData == Keys.Up)
            {
                player2.go_down = false;
                player2.go_up = true;
            }
            if (keyData == Keys.Down)
            {
                player2.go_down = true;
                player2.go_up = false;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


        //timer auf 20 millisec eingestellt im designer alle 20millisec wird der nachstehende codeblock ausgeführt
        private void timertick(object sender, EventArgs e)
        {
            if (server != null)
            {
                controle_player1();
                calculate_enemy_player2();
                controle_ball();
            }

            if (client != null)
            {
                controle_player2();
                calculate_enemy_player1();
                controle_ball();
            }
        }

        private void controle_player1()
        {
            //controlling Player
            if (player1.go_up == true && player_1.Top > 0)
            {
                player_1.Top -= 8;
            }
            if (player1.go_down == true && player_1.Top < 455)
            {
                player_1.Top += 8;
            }
            if (player1.player_score > 10)
            {
                gameTimer.Stop();
                MessageBox.Show("You win this game");
            }
            if (player2.player_score > 10)
            {
                gameTimer.Stop();
                MessageBox.Show("Player_2 wins more luck next time looooser!");
            }
            player2.go_down = Convert.ToBoolean(array_data_received_server[0]);
            player2.go_up = Convert.ToBoolean(array_data_received_server[1]);
            player2.player_score = Convert.ToInt32(array_data_received_server[2]);

            if (server.ClientConnected)
            {
                server.send(serialize_player1());
            }



        }
        private void calculate_enemy_player2()
        {
            if (player2.go_up == true && player_2.Top > 0)
            {
                player_2.Top -= 8;
            }
            if (player2.go_down == true && player_2.Top < 455)
            {
                player_2.Top += 8;
            }
        }

        private void calculate_enemy_player1()
        {
            if (player1.go_up == true && player_1.Top > 0)
            {
                player_1.Top -= 8;
            }
            if (player1.go_down == true && player_1.Top < 455)
            {
                player_1.Top += 8;
            }
        }

        private void controle_player2()
        {

            //controlling Player
            if (player2.go_up == true && player_2.Top > 0)
            {
                player_2.Top -= 8;
            }
            if (player2.go_down == true && player_2.Top < 455)
            {
                player_2.Top += 8;
            }
            if (player2.player_score > 10)
            {
                gameTimer.Stop();
                MessageBox.Show("You win this game");
            }
            if (player1.player_score > 10)
            {
                gameTimer.Stop();
                MessageBox.Show("Player_2 wins more luck next time looooser!");
            }
            client.send(serialize_player2());
            player1.go_down = Convert.ToBoolean(array_data_received_client[0]);
            player1.go_up = Convert.ToBoolean(array_data_received_client[1]);
            player1.player_score = Convert.ToInt32(array_data_received_client[2]);


        }

        private void controle_ball()
        {
            //initialisiere Playerscore Label
            player1_score.Text = "" + player1.player_score;
            player2_score.Text = "" + player2.player_score;

            //controlling ball
            ball.Top -= bally;//füge position ball y und geschwindigkeit y zusammen
            ball.Left -= ballx;//füge position ball x und geschwindigkeit x zusammen

            if (ball.Left < 0)
            {
                ball.Left = 434;//setze den Ball wieder in die Mitte
                ballx = -ballx;//ändere die Richtung
                ballx -= 2;//beschleunige den Ball
                player2.player_score++;//erhöhe Punkte um 1
            }
            if (ball.Left + ball.Width > ClientSize.Width)
            {
                ball.Left = 434;
                ballx = -ballx;
                ballx += 2;
                player1.player_score++;
            }

            if (ball.Top < 0 || ball.Top + ball.Height > ClientSize.Height)
            {
                bally = -bally;
            }
            if (ball.Bounds.IntersectsWith(player_1.Bounds) || ball.Bounds.IntersectsWith(player_2.Bounds))
            {
                ballx = -ballx;
            }
        }
        public void callback_receive_server(string[] data)
        {
            if (data.Length > 2)
            {
                player2.go_down = false;
                player2.go_up = false;
                if (data[0] == "True")
                {
                    player2.go_down = true;
                }
                if (data[1] == "True")
                {
                    player2.go_up = true;
                }
            }
            array_data_received_server = data;
            Console.WriteLine("@Server: callback finished");
        }
        public void callback_receive_client(string[] data)
        {
            if (data.Length > 2)
            {
                player1.go_down = false;
                player1.go_up = false;
                if (data[0] == "True")
                {
                    player1.go_down = true;
                }
                if (data[1] == "True")
                {
                    player1.go_up = true;
                }

            }

            array_data_received_client = data;
            Console.WriteLine("@Client: callback finished");
        }
        public string serialize_player1()
        {
            serialized = player1.go_down + "," + player1.go_up + "," + player1.player_score;
            return serialized;
        }

        public string serialize_player2()
        {
            serialized = player2.go_down + "," + player2.go_up + "," + player2.player_score;
            return serialized;
        }

    }
}
