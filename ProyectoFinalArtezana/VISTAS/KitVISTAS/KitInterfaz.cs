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
    public partial class KitInterfaz : Form
    {
        KitBSS bss = new KitBSS();
        public KitInterfaz()
        {
            InitializeComponent();
        }

        private void KitInterfaz_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bss.ListarKitsBss();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["Precio"].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells["Cantidad"].Value.ToString();
            comboBox1.SelectedItem = dataGridView1.CurrentRow.Cells["Estado"].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Kit kit = new Kit
            {
                Nombre = textBox1.Text,
                Descripcion = textBox2.Text,
                Precio = decimal.Parse(textBox3.Text),
                Cantidad = int.Parse(textBox4.Text),
                Estado = comboBox1.SelectedItem.ToString(),
                Fecha = DateTime.Now
            };

            bss.InsertarKitBss(kit);
            MessageBox.Show("Kit guardado correctamente.");
            dataGridView1.DataSource = bss.ListarKitsBss();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int idKitSeleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            Kit kit = bss.ObtenerKitPorIdBss(idKitSeleccionado);
            kit.Nombre = textBox1.Text;
            kit.Descripcion = textBox2.Text;
            kit.Precio = decimal.Parse(textBox3.Text);
            kit.Cantidad = int.Parse(textBox4.Text);
            kit.Estado = comboBox1.SelectedItem.ToString();

            bss.EditarKitBss(kit);
            MessageBox.Show("Kit actualizado.");
            dataGridView1.DataSource = bss.ListarKitsBss();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Obtener el ID del kit seleccionado
            int idKitSeleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);

            // Mostrar un cuadro de diálogo de confirmación
            DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar este kit?", "ELIMINAR", MessageBoxButtons.YesNo);

            // Si el usuario confirma la eliminación
            if (result == DialogResult.Yes)
            {
                bss.EliminarKitBss(idKitSeleccionado);
                MessageBox.Show("Kit eliminado.");
                dataGridView1.DataSource = bss.ListarKitsBss();
            }
        }
    }
}
