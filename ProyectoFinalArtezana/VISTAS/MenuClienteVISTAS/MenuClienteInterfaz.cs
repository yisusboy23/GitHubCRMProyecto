using MODELOS;
using SistemasVentas.VISTA.InterfazGerenteVista;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VISTAS.CarritoVISTAS;
using VISTAS.DetalleCarritoKitVISTAS;
using VISTAS.DetalleCarritoProductoVISTAS;
using VISTAS.InicioSesionInterfazVISTAS;

namespace VISTAS.MenuClienteVISTAS
{
    public partial class MenuClienteInterfaz : Form
    {
        public MenuClienteInterfaz()
        {
            InitializeComponent();
        }
        private void AbrirFormHija(Object FormHija)
        {
            if (this.panel3.Controls.Count > 0)
                this.panel3.Controls.RemoveAt(0);
            Form fh = FormHija as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panel3.Controls.Add(fh);
            this.panel3.Tag = fh;
            fh.Show();

        }
        private void button6_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new DetalleCarritoProductoInterfaz());
        }

        private void MenuClienteInterfaz_Load(object sender, EventArgs e)
        {
            label2.Text = "Bienvenido, " + Sesion.NombreCliente;
            pictureBox2_Click(null, e);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new MenuCliente());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new DetalleCarritoKitInterfaz());
        }

        private void button15_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Esta seguro que desea cerrar la sesion?", "CERRAR SESION", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                InicoSesionClienteInterfaz abrir = new InicoSesionClienteInterfaz();
                abrir.Show();
                this.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new CarritoInterfaz());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new EditarCuenta());
        }
    }
}
