namespace Netzwerk_Pong2
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
            this.Server_Button = new System.Windows.Forms.Button();
            this.Server_Info = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Server_Button
            // 
            this.Server_Button.Location = new System.Drawing.Point(49, 25);
            this.Server_Button.Name = "Server_Button";
            this.Server_Button.Size = new System.Drawing.Size(293, 61);
            this.Server_Button.TabIndex = 0;
            this.Server_Button.Text = "Starte Server";
            this.Server_Button.UseVisualStyleBackColor = true;
            this.Server_Button.Click += new System.EventHandler(this.Server_Button_Click);
            // 
            // Server_Info
            // 
            this.Server_Info.AutoSize = true;
            this.Server_Info.Location = new System.Drawing.Point(50, 134);
            this.Server_Info.Name = "Server_Info";
            this.Server_Info.Size = new System.Drawing.Size(81, 17);
            this.Server_Info.TabIndex = 1;
            this.Server_Info.Text = "Server_Info";
            this.Server_Info.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 371);
            this.Controls.Add(this.Server_Info);
            this.Controls.Add(this.Server_Button);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Server_Button;
        private System.Windows.Forms.Label Server_Info;
    }
}

