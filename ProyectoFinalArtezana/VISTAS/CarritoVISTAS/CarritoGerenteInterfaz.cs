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
using VISTAS.PersonaVISTAS;
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
        PermisoBSS permisosBss = new PermisoBSS(); // Instancia de PermisosDAL
        private void CarritoGerenteInterfaz_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bss.ListarCarritoBss();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Verificar permiso para insertar
            if (permisosBss.VerificarPermisoBloqueoBss("Cambiar Estado Venta"))
            {
                MessageBox.Show("El permiso bloqueado.");
                return;
            }

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

        private void button5_Click(object sender, EventArgs e)
        {

            // Verifica que se haya seleccionado un rol en el DataGridView
            if (dataGridView1.CurrentRow != null)
            {
                // Obtiene el ID del rol seleccionado
                int idRolSeleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id_Carrito"].Value);

                // Crea una nueva instancia de RolDetalleInterfaz pasando el ID del rol
                CarritoDetalleInterfaz detalleForm = new CarritoDetalleInterfaz(idRolSeleccionado);

                // Muestra el formulario como un diálogo
                detalleForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un rol para ver los detalles.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
