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
    public partial class Menu3 : Form
    {
        public Menu3()
        {
            InitializeComponent();
        }

        private void Menu3_Load(object sender, EventArgs e)
        {
            label1.Text = "Bienvenido, " + Sesion.NombreCliente;
        }
    }
}
