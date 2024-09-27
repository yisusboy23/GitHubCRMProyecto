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

namespace VISTAS.AuditoriaVISTAS
{
    public partial class AuditoriaInterfaz : Form
    {
        public AuditoriaInterfaz()
        {
            InitializeComponent();
        }
        AuditoriaBSS auditoriaBss = new AuditoriaBSS();
        private void AuditoriaInterfaz_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = auditoriaBss.ListarAuditoriaBSS();
        }
    }
}
