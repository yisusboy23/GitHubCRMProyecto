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

namespace VISTAS.ProductoVISTAS
{
    public partial class ProductoInterfaz : Form
    {
        public ProductoInterfaz()
        {
            InitializeComponent();
        }
        ProductoBSS bss = new ProductoBSS();
        AuditoriaBSS auditoriaBss = new AuditoriaBSS(); // Instancia de BSS para auditoría

        private void ProductoInterfaz_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bss.ListarProductosBss();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto
            {
                Nombre = textBox1.Text,
                Descripcion = textBox2.Text,
                Precio = decimal.Parse(textBox3.Text),
                Cantidad = int.Parse(textBox4.Text),
                Estado = comboBox1.SelectedItem.ToString(),
                Fecha = DateTime.Now
            };

            bss.InsertarProductoBss(producto);
            MessageBox.Show("Producto guardado correctamente.");
           
            dataGridView1.DataSource = bss.ListarProductosBss();

            // Registrar auditoría
            string accion = $"Producto creado: Nombre={producto.Nombre}, Descripción={producto.Descripcion}, Precio={producto.Precio}, Cantidad={producto.Cantidad}, Estado={producto.Estado}";
            auditoriaBss.RegistrarAuditoria(Sesion.IdUsuarioSeleccionado, accion);

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
            int idProductoSeleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            Producto producto = bss.ObtenerProductoPorIdBss(idProductoSeleccionado);
            producto.Nombre = textBox1.Text;
            producto.Descripcion = textBox2.Text;
            producto.Precio = decimal.Parse(textBox3.Text);
            producto.Cantidad = int.Parse(textBox4.Text);
            producto.Estado = comboBox1.SelectedItem.ToString();

            bss.EditarProductoBss(producto);
            MessageBox.Show("Producto actualizado.");
            string accion = $"Producto actualizado: Id={idProductoSeleccionado}, Nombre={producto.Nombre}, Descripción={producto.Descripcion}, Precio={producto.Precio}, Cantidad={producto.Cantidad}, Estado={producto.Estado}";
            auditoriaBss.RegistrarAuditoria(Sesion.IdUsuarioSeleccionado, accion);

            dataGridView1.DataSource = bss.ListarProductosBss();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Obtener el ID del producto seleccionado
            int idProductoSeleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);

            // Mostrar un cuadro de diálogo de confirmación
            DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar este producto?", "ELIMINAR", MessageBoxButtons.YesNo);

            // Si el usuario confirma la eliminación
            if (result == DialogResult.Yes)
            {
                Producto producto = bss.ObtenerProductoPorIdBss(idProductoSeleccionado); // Obtener el producto para la auditoría
                bss.EliminarProductoBss(idProductoSeleccionado);
                MessageBox.Show("Producto eliminado.");

                string accion = $"Producto eliminado: Id={idProductoSeleccionado}, Nombre={producto.Nombre}, Descripción={producto.Descripcion}, Precio={producto.Precio}, Cantidad={producto.Cantidad}, Estado={producto.Estado}";
                auditoriaBss.RegistrarAuditoria(Sesion.IdUsuarioSeleccionado, accion);

                dataGridView1.DataSource = bss.ListarProductosBss();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["Precio"].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells["Cantidad"].Value.ToString();
            comboBox1.SelectedItem = dataGridView1.CurrentRow.Cells["Estado"].Value.ToString();
        }
    }
}
