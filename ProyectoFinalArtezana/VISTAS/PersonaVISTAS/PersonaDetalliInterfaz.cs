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

namespace VISTAS.PersonaVISTAS
{
    public partial class PersonaDetalliInterfaz : Form
    {
        int idPersona;
        PersonaBSS Bss = new PersonaBSS();
        public PersonaDetalliInterfaz(int idPersona)
        {
            InitializeComponent();
            this.idPersona = idPersona;
        }

        private void PersonaDetalliInterfaz_Load(object sender, EventArgs e)
        {
            // Cargar permisos asociados al rol
            dataGridView1.DataSource = Bss.ObtenerCuentasPorPersonaBss(idPersona);
        }
    }
}
