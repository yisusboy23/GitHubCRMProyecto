using BSS;
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

namespace VISTAS.KitVISTAS
{
    public partial class KitDetalleInterfaz : Form
    {
        int idKit;
        KitBSS Bss = new KitBSS();
        public KitDetalleInterfaz(int idKit)
        {
            InitializeComponent();
            this.idKit = idKit;
        }

        private void KitDetalleInterfaz_Load(object sender, EventArgs e)
        {
            // Cargar permisos asociados al rol
            dataGridView1.DataSource = Bss.ObtenerDetallesKitBSS(idKit);
        }
    }
}
