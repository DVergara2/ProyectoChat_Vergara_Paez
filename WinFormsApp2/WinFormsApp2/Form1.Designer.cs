namespace WinFormsApp2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button ButtonEnter;
        private System.Windows.Forms.Button ButtonSend;
        private System.Windows.Forms.Button ButtonExit;
        private System.Windows.Forms.Button ButtonBuzz;  // Añadir este botón
        private System.Windows.Forms.TextBox textBoxMessages;
        private System.Windows.Forms.TextBox textBoxMessageInput;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.TextBox textBoxIPAddress;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.Label labelIPAddress;
        private System.Windows.Forms.Label labelPort;

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
            ButtonEnter = new Button();
            ButtonSend = new Button();
            ButtonExit = new Button();
            ButtonBuzz = new Button();
            textBoxMessages = new TextBox();
            textBoxMessageInput = new TextBox();
            textBoxUsername = new TextBox();
            textBoxIPAddress = new TextBox();
            textBoxPort = new TextBox();
            labelIPAddress = new Label();
            labelPort = new Label();
            SuspendLayout();
            // 
            // ButtonEnter
            // 
            ButtonEnter.Location = new Point(14, 14);
            ButtonEnter.Margin = new Padding(4, 3, 4, 3);
            ButtonEnter.Name = "ButtonEnter";
            ButtonEnter.Size = new Size(88, 27);
            ButtonEnter.TabIndex = 0;
            ButtonEnter.Text = "Entrar";
            ButtonEnter.UseVisualStyleBackColor = true;
            ButtonEnter.Click += ButtonEnter_Click;
            // 
            // ButtonSend
            // 
            ButtonSend.BackColor = Color.Black;
            ButtonSend.ForeColor = SystemColors.ButtonHighlight;
            ButtonSend.Location = new Point(230, 262);
            ButtonSend.Margin = new Padding(4, 3, 4, 3);
            ButtonSend.Name = "ButtonSend";
            ButtonSend.Size = new Size(88, 27);
            ButtonSend.TabIndex = 1;
            ButtonSend.Text = "➡️";
            ButtonSend.UseVisualStyleBackColor = false;
            ButtonSend.Click += ButtonSend_Click;
            // 
            // ButtonExit
            // 
            ButtonExit.Location = new Point(121, 14);
            ButtonExit.Margin = new Padding(4, 3, 4, 3);
            ButtonExit.Name = "ButtonExit";
            ButtonExit.Size = new Size(88, 27);
            ButtonExit.TabIndex = 2;
            ButtonExit.Text = "Salir";
            ButtonExit.UseVisualStyleBackColor = true;
            ButtonExit.Click += ButtonExit_Click;
            // 
            // ButtonBuzz
            // 
            ButtonBuzz.BackColor = Color.DeepSkyBlue;
            ButtonBuzz.Location = new Point(230, 14);
            ButtonBuzz.Margin = new Padding(4, 3, 4, 3);
            ButtonBuzz.Name = "ButtonBuzz";
            ButtonBuzz.Size = new Size(88, 27);
            ButtonBuzz.TabIndex = 3;
            ButtonBuzz.Text = "🐝";
            ButtonBuzz.UseVisualStyleBackColor = false;
            ButtonBuzz.Click += ButtonBuzz_Click;
            // 
            // textBoxMessages
            // 
            textBoxMessages.Location = new Point(14, 173);
            textBoxMessages.Margin = new Padding(4, 3, 4, 3);
            textBoxMessages.Multiline = true;
            textBoxMessages.Name = "textBoxMessages";
            textBoxMessages.ReadOnly = true;
            textBoxMessages.Size = new Size(303, 80);
            textBoxMessages.TabIndex = 4;
            // 
            // textBoxMessageInput
            // 
            textBoxMessageInput.Location = new Point(14, 264);
            textBoxMessageInput.Margin = new Padding(4, 3, 4, 3);
            textBoxMessageInput.Name = "textBoxMessageInput";
            textBoxMessageInput.Size = new Size(208, 23);
            textBoxMessageInput.TabIndex = 5;
            textBoxMessageInput.KeyDown += textBoxMessageInput_KeyDown;
            // 
            // textBoxUsername
            // 
            textBoxUsername.Location = new Point(14, 47);
            textBoxUsername.Margin = new Padding(4, 3, 4, 3);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.PlaceholderText = "Ingrese su nombre de usuario";
            textBoxUsername.Size = new Size(303, 23);
            textBoxUsername.TabIndex = 6;
            // 
            // textBoxIPAddress
            // 
            textBoxIPAddress.Location = new Point(14, 98);
            textBoxIPAddress.Margin = new Padding(4, 3, 4, 3);
            textBoxIPAddress.Name = "textBoxIPAddress";
            textBoxIPAddress.PlaceholderText = "Dirección IP";
            textBoxIPAddress.Size = new Size(208, 23);
            textBoxIPAddress.TabIndex = 7;
            // 
            // textBoxPort
            // 
            textBoxPort.Location = new Point(230, 98);
            textBoxPort.Margin = new Padding(4, 3, 4, 3);
            textBoxPort.Name = "textBoxPort";
            textBoxPort.PlaceholderText = "Puerto";
            textBoxPort.Size = new Size(87, 23);
            textBoxPort.TabIndex = 8;
            // 
            // labelIPAddress
            // 
            labelIPAddress.AutoSize = true;
            labelIPAddress.Location = new Point(14, 81);
            labelIPAddress.Margin = new Padding(4, 0, 4, 0);
            labelIPAddress.Name = "labelIPAddress";
            labelIPAddress.Size = new Size(70, 15);
            labelIPAddress.TabIndex = 9;
            labelIPAddress.Text = "Dirección IP";
            // 
            // labelPort
            // 
            labelPort.AutoSize = true;
            labelPort.Location = new Point(230, 81);
            labelPort.Margin = new Padding(4, 0, 4, 0);
            labelPort.Name = "labelPort";
            labelPort.Size = new Size(42, 15);
            labelPort.TabIndex = 10;
            labelPort.Text = "Puerto";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            ClientSize = new Size(331, 299);
            Controls.Add(labelPort);
            Controls.Add(labelIPAddress);
            Controls.Add(textBoxPort);
            Controls.Add(textBoxIPAddress);
            Controls.Add(textBoxUsername);
            Controls.Add(textBoxMessageInput);
            Controls.Add(textBoxMessages);
            Controls.Add(ButtonBuzz);
            Controls.Add(ButtonExit);
            Controls.Add(ButtonSend);
            Controls.Add(ButtonEnter);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "Crisvid Chat";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}