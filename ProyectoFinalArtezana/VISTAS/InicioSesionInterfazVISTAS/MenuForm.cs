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
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            // Mostrar el nombre del usuario logueado en un solo Label
            label1.Text = "Bienvenido, " + Sesion.NombreUsuario;
        }
    }
}
