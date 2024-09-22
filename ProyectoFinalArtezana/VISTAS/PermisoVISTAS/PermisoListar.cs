using BSS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VISTAS.UsuariosVISTAS;

namespace VISTAS.PermisoVISTAS
{
    public partial class PermisoListar : Form
    {
        public PermisoListar()
        {
            InitializeComponent();
        }
        PermisoBSS bss = new PermisoBSS();
        private void PermisoListar_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bss.ListarPermisosBss();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RolPermisoVISTAS.RolPermisoInterfaz.IdPermisoSeleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
