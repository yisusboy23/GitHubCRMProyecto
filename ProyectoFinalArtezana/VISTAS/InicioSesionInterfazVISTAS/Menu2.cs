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
    public partial class Menu2 : Form
    {
        public Menu2()
        {
            InitializeComponent();
        }

        private void Menu2_Load(object sender, EventArgs e)
        {
            label1.Text = "Bienvenido, " + Sesion.NombreUsuario;
        }
    }
}
