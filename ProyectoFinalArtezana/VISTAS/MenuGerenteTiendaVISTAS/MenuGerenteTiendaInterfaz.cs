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
using VISTAS.AuditoriaClieVISTAS;
using VISTAS.ProductoVISTAS;

namespace VISTAS.MenuGerenteTiendaVISTAS
{
    public partial class MenuGerenteTiendaInterfaz : Form
    {
        public MenuGerenteTiendaInterfaz()
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

        private void MenuGerenteTiendaInterfaz_Load(object sender, EventArgs e)
        {
            pictureBox2_Click(null, e);
            label1.Text = "Bienvenido, " + Sesion.NombreUsuario;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new MenuGerente2());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new ProductoInterfaz());
        }
    }
}
