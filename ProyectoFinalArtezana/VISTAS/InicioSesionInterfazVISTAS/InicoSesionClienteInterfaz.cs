using BSS;
using MODELOS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VISTAS.MenuClienteVISTAS;

namespace VISTAS.InicioSesionInterfazVISTAS
{
    public partial class InicoSesionClienteInterfaz : Form
    {
        public InicoSesionClienteInterfaz()
        {
            InitializeComponent();
        }
        private static int intentosFallidos = 0; // Conteo de intentos fallidos
        private static DateTime proximoIntento = DateTime.Now;

        ClienteBSS bss = new ClienteBSS();
        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            // Verificar si el cliente está temporalmente bloqueado por intentos fallidos
            if (intentosFallidos >= 3 && DateTime.Now < proximoIntento)
            {
                TimeSpan tiempoRestante = proximoIntento - DateTime.Now;
                MessageBox.Show($"La cuenta está temporalmente bloqueada. Inténtelo de nuevo en {tiempoRestante.Seconds} segundos.");
                return; // Detenemos el flujo si está en bloqueo
            }

            // Lógica de autenticación para Cliente
            Cliente cliente = bss.ObtenerCredencialesBss(username, password);
            if (cliente != null)
            {
                // Verificar si el cliente está bloqueado permanentemente
                if (cliente.Bloqueado)
                {
                    MessageBox.Show("La cuenta está bloqueada. Por favor, contacte al administrador.");
                    return; // Detenemos el flujo si está bloqueado
                }

                // Si la autenticación es exitosa, restablecemos el contador de intentos fallidos
                intentosFallidos = 0;
                proximoIntento = DateTime.Now;

                // Guardamos el IdCliente y UserName en la clase Sesion
                Sesion.IdClienteSeleccionado = cliente.IdCliente;
                Sesion.NombreCliente = cliente.UserName;

                MessageBox.Show("Inicio de sesión exitoso");
                MenuClienteInterfaz menu = new MenuClienteInterfaz(); // Cambia a tu interfaz correspondiente
                menu.Show();
                this.Hide();
            }
            else
            {
                // Incrementamos el número de intentos fallidos
                intentosFallidos++;

                // Si el número de intentos fallidos es 3 o más, aplicamos el bloqueo temporal
                if (intentosFallidos >= 3)
                {
                    int tiempoEspera = (intentosFallidos - 2) * 20; // Aumenta 20 segundos con cada intento adicional
                    MessageBox.Show($"Ha fallado {intentosFallidos} veces. Espere {tiempoEspera} segundos antes de volver a intentarlo.");
                    proximoIntento = DateTime.Now.AddSeconds(tiempoEspera); // Ajustamos el tiempo de bloqueo
                }
                else
                {
                    MessageBox.Show($"Credenciales incorrectas. Intento {intentosFallidos} de 3.");
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            CrearCliente menu = new CrearCliente();
            menu.Show();
            this.Hide();
        }
    }
}
