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

namespace VISTAS.RolVISTAS
{
    public partial class RolInterfaz : Form
    {
        RolBSS bss = new RolBSS();
        AuditoriaBSS auditoriaBss = new AuditoriaBSS(); // Instancia para manejar la auditoría

        public RolInterfaz()
        {
            InitializeComponent();
        }

        private void RolInterfaz_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bss.ListarRolesBss();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

            bool estaBloqueado = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[3].Value);
            checkBox1.Checked = estaBloqueado;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            Rol rol = new Rol
            {
                NombreRol = textBox1.Text,
                Descripcion = textBox2.Text,
                Bloqueado = checkBox1.Checked,
                FechaBloq = checkBox1.Checked ? (DateTime?)DateTime.Now : null
            };

            bss.InsertarRolBss(rol);
            MessageBox.Show("Rol agregado correctamente.");

            // Registrar auditoría
            string accion = $"Rol creado: NombreRol={rol.NombreRol}, Descripcion={rol.Descripcion}, Bloqueado={rol.Bloqueado}";
            auditoriaBss.RegistrarAuditoria(Sesion.IdUsuarioSeleccionado, accion);

            dataGridView1.DataSource = bss.ListarRolesBss();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            checkBox1.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            int idRolSeleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdRol"].Value);
            Rol rol = bss.ObtenerRolPorIdBss(idRolSeleccionado);
            rol.NombreRol = textBox1.Text;
            rol.Descripcion = textBox2.Text;
            rol.Bloqueado = checkBox1.Checked;
            rol.FechaBloq = checkBox1.Checked ? (DateTime?)DateTime.Now : null;

            bss.EditarRolBss(rol);
            MessageBox.Show("Datos actualizados correctamente.");

            // Registrar auditoría
            string accion = $"Rol actualizado: Id={idRolSeleccionado}, NombreRol={rol.NombreRol}, Bloqueado={rol.Bloqueado}";
            auditoriaBss.RegistrarAuditoria(Sesion.IdUsuarioSeleccionado, accion);

            dataGridView1.DataSource = bss.ListarRolesBss();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            int idRolSeleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdRol"].Value);
            DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar este rol?", "Eliminar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    // Registrar auditoría antes de eliminar
                    string accion = $"Rol eliminado: Id={idRolSeleccionado}, NombreRol={dataGridView1.CurrentRow.Cells["NombreRol"].Value}";
                    auditoriaBss.RegistrarAuditoria(Sesion.IdUsuarioSeleccionado, accion);

                    bss.EliminarRolBss(idRolSeleccionado);
                    MessageBox.Show("Rol eliminado correctamente.");
                }
                catch (InvalidOperationException ex) // Captura la excepción específica
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex) // Captura cualquier otra excepción
                {
                    MessageBox.Show("Error al eliminar el rol: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                dataGridView1.DataSource = bss.ListarRolesBss();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Verifica que se haya seleccionado un rol en el DataGridView
            if (dataGridView1.CurrentRow != null)
            {
                // Obtiene el ID del rol seleccionado
                int idRolSeleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdRol"].Value);

                // Crea una nueva instancia de RolDetalleInterfaz pasando el ID del rol
                RolDetalleInterfaz detalleForm = new RolDetalleInterfaz(idRolSeleccionado);

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
