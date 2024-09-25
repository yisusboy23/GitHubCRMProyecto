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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VISTAS.CarritoVISTAS
{
    public partial class CarritoGerenteInterfaz : Form
    {
        public CarritoGerenteInterfaz()
        {
            InitializeComponent();
        }
        CarritoBSS bss = new CarritoBSS();
        private void CarritoGerenteInterfaz_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bss.ListarCarritoBss();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int idProductoSeleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            Carrito carrito = bss.ObtenerCarritoPorIdBss(idProductoSeleccionado);

            carrito.Estado = comboBox1.SelectedItem.ToString();

            bss.EditarCarritoBss(carrito);
            MessageBox.Show("Producto actualizado.");
            dataGridView1.DataSource = bss.ListarCarritoBss();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = dataGridView1.CurrentRow.Cells["Estado"].Value.ToString();
        }
    }
}
