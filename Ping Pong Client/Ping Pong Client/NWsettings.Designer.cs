namespace Ping_Pong_Client
{
    partial class NWsettings
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
            this.lblStatus = new System.Windows.Forms.Label();
            this.rButtonServer = new System.Windows.Forms.RadioButton();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.rButtonClient = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(147, 137);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // rButtonServer
            // 
            this.rButtonServer.AutoSize = true;
            this.rButtonServer.Location = new System.Drawing.Point(82, 26);
            this.rButtonServer.Name = "rButtonServer";
            this.rButtonServer.Size = new System.Drawing.Size(56, 17);
            this.rButtonServer.TabIndex = 1;
            this.rButtonServer.TabStop = true;
            this.rButtonServer.Text = "Server";
            this.rButtonServer.UseVisualStyleBackColor = true;
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(150, 74);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(75, 23);
            this.buttonConnect.TabIndex = 2;
            this.buttonConnect.Text = "Start";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // rButtonClient
            // 
            this.rButtonClient.AutoSize = true;
            this.rButtonClient.Location = new System.Drawing.Point(234, 26);
            this.rButtonClient.Name = "rButtonClient";
            this.rButtonClient.Size = new System.Drawing.Size(51, 17);
            this.rButtonClient.TabIndex = 3;
            this.rButtonClient.TabStop = true;
            this.rButtonClient.Text = "Client";
            this.rButtonClient.UseVisualStyleBackColor = true;
            this.rButtonClient.CheckedChanged += new System.EventHandler(this.rButtonClient_CheckedChanged);
            // 
            // NWsettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 171);
            this.Controls.Add(this.rButtonClient);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.rButtonServer);
            this.Controls.Add(this.lblStatus);
            this.Name = "NWsettings";
            this.Text = "Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.RadioButton rButtonServer;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.RadioButton rButtonClient;
    }
}