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
    public partial class EditarCuenta : Form
    {
        public EditarCuenta()
        {
            InitializeComponent();
        }

        ClienteBSS clienteBss = new ClienteBSS();
        private void EditarCuenta_Load(object sender, EventArgs e)
        {

            // Mostrar el nombre del cliente almacenado en la sesión
            label4.Text = "Bienvenido, " + Sesion.NombreCliente;

            // Si necesitas mostrar más detalles, puedes cargarlos aquí
            Cliente cliente = clienteBss.ObtenerClientePorIdBss(Sesion.IdClienteSeleccionado);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nuevaContraseña = textBox1.Text;
            string confirmarContraseña = textBox2.Text;

            if (nuevaContraseña != confirmarContraseña)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Cambiar la contraseña
                clienteBss.CambiarContraseñaBss(Sesion.IdClienteSeleccionado, nuevaContraseña);
                MessageBox.Show("Contraseña cambiada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
