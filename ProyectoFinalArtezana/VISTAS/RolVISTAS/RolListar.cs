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

namespace VISTAS.RolVISTAS
{
    public partial class RolListar : Form
    {
        RolBSS bss = new RolBSS();
        public RolListar()
        {
            InitializeComponent();
        }
        private void RolListar_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bss.ListarRolesBss();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UsuariosRolVISTAS.UsuarioRolInterfaz.IdRolSeleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            RolPermisoVISTAS.RolPermisoInterfaz.IdRolSeleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
        }
    }
}
