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

namespace VISTAS.KitVISTAS
{
    public partial class KitListar : Form
    {
        public KitListar()
        {
            InitializeComponent();
        }
        KitBSS bss = new KitBSS();
        private void KitListar_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bss.ListarKitsBss();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KitProductoVISTAS.KitProductoInterfaz.IdKitSeleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
