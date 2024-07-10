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
            this.ButtonEnter = new System.Windows.Forms.Button();
            this.ButtonSend = new System.Windows.Forms.Button();
            this.ButtonExit = new System.Windows.Forms.Button();
            this.ButtonBuzz = new System.Windows.Forms.Button();  // Inicializar este botón
            this.textBoxMessages = new System.Windows.Forms.TextBox();
            this.textBoxMessageInput = new System.Windows.Forms.TextBox();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.textBoxIPAddress = new System.Windows.Forms.TextBox();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.labelIPAddress = new System.Windows.Forms.Label();
            this.labelPort = new System.Windows.Forms.Label();
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
            // ButtonBuzz
            // 
            this.ButtonBuzz.Location = new System.Drawing.Point(174, 12);  // Ubicación para el nuevo botón
            this.ButtonBuzz.Name = "ButtonBuzz";
            this.ButtonBuzz.Size = new System.Drawing.Size(75, 23);
            this.ButtonBuzz.TabIndex = 3;
            this.ButtonBuzz.Text = "Zumbido";
            this.ButtonBuzz.UseVisualStyleBackColor = true;
            this.ButtonBuzz.Click += new System.EventHandler(this.ButtonBuzz_Click);

            // 
            // textBoxMessages
            // 
            this.textBoxMessages.Location = new System.Drawing.Point(12, 150);
            this.textBoxMessages.Multiline = true;
            this.textBoxMessages.Name = "textBoxMessages";
            this.textBoxMessages.ReadOnly = true;
            this.textBoxMessages.Size = new System.Drawing.Size(260, 70);
            this.textBoxMessages.TabIndex = 4;

            // 
            // textBoxMessageInput
            // 
            this.textBoxMessageInput.Location = new System.Drawing.Point(12, 229);
            this.textBoxMessageInput.Name = "textBoxMessageInput";
            this.textBoxMessageInput.Size = new System.Drawing.Size(179, 20);
            this.textBoxMessageInput.TabIndex = 5;
            this.textBoxMessageInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxMessageInput_KeyDown);

            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(12, 41);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(260, 20);
            this.textBoxUsername.TabIndex = 6;
            this.textBoxUsername.PlaceholderText = "Ingrese su nombre de usuario";

            // 
            // textBoxIPAddress
            // 
            this.textBoxIPAddress.Location = new System.Drawing.Point(12, 85);
            this.textBoxIPAddress.Name = "textBoxIPAddress";
            this.textBoxIPAddress.Size = new System.Drawing.Size(179, 20);
            this.textBoxIPAddress.TabIndex = 7;
            this.textBoxIPAddress.PlaceholderText = "Dirección IP";

            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(197, 85);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(75, 20);
            this.textBoxPort.TabIndex = 8;
            this.textBoxPort.PlaceholderText = "Puerto";

            // 
            // labelIPAddress
            // 
            this.labelIPAddress.AutoSize = true;
            this.labelIPAddress.Location = new System.Drawing.Point(12, 70);
            this.labelIPAddress.Name = "labelIPAddress";
            this.labelIPAddress.Size = new System.Drawing.Size(61, 13);
            this.labelIPAddress.TabIndex = 9;
            this.labelIPAddress.Text = "Dirección IP";

            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.Location = new System.Drawing.Point(197, 70);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(38, 13);
            this.labelPort.TabIndex = 10;
            this.labelPort.Text = "Puerto";

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.labelPort);
            this.Controls.Add(this.labelIPAddress);
            this.Controls.Add(this.textBoxPort);
            this.Controls.Add(this.textBoxIPAddress);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.textBoxMessageInput);
            this.Controls.Add(this.textBoxMessages);
            this.Controls.Add(this.ButtonBuzz);  // Añadir el nuevo botón al formulario
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