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

namespace VISTAS.InicioSesionInterfazVISTAS
{
    public partial class InicioSesionInterfaz : Form
    {
        public InicioSesionInterfaz()
        {
            InitializeComponent();
        }
        UsuarioBSS bss = new UsuarioBSS();
        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            // Lógica de autenticación
            Usuarios usuario = bss.ObtenerCredencialesBss(username, password);
            if (usuario != null)
            {
                // Guardamos el IdUsuario y UserName en la clase Sesion
                Sesion.IdUsuarioSeleccionado = usuario.IdUsuario;
                Sesion.NombreUsuario = usuario.UserName;

                MessageBox.Show("Inicio de sesión exitoso");
                MenuForm menu = new MenuForm();
                menu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas");
            }
        }
    }
}
