namespace ServidorForm1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnStart = new Button();
            listViewClientes = new ListView();
            puertobtn = new Button();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Location = new Point(132, 40);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(75, 23);
            btnStart.TabIndex = 0;
            btnStart.Text = "START";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // listViewClientes
            // 
            listViewClientes.Location = new Point(132, 69);
            listViewClientes.Name = "listViewClientes";
            listViewClientes.Size = new Size(421, 175);
            listViewClientes.TabIndex = 1;
            listViewClientes.UseCompatibleStateImageBehavior = false;
            listViewClientes.SelectedIndexChanged += listViewClient_SelectedIndexChanged;
            // 
            // puertobtn
            // 
            puertobtn.Location = new Point(213, 40);
            puertobtn.Name = "puertobtn";
            puertobtn.Size = new Size(75, 23);
            puertobtn.TabIndex = 2;
            puertobtn.Text = "Puerto";
            puertobtn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(puertobtn);
            Controls.Add(listViewClientes);
            Controls.Add(btnStart);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btnStart;
        private ListView listViewClientes;
        private Button puertobtn;
    }
}
