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

namespace VISTAS.ClienteVISTAS
{
    public partial class ClientesInterfaz : Form
    {
        ClienteBSS bss = new ClienteBSS();
        PersonaBSS bssPersona = new PersonaBSS();
        public static int IdPersonaSeleccionada = 0;
        AuditoriaBSS auditoriaBss = new AuditoriaBSS(); // Instancia para manejar la auditoría
        public ClientesInterfaz()
        {
            InitializeComponent();
        }
        private void ClientesInterfaz_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bss.ListarClientesBss();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();  // UserName
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();  // Contraseña
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();  // Contraseña
            bool estaBloqueado = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[4].Value);  // Bloqueado
            checkBox1.Checked = estaBloqueado;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
            }
            else
            {
                Cliente cliente = new Cliente
                {
                    IdPersona = IdPersonaSeleccionada,
                    UserName = textBox2.Text,
                    Contraseña = textBox3.Text,
                    Bloqueado = false, // Puedes cambiar esto según tu lógica
                    FechaBloq = null // O el valor que desees
                };

                bss.InsertarClienteBss(cliente);
                MessageBox.Show("Cliente guardado correctamente.");
                dataGridView1.DataSource = bss.ListarClientesBss();

                // Registrar auditoría de inserción
                string accion = $"Cliente creado: UserName={cliente.UserName}, Bloqueado={cliente.Bloqueado}";
                auditoriaBss.RegistrarAuditoria(Sesion.IdUsuarioSeleccionado, accion);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int idClienteSeleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdCliente"].Value);
            Cliente editarCliente = bss.ObtenerClientePorIdBss(idClienteSeleccionado);
            editarCliente.IdPersona = IdPersonaSeleccionada;
            editarCliente.UserName = textBox2.Text;
            editarCliente.Contraseña = textBox3.Text;
            editarCliente.Bloqueado = checkBox1.Checked;
            editarCliente.FechaBloq = checkBox1.Checked ? (DateTime?)DateTime.Now : null;
            bss.EditarClienteBss(editarCliente);
            MessageBox.Show("Datos actualizados.");
            dataGridView1.DataSource = bss.ListarClientesBss();

            // Registrar auditoría de actualización
            string accion = $"Cliente actualizado: Id={idClienteSeleccionado}, UserName={editarCliente.UserName}, Bloqueado={editarCliente.Bloqueado}";
            auditoriaBss.RegistrarAuditoria(Sesion.IdUsuarioSeleccionado, accion);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int idClienteSeleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdCliente"].Value);
            DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar este cliente?", "Eliminar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    // Registrar auditoría antes de eliminar
                    string accion = $"Cliente eliminado: Id={idClienteSeleccionado}, UserName={dataGridView1.CurrentRow.Cells["UserName"].Value}";
                    auditoriaBss.RegistrarAuditoria(Sesion.IdUsuarioSeleccionado, accion);

                    bss.EliminarClienteBss(idClienteSeleccionado);
                    MessageBox.Show("Cliente eliminado correctamente.");
                    dataGridView1.DataSource = bss.ListarClientesBss();
                }
                catch (InvalidOperationException ex) // Captura la excepción específica
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex) // Captura cualquier otra excepción
                {
                    MessageBox.Show("Error al eliminar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            checkBox1.Checked = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PersonaVISTAS.PersonaListar fr = new PersonaVISTAS.PersonaListar();
            if (fr.ShowDialog() == DialogResult.OK)
            {
                Persona p = bssPersona.ObtenerPersonaIdBss(IdPersonaSeleccionada);
                textBox1.Text = p.Nombre + " " + p.Apellido;
            }
        }
    }
}
