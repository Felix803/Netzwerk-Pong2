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
using System.Xml.Serialization;




namespace Ping_Pong_Client
{
    public partial class Form1 : Form
    {
        public Client client;
        public Server server;
        Player player1 = new Player(false, false, 0, 225);
        Player player2 = new Player(false, false, 0, 225);
        Ball ball1 = new Ball(5, 5, 434, 225);
        Serializer Sz = new Serializer();

        public string serialized;

        public Form1()
        {
            InitializeComponent();
            Hide();
            NWsettings settings = new NWsettings(this);
            settings.ShowDialog();
            Show();
            gameTimer.Start();
        }

        public Form1(Client c, Server s)
        {
            InitializeComponent();
            client = c;
            server = s;
            Client_Button.Enabled = false;
            Server_Button.Enabled = false;
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
            server.startThreadServer();
        }

        public void change_Server_Info(string server_info)
        {
            Server_Info.Text = server_info;
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            player1.go_up = false;
            player2.go_up = false;
            player1.go_down = false;
            player2.go_down = false;

            if (e.KeyCode == Keys.Up)
            {
                player1.go_up = true;
                player2.go_up = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                player1.go_down = true;
                player2.go_down = true;
            }

        }
        private void keyisup(object sender, KeyEventArgs e)
        {
            player1.go_up = false;
            player2.go_up = false;
            player1.go_down = false;
            player2.go_down = false;

            if (e.KeyCode == Keys.Up)
            {
                player1.go_down = false;
                player2.go_down = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                player1.go_up = false;
                player2.go_up = false;
            }
        }


        //timer auf 20 millisec eingestellt im designer alle 20millisec wird der nachstehende codeblock ausgeführt
        private void timertick(object sender, EventArgs e)
        {
            if (server != null)
            {
                controle_player1();
                calculate_enemy_player(player2);
                controle_ball();
            }

            if (client != null)
            {
                controle_player2();
                calculate_enemy_player(player1);
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
            player1.player_posy = player_1.Top;
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
            
            if (server.clientConnected)
            {
                server.send(Sz.serialize_player(player1) + Sz.serialize_ball_data(ball1));
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
            player2.player_posy = player_2.Top;
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

            client.send(Sz.serialize_player(player2));
            process_received_ball_data();
        }

        private void calculate_enemy_player(Player player)
        {
            if (server != null)
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
            else if (client != null)
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

        }

        private void process_received_ball_data()
        {
            ball.Top = ball1.ball_posy;
            ball.Left = ball1.ball_posx;
            player1_score.Text = "" + player1.player_score;
            player2_score.Text = "" + player2.player_score;
        }

        private void controle_ball()
        {
            //initialisiere Playerscore Label
            player1_score.Text = "" + player1.player_score;
            player2_score.Text = "" + player2.player_score;

            //controlling ball
            ball.Top -= ball1.bally;//füge position ball y und geschwindigkeit y zusammen
            ball.Left -= ball1.ballx;//füge position ball x und geschwindigkeit x zusammen

            if (ball.Left < 0)
            {
                ball.Left = 434;//setze den Ball wieder in die Mitte
                ball1.ballx = -ball1.ballx;//ändere die Richtung
                ball1.ballx -= 1;//beschleunige den Ball
                player2.player_score++;//erhöhe Punkte um 1
            }
            if (ball.Left + ball.Width > ClientSize.Width)
            {
                ball.Left = 434;
                ball1.ballx = -ball1.ballx;
                ball1.ballx += 1;
                player1.player_score++;
            }

            if (ball.Top < 0 || ball.Top + ball.Height > ClientSize.Height)
            {
                ball1.bally = -ball1.bally;
            }
            if (ball.Bounds.IntersectsWith(player_1.Bounds) || ball.Bounds.IntersectsWith(player_2.Bounds))
            {
                ball1.ballx = -ball1.ballx;
            }
            ball1.ball_posy = ball.Top;
            ball1.ball_posx = ball.Left;
        }

        public void callback_receive_server(string[] data)
        {
            if (data.Length > 3)
            {
                player2.go_up = false;
                player2.go_down = false;
                player2.go_down = Convert.ToBoolean(data[0]);
                player2.go_up = Convert.ToBoolean(data[1]);
                player2.player_score = Convert.ToInt32(data[2]);
                player2.player_posy = Convert.ToInt32(data[3]);
            }
            Console.WriteLine("@Server: callback finished");
        }

        public void callback_receive_client(string[] data)
        {
            if (data.Length > 7)
            {
                player1.go_up = false;
                player1.go_down = false;
                player1.go_down = Convert.ToBoolean(data[0]);
                player1.go_up = Convert.ToBoolean(data[1]);
                player1.player_score = Convert.ToInt32(data[2]);
                player1.player_posy = Convert.ToInt32(data[3]);
                ball1.ballx = Convert.ToInt32(data[4]);
                ball1.bally = Convert.ToInt32(data[5]);
                ball1.ball_posx = Convert.ToInt32(data[6]);
                ball1.ball_posy = Convert.ToInt32(data[7]);
            }
            Console.WriteLine("@Client: callback finished");
        }


    }
}
