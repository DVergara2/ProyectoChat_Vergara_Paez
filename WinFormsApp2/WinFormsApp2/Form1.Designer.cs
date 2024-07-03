/*namespace WinFormsApp2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button ButtonEnter;
        private System.Windows.Forms.Button ButtonSend;
        private System.Windows.Forms.TextBox textBoxMessages;
        private System.Windows.Forms.TextBox textBoxMessageInput;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.ButtonEnter = new System.Windows.Forms.Button();
            this.ButtonSend = new System.Windows.Forms.Button();
            this.textBoxMessages = new System.Windows.Forms.TextBox();
            this.textBoxMessageInput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();

            // 
            // ButtonEnter
            // 
            this.ButtonEnter.Location = new System.Drawing.Point(12, 12);
            this.ButtonEnter.Name = "ButtonEnter";
            this.ButtonEnter.Size = new System.Drawing.Size(75, 23);
            this.ButtonEnter.TabIndex = 0;
            this.ButtonEnter.Text = "Entrar";
            this.ButtonEnter.UseVisualStyleBackColor = true;
            this.ButtonEnter.Click += new System.EventHandler(this.ButtonEnter_Click);

            // 
            // ButtonSend
            // 
            this.ButtonSend.Location = new System.Drawing.Point(197, 227);
            this.ButtonSend.Name = "ButtonSend";
            this.ButtonSend.Size = new System.Drawing.Size(75, 23);
            this.ButtonSend.TabIndex = 1;
            this.ButtonSend.Text = "Enviar";
            this.ButtonSend.UseVisualStyleBackColor = true;
            this.ButtonSend.Click += new System.EventHandler(this.ButtonSend_Click);

            // 
            // textBoxMessages
            // 
            this.textBoxMessages.Location = new System.Drawing.Point(12, 41);
            this.textBoxMessages.Multiline = true;
            this.textBoxMessages.Name = "textBoxMessages";
            this.textBoxMessages.ReadOnly = true;
            this.textBoxMessages.Size = new System.Drawing.Size(260, 180);
            this.textBoxMessages.TabIndex = 2;

            // 
            // textBoxMessageInput
            // 
            this.textBoxMessageInput.Location = new System.Drawing.Point(12, 229);
            this.textBoxMessageInput.Name = "textBoxMessageInput";
            this.textBoxMessageInput.Size = new System.Drawing.Size(179, 20);
            this.textBoxMessageInput.TabIndex = 3;

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.textBoxMessageInput);
            this.Controls.Add(this.textBoxMessages);
            this.Controls.Add(this.ButtonSend);
            this.Controls.Add(this.ButtonEnter);
            this.Name = "Form1";
            this.Text = "SimpleChat";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}*/


namespace WinFormsApp2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button ButtonEnter;
        private System.Windows.Forms.Button ButtonSend;
        private System.Windows.Forms.Button ButtonExit;
        private System.Windows.Forms.TextBox textBoxMessages;
        private System.Windows.Forms.TextBox textBoxMessageInput;
        private System.Windows.Forms.TextBox textBoxUsername;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.ButtonEnter = new System.Windows.Forms.Button();
            this.ButtonSend = new System.Windows.Forms.Button();
            this.ButtonExit = new System.Windows.Forms.Button();
            this.textBoxMessages = new System.Windows.Forms.TextBox();
            this.textBoxMessageInput = new System.Windows.Forms.TextBox();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.SuspendLayout();

            // 
            // ButtonEnter
            // 
            this.ButtonEnter.Location = new System.Drawing.Point(12, 12);
            this.ButtonEnter.Name = "ButtonEnter";
            this.ButtonEnter.Size = new System.Drawing.Size(75, 23);
            this.ButtonEnter.TabIndex = 0;
            this.ButtonEnter.Text = "Entrar";
            this.ButtonEnter.UseVisualStyleBackColor = true;
            this.ButtonEnter.Click += new System.EventHandler(this.ButtonEnter_Click);

            // 
            // ButtonSend
            // 
            this.ButtonSend.Location = new System.Drawing.Point(197, 227);
            this.ButtonSend.Name = "ButtonSend";
            this.ButtonSend.Size = new System.Drawing.Size(75, 23);
            this.ButtonSend.TabIndex = 1;
            this.ButtonSend.Text = "Enviar";
            this.ButtonSend.UseVisualStyleBackColor = true;
            this.ButtonSend.Click += new System.EventHandler(this.ButtonSend_Click);

            // 
            // ButtonExit
            // 
            this.ButtonExit.Location = new System.Drawing.Point(93, 12);
            this.ButtonExit.Name = "ButtonExit";
            this.ButtonExit.Size = new System.Drawing.Size(75, 23);
            this.ButtonExit.TabIndex = 2;
            this.ButtonExit.Text = "Salir";
            this.ButtonExit.UseVisualStyleBackColor = true;
            this.ButtonExit.Click += new System.EventHandler(this.ButtonExit_Click);

            // 
            // textBoxMessages
            // 
            this.textBoxMessages.Location = new System.Drawing.Point(12, 70);
            this.textBoxMessages.Multiline = true;
            this.textBoxMessages.Name = "textBoxMessages";
            this.textBoxMessages.ReadOnly = true;
            this.textBoxMessages.Size = new System.Drawing.Size(260, 150);
            this.textBoxMessages.TabIndex = 3;

            // 
            // textBoxMessageInput
            // 
            this.textBoxMessageInput.Location = new System.Drawing.Point(12, 229);
            this.textBoxMessageInput.Name = "textBoxMessageInput";
            this.textBoxMessageInput.Size = new System.Drawing.Size(179, 20);
            this.textBoxMessageInput.TabIndex = 4;
            this.textBoxMessageInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxMessageInput_KeyDown);

            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(12, 41);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(260, 20);
            this.textBoxUsername.TabIndex = 5;
            this.textBoxUsername.PlaceholderText = "Ingrese su nombre de usuario";

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.textBoxMessageInput);
            this.Controls.Add(this.textBoxMessages);
            this.Controls.Add(this.ButtonExit);
            this.Controls.Add(this.ButtonSend);
            this.Controls.Add(this.ButtonEnter);
            this.Name = "Form1";
            this.Text = "SimpleChat";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

