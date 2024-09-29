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
using VISTAS.KitVISTAS;

namespace VISTAS.DetalleCarritoKitVISTAS
{
    public partial class DetalleCarritoKitInterfaz : Form
    {
        KitBSS bssKit = new KitBSS();
        DetalleCarritoKitBSS bssCarrito = new DetalleCarritoKitBSS();
        CarritoBSS bssCarro = new CarritoBSS();
        ClienteBSS bssCliente = new ClienteBSS();
        public static int IdClienteSeleccionado = 0;
        public DetalleCarritoKitInterfaz()
        {
            InitializeComponent();
        }

        private void DetalleCarritoKitInterfaz_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bssKit.ListarKitsBss();
            bssCarro.InsertarCarritoBss();
            numericUpDown1.Value = 1;
            numericUpDown1.Minimum = 1;
        }
        private List<DetalleCarritoProducto> detallesCarrito = new List<DetalleCarritoProducto>();

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int idCarrito = bssCarro.ObtenerUltimoCarritoBss();
                // Obtener el producto seleccionado
                int idProducto = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id_Kit"].Value);
                string nombreProducto = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                decimal precioUnitario = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["Precio"].Value);

                // Obtener la cantidad desde el NumericUpDown
                int cantidad = (int)numericUpDown1.Value;

                // Crear una nueva entrada para el detalle del carrito
                DetalleCarritoProducto detalle = new DetalleCarritoProducto
                {
                    IdCarrito = idCarrito,
                    IdProducto = idProducto,
                    Cantidad = cantidad, // Usar la cantidad seleccionada
                    PrecioUnitario = precioUnitario,
                    Fecha = DateTime.Now
                };

                // Añadir el detalle al carrito
                detallesCarrito.Add(detalle); // Asegúrate de que estás añadiendo a la lista
                CalcularTotal();

                // Actualizar dataGridView2
                dataGridView2.DataSource = null; // Limpiar el origen de datos
                dataGridView2.DataSource = detallesCarrito; // Asignar la lista directamente
            }
        }



        private void CalcularTotal()
        {
            decimal total = 0;
            foreach (var detalle in detallesCarrito)
            {
                total += detalle.Cantidad * detalle.PrecioUnitario;
            }

            // Asignar el total al TextBox
            textBox3.Text = total.ToString("F2"); // Formato con 2 decimales
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow != null)
            {
                // Obtener el detalle seleccionado
                DetalleCarritoProducto detalleSeleccionado = (DetalleCarritoProducto)dataGridView2.CurrentRow.DataBoundItem;

                // Actualizar la cantidad
                detalleSeleccionado.Cantidad = (int)numericUpDown1.Value;

                // Actualizar dataGridView2
                dataGridView2.DataSource = null; // Limpiar el origen de datos
                dataGridView2.DataSource = detallesCarrito; // Asignar la lista actualizada
                CalcularTotal();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Verifica si hay una fila seleccionada en dataGridView2
            if (dataGridView2.CurrentRow != null)
            {
                // Obtener el detalle seleccionado (puedes usar IdDetalleCarritoP o alguna otra propiedad única)
                DetalleCarritoProducto detalleSeleccionado = (DetalleCarritoProducto)dataGridView2.CurrentRow.DataBoundItem;

                // Eliminar el detalle de la lista
                detallesCarrito.Remove(detalleSeleccionado);

                // Actualizar dataGridView2
                dataGridView2.DataSource = null; // Limpiar el origen de datos
                dataGridView2.DataSource = detallesCarrito; // Asignar la lista actualizada
                CalcularTotal();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un producto para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.CurrentRow != null)
            {
                // Obtener el detalle seleccionado
                DetalleCarritoProducto detalleSeleccionado = (DetalleCarritoProducto)dataGridView2.CurrentRow.DataBoundItem;

                // Establecer la cantidad en el NumericUpDown
                numericUpDown1.Value = detalleSeleccionado.Cantidad;
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            // Obtener el último carrito creado (que se crea automáticamente al iniciar)
            int idCarrito = bssCarro.ObtenerUltimoCarritoBss();

            // Calcular el precio total sumando el precio de cada detalle del carrito
            decimal precioTotal = detallesCarrito.Sum(detalle => detalle.Cantidad * detalle.PrecioUnitario);

            // Cambiar el estado del carrito a "Pendiente"
            string estado = "Pendiente";

            // Actualizar el carrito con el cliente seleccionado, el precio total y el estado
            Carrito carritoActualizado = bssCarro.ObtenerCarritoPorIdBss(idCarrito);

            // Usar el cliente que se inició sesión
            carritoActualizado.IdCliente = Sesion.IdClienteSeleccionado;
            carritoActualizado.PrecioTotal = precioTotal;
            carritoActualizado.Estado = estado;

            // Actualizar el carrito en la base de datos
            bssCarro.EditarCarritoBss(carritoActualizado);

            // Insertar los detalles del carrito (kits seleccionados) en la tabla DetalleCarritoKit
            List<string> nombresKits = new List<string>(); // Lista para almacenar nombres de kits
            foreach (var detalle in detallesCarrito)
            {
                DetalleCarritoKit nuevoDetalle = new DetalleCarritoKit
                {
                    IdCarrito = idCarrito,
                    IdKitProducto = detalle.IdProducto, // Asegúrate de que IdProducto corresponde a un kit
                    Cantidad = detalle.Cantidad,
                    PrecioUnitario = detalle.PrecioUnitario,
                    Fecha = DateTime.Now
                };

                // Insertar cada detalle en la base de datos
                bssCarrito.InsertarDetalleCarritoKitBss(nuevoDetalle);

                // Agregar el nombre del kit a la lista
                string nombreKit = bssKit.ObtenerNombreKitPorId(detalle.IdProducto); // Obtener el nombre del kit
                nombresKits.Add(nombreKit);
            }

            // Registrar la auditoría
            string username = Sesion.NombreCliente; // Obtén el nombre de usuario desde la sesión
            string kitsComprados = string.Join(", ", nombresKits); // Unir los nombres en una sola cadena
            string accion = $"{username} realizó una compra de kits: {kitsComprados}."; // Mensaje de acción

            AuditoriaClieBSS auditoriaBss = new AuditoriaClieBSS();
            auditoriaBss.RegistrarAuditoria(Sesion.IdClienteSeleccionado, accion); // Registrar auditoría

            // Mostrar mensaje de éxito
            MessageBox.Show("Compra de kits realizada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Limpiar la lista de detalles y actualizar la interfaz
            detallesCarrito.Clear();
            dataGridView2.DataSource = null;
            textBox3.Text = "0.00";  // Reiniciar el total a 0
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Verifica que se haya seleccionado un rol en el DataGridView
            if (dataGridView1.CurrentRow != null)
            {
                // Obtiene el ID del rol seleccionado
                int idRolSeleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id_Kit"].Value);

                // Crea una nueva instancia de RolDetalleInterfaz pasando el ID del rol
                KitDetalleInterfaz detalleForm = new KitDetalleInterfaz(idRolSeleccionado);

                // Muestra el formulario como un diálogo
                detalleForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un Kit para ver los detalles.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string nombreKit = textBox5.Text.Trim();

            if (!string.IsNullOrEmpty(nombreKit))
            {
                DataTable resultados = bssKit.BuscarKitsPorNombre(nombreKit);
                dataGridView1.DataSource = resultados;
            }
            else
            {
                MessageBox.Show("Por favor ingrese un nombre para la búsqueda.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bssKit.ListarKitsBss();
        }
    }
}
