namespace ChatTcpEncriptado
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.TextBox txtPuerto;
        private System.Windows.Forms.TextBox txtMensaje;
        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.Button btnIniciarServidor;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.TextBox txtLog;

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
            this.txtIP = new System.Windows.Forms.TextBox();
            this.txtPuerto = new System.Windows.Forms.TextBox();
            this.txtMensaje = new System.Windows.Forms.TextBox();
            this.btnConectar = new System.Windows.Forms.Button();
            this.btnIniciarServidor = new System.Windows.Forms.Button();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(12, 12);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(150, 20);
            this.txtIP.TabIndex = 0;
            this.txtIP.Text = "127.0.0.1";
            // 
            // txtPuerto
            // 
            this.txtPuerto.Location = new System.Drawing.Point(168, 12);
            this.txtPuerto.Name = "txtPuerto";
            this.txtPuerto.Size = new System.Drawing.Size(100, 20);
            this.txtPuerto.TabIndex = 1;
            this.txtPuerto.Text = "5000";
            // 
            // txtMensaje
            // 
            this.txtMensaje.Location = new System.Drawing.Point(12, 240);
            this.txtMensaje.Name = "txtMensaje";
            this.txtMensaje.Size = new System.Drawing.Size(350, 20);
            this.txtMensaje.TabIndex = 2;
            // 
            // btnConectar
            // 
            this.btnConectar.Location = new System.Drawing.Point(274, 10);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(88, 23);
            this.btnConectar.TabIndex = 3;
            this.btnConectar.Text = "Conectar";
            this.btnConectar.UseVisualStyleBackColor = true;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // btnIniciarServidor
            // 
            this.btnIniciarServidor.Location = new System.Drawing.Point(368, 10);
            this.btnIniciarServidor.Name = "btnIniciarServidor";
            this.btnIniciarServidor.Size = new System.Drawing.Size(110, 23);
            this.btnIniciarServidor.TabIndex = 4;
            this.btnIniciarServidor.Text = "Iniciar Servidor";
            this.btnIniciarServidor.UseVisualStyleBackColor = true;
            this.btnIniciarServidor.Click += new System.EventHandler(this.btnIniciarServidor_Click);
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(368, 237);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(110, 23);
            this.btnEnviar.TabIndex = 5;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(12, 40);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(466, 190);
            this.txtLog.TabIndex = 6;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(490, 270);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.btnIniciarServidor);
            this.Controls.Add(this.btnConectar);
            this.Controls.Add(this.txtMensaje);
            this.Controls.Add(this.txtPuerto);
            this.Controls.Add(this.txtIP);
            this.Name = "Form1";
            this.Text = "Chat TCP Encriptado";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
