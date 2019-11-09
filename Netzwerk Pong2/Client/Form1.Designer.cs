namespace Client
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
            this.Client_Button = new System.Windows.Forms.Button();
            this.Client_Info = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Client_Button
            // 
            this.Client_Button.Location = new System.Drawing.Point(342, 79);
            this.Client_Button.Name = "Client_Button";
            this.Client_Button.Size = new System.Drawing.Size(400, 77);
            this.Client_Button.TabIndex = 0;
            this.Client_Button.Text = "Starte Client";
            this.Client_Button.UseVisualStyleBackColor = true;
            this.Client_Button.Click += new System.EventHandler(this.Client_Button_Click);
            // 
            // Client_Info
            // 
            this.Client_Info.AutoSize = true;
            this.Client_Info.Location = new System.Drawing.Point(45, 139);
            this.Client_Info.Name = "Client_Info";
            this.Client_Info.Size = new System.Drawing.Size(74, 17);
            this.Client_Info.TabIndex = 1;
            this.Client_Info.Text = "Client_Info";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(157, 139);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 253);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Client_Info);
            this.Controls.Add(this.Client_Button);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Client_Button;
        private System.Windows.Forms.Label Client_Info;
        private System.Windows.Forms.TextBox textBox1;
    }
}

