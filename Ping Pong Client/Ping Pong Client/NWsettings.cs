using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ping_Pong_Client
{
    public partial class NWsettings : Form
    {
        Form1 game;

        public NWsettings(Form1 g)
        {
            InitializeComponent();
            game = g;
        }

        private void rButtonClient_CheckedChanged(object sender, EventArgs e)
        {
            if(rButtonClient.Checked)
            {
                buttonConnect.Text = "Connect";
            }
            else
            {
                buttonConnect.Text = "Start";
            }
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (rButtonClient.Checked)
            {
                game.client = new Client();
                if (game.client.start())
                    game.client.addForm(game);
                game.client.startThreadClient();
                Close();
            }
            else
            {
                game.server = new Server();
                lblStatus.Text = "waiting for client";
                if (game.server.start())
                    game.server.addForm(game);
                game.server.startThreadServer();
                Close();
            }
        }
    }
}
