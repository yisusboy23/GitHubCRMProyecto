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

namespace VISTAS.PersonaVISTAS
{
    public partial class PersonaListar : Form
    {
        public PersonaListar()
        {
            InitializeComponent();
        }
        PersonaBSS bss = new PersonaBSS();
        private void PersonaListar_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bss.ListarPersonasBss();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UsuariosInterfaz.IdPersonaSeleccionada = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
