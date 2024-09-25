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

namespace VISTAS.KitProductoVISTAS
{
    public partial class KitProductoInterfaz : Form
    {
        KitProductoBSS bss = new KitProductoBSS();
        KitBSS kitBss = new KitBSS(); // Para obtener la lista de kits
        ProductoBSS productoBss = new ProductoBSS();
        public static int IdProductoSeleccionado = 0;
        public static int IdKitSeleccionado = 0;
        AuditoriaBSS auditoriaBss = new AuditoriaBSS(); // Instancia para manejar la auditoría
        public KitProductoInterfaz()
        {
            InitializeComponent();
        }

        private void KitProductoInterfaz_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bss.ListarKitProductosBss();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
            }
            else
            {
                KitProducto kp = new KitProducto
                {
                    IdProducto = IdProductoSeleccionado,
                    IdKit = IdKitSeleccionado,
                    Cantidad = int.Parse(textBox3.Text),
                    Fecha = DateTime.Now
                };

                bss.InsertarKitProductoBss(kp);
                MessageBox.Show("Kit-Producto guardado correctamente.");

                // Registrar auditoría
                string accion = $"Gerende de tienda: KitProducto creado: IdKit={kp.IdKit}, IdProducto={kp.IdProducto}, Cantidad={kp.Cantidad}";
                auditoriaBss.RegistrarAuditoria(Sesion.IdUsuarioSeleccionado, accion);

                dataGridView1.DataSource = bss.ListarKitProductosBss();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
       string.IsNullOrWhiteSpace(textBox2.Text) ||
       string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
            }
            else
            {
                // Obtener el ID del KitProducto seleccionado desde el DataGridView
                int idKitProductoSeleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id_KitProducto"].Value);

                // Obtener el KitProducto a editar
                KitProducto editarKitProducto = bss.ObtenerKitProductoPorIdBss(idKitProductoSeleccionado);

                // Actualizar las propiedades del KitProducto
                editarKitProducto.IdProducto = IdProductoSeleccionado;
                editarKitProducto.IdKit = IdKitSeleccionado;
                editarKitProducto.Cantidad = int.Parse(textBox3.Text);
                editarKitProducto.Fecha = DateTime.Now;

                // Guardar los cambios
                bss.EditarKitProductoBss(editarKitProducto);
                MessageBox.Show("KitProducto actualizado correctamente.");

                // Actualizar el DataGridView con los nuevos datos
                dataGridView1.DataSource = bss.ListarKitProductosBss();

                // Registrar auditoría
                string accion = $"Gerende de tienda: KitProducto actualizado: IdKitProducto={idKitProductoSeleccionado}, IdKit={editarKitProducto.IdKit}, IdProducto={editarKitProducto.IdProducto}, Cantidad={editarKitProducto.Cantidad}";
                auditoriaBss.RegistrarAuditoria(Sesion.IdUsuarioSeleccionado, accion);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int idKitProductoSeleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id_KitProducto"].Value);
            DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar este Kit-Producto?", "ELIMINAR", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                KitProducto kp = bss.ObtenerKitProductoPorIdBss(idKitProductoSeleccionado); // Obtener el KitProducto para auditoría
                bss.EliminarKitProductoBss(idKitProductoSeleccionado);
                MessageBox.Show("KitProducto eliminado.");
                dataGridView1.DataSource = bss.ListarKitProductosBss();

                // Registrar auditoría
                string accion = $"Gerende de tienda: KitProducto eliminado: IdKitProducto={idKitProductoSeleccionado}, IdKit={kp.IdKit}, IdProducto={kp.IdProducto}, Cantidad={kp.Cantidad}";
                auditoriaBss.RegistrarAuditoria(Sesion.IdUsuarioSeleccionado, accion);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            KitVISTAS.KitListar kitForm = new KitVISTAS.KitListar();
            if (kitForm.ShowDialog() == DialogResult.OK)
            {
                Kit k = kitBss.ObtenerKitPorIdBss(IdKitSeleccionado);
                textBox1.Text = k.Nombre;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ProductoVISTAS.ProductoListar productoForm = new ProductoVISTAS.ProductoListar();
            if (productoForm.ShowDialog() == DialogResult.OK)
            {
                Producto p = productoBss.ObtenerProductoPorIdBss(IdProductoSeleccionado);
                textBox2.Text = p.Nombre;
            }
        }
    }
}
