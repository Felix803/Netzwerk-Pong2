namespace Felix_Chat
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.MessageList = new System.Windows.Forms.ListBox();
            this.MessageText = new System.Windows.Forms.TextBox();
            this.LocalIPText = new System.Windows.Forms.TextBox();
            this.LocalPortText = new System.Windows.Forms.TextBox();
            this.RemoteIPText = new System.Windows.Forms.TextBox();
            this.RemotePortText = new System.Windows.Forms.TextBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LocalPortText);
            this.groupBox1.Controls.Add(this.LocalIPText);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(38, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(271, 118);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Local";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RemotePortText);
            this.groupBox2.Controls.Add(this.RemoteIPText);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(379, 18);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(287, 117);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Remote";
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(744, 50);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(182, 47);
            this.buttonConnect.TabIndex = 2;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Port";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "IP";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Port";
            // 
            // MessageList
            // 
            this.MessageList.FormattingEnabled = true;
            this.MessageList.ItemHeight = 16;
            this.MessageList.Location = new System.Drawing.Point(38, 149);
            this.MessageList.Name = "MessageList";
            this.MessageList.Size = new System.Drawing.Size(627, 228);
            this.MessageList.TabIndex = 3;
            // 
            // MessageText
            // 
            this.MessageText.Location = new System.Drawing.Point(38, 394);
            this.MessageText.Name = "MessageText";
            this.MessageText.Size = new System.Drawing.Size(627, 22);
            this.MessageText.TabIndex = 4;
            // 
            // LocalIPText
            // 
            this.LocalIPText.Location = new System.Drawing.Point(103, 36);
            this.LocalIPText.Name = "LocalIPText";
            this.LocalIPText.Size = new System.Drawing.Size(103, 22);
            this.LocalIPText.TabIndex = 2;
            // 
            // LocalPortText
            // 
            this.LocalPortText.Location = new System.Drawing.Point(104, 68);
            this.LocalPortText.Name = "LocalPortText";
            this.LocalPortText.Size = new System.Drawing.Size(102, 22);
            this.LocalPortText.TabIndex = 3;
            // 
            // RemoteIPText
            // 
            this.RemoteIPText.Location = new System.Drawing.Point(90, 34);
            this.RemoteIPText.Name = "RemoteIPText";
            this.RemoteIPText.Size = new System.Drawing.Size(138, 22);
            this.RemoteIPText.TabIndex = 2;
            // 
            // RemotePortText
            // 
            this.RemotePortText.Location = new System.Drawing.Point(90, 68);
            this.RemotePortText.Name = "RemotePortText";
            this.RemotePortText.Size = new System.Drawing.Size(138, 22);
            this.RemotePortText.TabIndex = 3;
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(744, 382);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(182, 34);
            this.buttonSend.TabIndex = 5;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 446);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.MessageText);
            this.Controls.Add(this.MessageList);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox LocalPortText;
        private System.Windows.Forms.TextBox LocalIPText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox RemotePortText;
        private System.Windows.Forms.TextBox RemoteIPText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.ListBox MessageList;
        private System.Windows.Forms.TextBox MessageText;
        private System.Windows.Forms.Button buttonSend;
    }
}

