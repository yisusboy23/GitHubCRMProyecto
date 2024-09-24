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
using VISTAS.ClienteVISTAS;
using VISTAS.InicioSesionInterfazVISTAS;
using VISTAS.PermisoVISTAS;
using VISTAS.RolPermisoVISTAS;
using VISTAS.RolVISTAS;
using VISTAS.UsuariosRolVISTAS;
using VISTAS.UsuariosVISTAS;

namespace VISTAS.MenuAdministradorVISTAS
{
    public partial class MenuAdministradorInterfaz : Form
    {
        public MenuAdministradorInterfaz()
        {
            InitializeComponent();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

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
        private void MenuAdministradorInterfaz_Load(object sender, EventArgs e)
        {
            pictureBox2_Click(null, e);
            label1.Text = "Bienvenido, " + Sesion.NombreUsuario;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new MenuGerente());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new PersonaInterfaz());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new UsuariosInterfaz());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new ClientesInterfaz());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new RolInterfaz());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new UsuarioRolInterfaz());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new PermisoInterfaz());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new RolPermisoInterfaz());
        }

        private void button15_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Esta seguro que desea cerrar la sesion?", "CERRAR SESION", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                InicioSesionInterfaz abrir = new InicioSesionInterfaz();
                abrir.Show();
                this.Hide();
            }
        }
    }
}
