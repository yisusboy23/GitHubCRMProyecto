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

namespace VISTAS.AuditoriaClieVISTAS
{
    public partial class AuditoriaClieInterfaz : Form
    {
        public AuditoriaClieInterfaz()
        {
            InitializeComponent();
        }
        AuditoriaClieBSS auditoriaBss = new AuditoriaClieBSS();
        private void AuditoriaClieInterfaz_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = auditoriaBss.ListarAuditoriaClieBSS();
        }
    }
}
