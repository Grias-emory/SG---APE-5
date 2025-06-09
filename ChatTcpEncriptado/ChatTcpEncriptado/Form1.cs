using System;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Threading;

namespace ChatTcpEncriptado
{
    public partial class Form1 : Form
    {
        TcpListener listener;
        TcpClient client;
        NetworkStream stream;
        Thread recibirThread;
        static string claveSecreta = "claveSegura16bts"; 

        public Form1()
        {
            InitializeComponent();
        }

        private void btnIniciarServidor_Click(object sender, EventArgs e)
        {
            int puerto = int.Parse(txtPuerto.Text);
            listener = new TcpListener(IPAddress.Any, puerto);
            listener.Start();
            txtLog.AppendText("Servidor iniciado en puerto " + puerto + "\r\n");

            Thread serverThread = new Thread(() =>
            {
                client = listener.AcceptTcpClient();
                stream = client.GetStream();
                this.Invoke((MethodInvoker)(() => txtLog.AppendText("Cliente conectado.\r\n")));

                byte[] buffer = new byte[1024];
                int bytesLeidos;
                while ((bytesLeidos = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    string mensajeEncriptado = Encoding.UTF8.GetString(buffer, 0, bytesLeidos);
                    string mensaje = Desencriptar(mensajeEncriptado);
                    this.Invoke((MethodInvoker)(() => txtLog.AppendText("Recibido: " + mensaje + "\r\n")));
                }
            });
            serverThread.IsBackground = true;
            serverThread.Start();
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            try
            {
                client = new TcpClient();
                client.Connect(txtIP.Text, int.Parse(txtPuerto.Text));
                stream = client.GetStream();
                txtLog.AppendText("Conectado al servidor.\r\n");

                recibirThread = new Thread(() =>
                {
                    byte[] buffer = new byte[1024];
                    int bytesLeidos;
                    while ((bytesLeidos = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        string mensajeEncriptado = Encoding.UTF8.GetString(buffer, 0, bytesLeidos);
                        string mensaje = Desencriptar(mensajeEncriptado);
                        this.Invoke((MethodInvoker)(() => txtLog.AppendText("Recibido: " + mensaje + "\r\n")));
                    }
                });
                recibirThread.IsBackground = true;
                recibirThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar: " + ex.Message);
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (stream != null && client.Connected && stream.CanWrite)
            {
                string mensaje = txtMensaje.Text;
                string mensajeEncriptado = Encriptar(mensaje);
                byte[] datos = Encoding.UTF8.GetBytes(mensajeEncriptado);
                stream.Write(datos, 0, datos.Length);
                txtLog.AppendText("Enviado: " + mensaje + "\r\n");
                txtMensaje.Clear();
            }
        }

        private string Encriptar(string texto)
        {
            using (Aes aes = Aes.Create())
            {
                byte[] clave = Encoding.UTF8.GetBytes(claveSecreta);

                // Asegura que la clave tenga 16 bytes (AES-128)
                if (clave.Length != 16)
                    throw new ArgumentException("La clave debe tener exactamente 16 caracteres para AES-128.");

                aes.Key = clave;
                aes.IV = new byte[16]; // Vector de inicialización fijo (puedes randomizar si deseas más seguridad)

                ICryptoTransform encryptor = aes.CreateEncryptor();
                byte[] inputBuffer = Encoding.UTF8.GetBytes(texto);
                byte[] output = encryptor.TransformFinalBlock(inputBuffer, 0, inputBuffer.Length);
                return Convert.ToBase64String(output);
            }
        }


        private string Desencriptar(string textoEncriptado)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(claveSecreta);
                aes.IV = new byte[16];
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                byte[] inputBuffer = Convert.FromBase64String(textoEncriptado);
                byte[] output = decryptor.TransformFinalBlock(inputBuffer, 0, inputBuffer.Length);
                return Encoding.UTF8.GetString(output);
            }
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Lanzar dos ventanas automáticamente
            Thread t1 = new Thread(() => Application.Run(new Form1()));
            Thread t2 = new Thread(() => Application.Run(new Form1()));
            t1.SetApartmentState(ApartmentState.STA);
            t2.SetApartmentState(ApartmentState.STA);
            t1.Start();
            t2.Start();
        }
    }
}
