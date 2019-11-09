using System.Windows.Forms;

namespace Ping_Pong_Client
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.player1_score = new System.Windows.Forms.Label();
            this.player2_score = new System.Windows.Forms.Label();
            this.player_1 = new System.Windows.Forms.PictureBox();
            this.player_2 = new System.Windows.Forms.PictureBox();
            this.ball = new System.Windows.Forms.PictureBox();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.Server_Info = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Server_Button = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Client_Button = new System.Windows.Forms.Button();
            this.Client_info = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.player_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ball)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // player1_score
            // 
            this.player1_score.AutoSize = true;
            this.player1_score.ForeColor = System.Drawing.Color.LimeGreen;
            this.player1_score.Location = new System.Drawing.Point(67, 13);
            this.player1_score.Name = "player1_score";
            this.player1_score.Size = new System.Drawing.Size(98, 17);
            this.player1_score.TabIndex = 0;
            this.player1_score.Text = "player1_score";
            // 
            // player2_score
            // 
            this.player2_score.AutoSize = true;
            this.player2_score.ForeColor = System.Drawing.Color.Crimson;
            this.player2_score.Location = new System.Drawing.Point(669, 13);
            this.player2_score.Name = "player2_score";
            this.player2_score.Size = new System.Drawing.Size(46, 17);
            this.player2_score.TabIndex = 1;
            this.player2_score.Text = "label2";
            // 
            // player_1
            // 
            this.player_1.BackColor = System.Drawing.Color.Yellow;
            this.player_1.Location = new System.Drawing.Point(105, 9);
            this.player_1.Name = "player_1";
            this.player_1.Size = new System.Drawing.Size(27, 127);
            this.player_1.TabIndex = 2;
            this.player_1.TabStop = false;
            // 
            // player_2
            // 
            this.player_2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.player_2.Location = new System.Drawing.Point(735, 9);
            this.player_2.Name = "player_2";
            this.player_2.Size = new System.Drawing.Size(27, 127);
            this.player_2.TabIndex = 3;
            this.player_2.TabStop = false;
            // 
            // ball
            // 
            this.ball.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ball.Location = new System.Drawing.Point(275, 118);
            this.ball.Name = "ball";
            this.ball.Size = new System.Drawing.Size(27, 26);
            this.ball.TabIndex = 4;
            this.ball.TabStop = false;
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.timertick);
            // 
            // Server_Info
            // 
            this.Server_Info.AutoSize = true;
            this.Server_Info.ForeColor = System.Drawing.Color.White;
            this.Server_Info.Location = new System.Drawing.Point(6, 13);
            this.Server_Info.Name = "Server_Info";
            this.Server_Info.Size = new System.Drawing.Size(81, 17);
            this.Server_Info.TabIndex = 6;
            this.Server_Info.Text = "Server_info";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Server_Button);
            this.panel1.Controls.Add(this.Server_Info);
            this.panel1.Location = new System.Drawing.Point(1, 509);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(113, 57);
            this.panel1.TabIndex = 7;
            // 
            // Server_Button
            // 
            this.Server_Button.Location = new System.Drawing.Point(0, 31);
            this.Server_Button.Name = "Server_Button";
            this.Server_Button.Size = new System.Drawing.Size(110, 23);
            this.Server_Button.TabIndex = 7;
            this.Server_Button.Text = "Starte Server";
            this.Server_Button.UseVisualStyleBackColor = true;
            this.Server_Button.Click += new System.EventHandler(this.Server_Button_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Client_info);
            this.panel2.Controls.Add(this.Client_Button);
            this.panel2.Location = new System.Drawing.Point(793, 507);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(134, 58);
            this.panel2.TabIndex = 8;
            // 
            // Client_Button
            // 
            this.Client_Button.Location = new System.Drawing.Point(6, 33);
            this.Client_Button.Name = "Client_Button";
            this.Client_Button.Size = new System.Drawing.Size(127, 22);
            this.Client_Button.TabIndex = 0;
            this.Client_Button.Text = "Starte Client";
            this.Client_Button.UseVisualStyleBackColor = true;
            this.Client_Button.Click += new System.EventHandler(this.Client_Button_Click);
            // 
            // Client_info
            // 
            this.Client_info.AutoSize = true;
            this.Client_info.ForeColor = System.Drawing.Color.White;
            this.Client_info.Location = new System.Drawing.Point(12, 8);
            this.Client_info.Name = "Client_info";
            this.Client_info.Size = new System.Drawing.Size(74, 17);
            this.Client_info.TabIndex = 1;
            this.Client_info.Text = "Client_Info";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(926, 566);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ball);
            this.Controls.Add(this.player_2);
            this.Controls.Add(this.player_1);
            this.Controls.Add(this.player2_score);
            this.Controls.Add(this.player1_score);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Ping Pong Game";
            ((System.ComponentModel.ISupportInitialize)(this.player_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ball)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label player1_score;
        private System.Windows.Forms.Label player2_score;
        private System.Windows.Forms.PictureBox player_1;
        private System.Windows.Forms.PictureBox player_2;
        private System.Windows.Forms.PictureBox ball;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label Server_Info;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Server_Button;
        private Panel panel2;
        private Label Client_info;
        private Button Client_Button;
    }
}

