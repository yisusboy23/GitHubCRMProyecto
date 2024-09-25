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

namespace VISTAS.CarritoVISTAS
{
    public partial class CarritoInterfaz : Form
    {
        CarritoBSS bss = new CarritoBSS();
        public CarritoInterfaz()
        {
            InitializeComponent();
        }

        private void CarritoInterfaz_Load(object sender, EventArgs e)
        {
            // Llenar DataGridView con carritos pendientes
            DataTable carritoPendiente = bss.ListarCarritoPendienteBss(Sesion.IdClienteSeleccionado);
            dataGridView2.DataSource = carritoPendiente;

            // Llenar DataGridView con carritos completados o cancelados
            DataTable carritoCompletado = bss.ListarCarritoCompletadoBss(Sesion.IdClienteSeleccionado);
            dataGridView1.DataSource = carritoCompletado;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Asegúrate de que se ha seleccionado una fila en el DataGridView
            if (dataGridView2.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona un carrito para cancelar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener el Id del carrito seleccionado
            int idCarritoSeleccionado = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["Id_Carrito"].Value);

            // Preguntar al usuario si realmente quiere cancelar el pedido
            DialogResult dialogResult = MessageBox.Show("¿Quieres cancelar el pedido?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                // Llamar al método para cancelar el carrito
                bss.CancelarCarritoBss(idCarritoSeleccionado);

                // Registrar la auditoría
                string username = Sesion.NombreCliente; // Obtén el nombre de usuario desde la sesión
                string accion = $"{username} canceló el carrito con ID: {idCarritoSeleccionado}."; // Mensaje de acción

                AuditoriaClieBSS auditoriaBss = new AuditoriaClieBSS();
                auditoriaBss.RegistrarAuditoria(Sesion.IdClienteSeleccionado, accion); // Registrar auditoría

                // Refrescar el DataGridView para mostrar los cambios
                DataTable carritoPendiente = bss.ListarCarritoPendienteBss(Sesion.IdClienteSeleccionado);
                dataGridView2.DataSource = carritoPendiente;

                // También actualizar el DataGridView de carritos completados
                DataTable carritoCompletado = bss.ListarCarritoCompletadoBss(Sesion.IdClienteSeleccionado);
                dataGridView1.DataSource = carritoCompletado;

                MessageBox.Show("El carrito ha sido cancelado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
