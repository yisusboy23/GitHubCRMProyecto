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

namespace VISTAS.ReportesVISTAS
{
    public partial class ReportesClientesInterfaz : Form
    {
        public ReportesClientesInterfaz()
        {
            InitializeComponent();
        }
        PersonaBSS clientesBss = new PersonaBSS(); // BSS para clientes
        private void button1_Click(object sender, EventArgs e)
        {
            DateTime? fechaInicio = checkBox1.Checked ? (DateTime?)null : dateTimePicker1.Value.Date;
            DateTime? fechaFin = checkBox1.Checked ? (DateTime?)null : dateTimePicker2.Value.Date;

            // Validar si fechaFin es mayor que fechaInicio solo si el CheckBox no está marcado
            if (!checkBox1.Checked && fechaFin < fechaInicio)
            {
                MessageBox.Show("La fecha de fin debe ser mayor o igual que la fecha de inicio.");
                return;
            }

            DataTable resultados = clientesBss.ObtenerTopClientes(fechaInicio, fechaFin);
            dataGridView1.DataSource = resultados;
        }

        private void ReportesClientesInterfaz_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Si el checkbox está marcado, deshabilitar los DateTimePickers
            bool sinFechas = checkBox1.Checked;
            dateTimePicker1.Enabled = !sinFechas;
            dateTimePicker2.Enabled = !sinFechas;
        }
    }
}
