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
using VISTAS.MenuAdministradorVISTAS;

namespace VISTAS.InicioSesionInterfazVISTAS
{
    public partial class InicioSesionInterfaz : Form
    {
        public InicioSesionInterfaz()
        {
            InitializeComponent();
        }
        private static int intentosFallidos = 0; // Conteo de intentos fallidos
        private static DateTime proximoIntento = DateTime.Now;
        UsuarioBSS bss = new UsuarioBSS();
        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            // Verificar si está en tiempo de espera por intentos fallidos
            if (intentosFallidos >= 3 && DateTime.Now < proximoIntento)
            {
                TimeSpan tiempoRestante = proximoIntento - DateTime.Now;
                MessageBox.Show($"La cuenta está temporalmente bloqueada. Inténtelo de nuevo en {tiempoRestante.Seconds} segundos.");
                return;
            }

            // Lógica de autenticación
            Usuarios usuario = bss.ObtenerCredencialesBss(username, password);

            if (usuario != null)
            {
                // Verificar si el rol está bloqueado
                if (usuario.RolBloqueado)
                {
                    MessageBox.Show("El rol asignado a esta cuenta está bloqueado. Por favor, contacte al administrador.");
                    return;
                }

                // Verificar si la relación UsuarioRol está bloqueada
                if (usuario.UsuarioRolBloqueado)
                {
                    TimeSpan tiempoRestante = proximoIntento - DateTime.Now;
                    MessageBox.Show($"La cuenta está temporalmente bloqueada. Por favor, contacte al administrador.");
                    return;
                }

                if (usuario.Bloqueado)
                {
                    MessageBox.Show("La cuenta de usuario está bloqueada. Por favor, contacte al administrador.");
                    return; // Detenemos el flujo si el usuario está bloqueado
                }

                // Restablecer los intentos fallidos y el tiempo de bloqueo
                intentosFallidos = 0;
                proximoIntento = DateTime.Now; // El tiempo de bloqueo se restablece

                // Guardamos el IdUsuario y UserName en la clase Sesion
                Sesion.IdUsuarioSeleccionado = usuario.IdUsuario;
                Sesion.NombreUsuario = usuario.UserName;

                MessageBox.Show("Inicio de sesión exitoso");

                // Redirigir según el rol
                if (usuario.IdRol == 1) // ID rol 1
                {
                    MenuAdministradorInterfaz menu = new MenuAdministradorInterfaz();
                    menu.Show();
                }
                else if (usuario.IdRol == 2) // ID rol 2
                {
                    Menu2 otraInterfaz = new Menu2(); // Cambia a tu interfaz correspondiente
                    otraInterfaz.Show();
                }

                this.Hide();
            }
            else
            {
                // Incrementar el conteo de intentos fallidos solo si las credenciales son incorrectas
                intentosFallidos++;

                // Definir tiempos de bloqueo basados en el número de intentos
                if (intentosFallidos >= 3)
                {
                    int tiempoEspera = (intentosFallidos - 2) * 20; // Aumenta 20 segundos por cada ciclo
                    MessageBox.Show($"Ha fallado {intentosFallidos} veces. Espere {tiempoEspera} segundos antes de volver a intentarlo.");
                    proximoIntento = DateTime.Now.AddSeconds(tiempoEspera);
                }
                else
                {
                    MessageBox.Show($"Credenciales incorrectas. Intento {intentosFallidos} de 3.");
                }
            }
        }
    }
}
