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

namespace VISTAS.UsuariosVISTAS
{
    public partial class UsuarioListar : Form
    {
        UsuarioBSS bss = new UsuarioBSS();
        public UsuarioListar()
        {
            InitializeComponent();
        }

        private void UsuarioListar_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bss.ListarUsuariosBss();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UsuariosRolVISTAS.UsuarioRolInterfaz.IdUsuarioSeleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            AuditoriaVISTAS.FiltroAuditoriaInterfaz.IdUsuarioSeleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
