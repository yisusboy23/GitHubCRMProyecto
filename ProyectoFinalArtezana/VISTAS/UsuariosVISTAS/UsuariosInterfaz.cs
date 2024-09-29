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

namespace VISTAS.UsuariosVISTAS
{
    public partial class UsuariosInterfaz : Form
    {
        UsuarioBSS bss = new UsuarioBSS();
        PersonaBSS bssuser = new PersonaBSS();
        AuditoriaBSS auditoriaBss = new AuditoriaBSS(); // Instancia para manejar la auditoría
        public static int IdPersonaSeleccionada = 0;
        public UsuariosInterfaz()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            bool estaBloqueado = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[5].Value);
            checkBox1.Checked = estaBloqueado;
        }

        private void UsuariosInterfaz_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bss.ListarUsuariosBss();
            textBox2.Validating += textBox2_Validating; // Validación para Nombre de Usuario
            textBox3.Validating += textBox3_Validating; // Validación para Contraseña
            textBox4.KeyPress += textBox4_KeyPress;
            textBox4.Validating += textBox4_Validating;// Validación para CI

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
            }
            else
            {
                Usuarios u = new Usuarios
                {
                    IdPersona = IdPersonaSeleccionada,
                    UserName = textBox2.Text,
                    Contraseña = textBox3.Text,
                    Ci = textBox4.Text,
                    Bloqueado = false, // Puedes cambiar esto según tu lógica
                    FechaBloq = null // O el valor que desees
                };

                bss.InsertarUsuarioBss(u);
                MessageBox.Show("Se guardó correctamente el usuario");
                dataGridView1.DataSource = bss.ListarUsuariosBss();
                string accion = $"Usuario creado: Username={u.UserName}, CI={u.Ci}, Bloqueado={u.Bloqueado}";
                auditoriaBss.RegistrarAuditoria(Sesion.IdUsuarioSeleccionado, accion);

                dataGridView1.DataSource = bss.ListarUsuariosBss();

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PersonaVISTAS.PersonaListar fr = new PersonaVISTAS.PersonaListar();
            if (fr.ShowDialog() == DialogResult.OK)
            {
                Persona p = bssuser.ObtenerPersonaIdBss(IdPersonaSeleccionada);
                textBox1.Text = p.Nombre + " " + p.Apellido;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            checkBox1.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
            }
            else
            {
                int idUsuarioSeleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdUsuario"].Value);
                Usuarios editarUsuario = bss.ObtenerUsuarioPorIdBss(idUsuarioSeleccionado);
                editarUsuario.IdPersona = IdPersonaSeleccionada;
                editarUsuario.UserName = textBox2.Text;
                editarUsuario.Contraseña = textBox3.Text;
                editarUsuario.Bloqueado = checkBox1.Checked;
                editarUsuario.FechaBloq = checkBox1.Checked ? (DateTime?)DateTime.Now : null;
                bss.EditarUsuarioBss(editarUsuario);
                MessageBox.Show("Datos Actualizados");
                dataGridView1.DataSource = bss.ListarUsuariosBss();

                string accion = $"Usuario actualizado: Id={idUsuarioSeleccionado}, Username={editarUsuario.UserName}, Bloqueado={editarUsuario.Bloqueado}";
                auditoriaBss.RegistrarAuditoria(Sesion.IdUsuarioSeleccionado, accion);

                dataGridView1.DataSource = bss.ListarUsuariosBss();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int idUsuarioSeleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdUsuario"].Value);
            DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar a este usuario?", "ELIMINAR", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    // Registrar auditoría antes de eliminar
                    string accion = $"Usuario eliminado: Id={idUsuarioSeleccionado}, Username={dataGridView1.CurrentRow.Cells["UserName"].Value}";
                    auditoriaBss.RegistrarAuditoria(Sesion.IdUsuarioSeleccionado, accion);

                    bss.EliminarUsuarioBss(idUsuarioSeleccionado);
                    dataGridView1.DataSource = bss.ListarUsuariosBss();
                    MessageBox.Show("Usuario eliminado correctamente.");
                }
                catch (InvalidOperationException ex) // Captura la excepción específica
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex) // Captura cualquier otra excepción
                {
                    MessageBox.Show("Error al eliminar el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (textBox2.Text.Length < 3)
            {
                errorProvider1.SetError(textBox2, "El nombre de usuario debe tener al menos 3 caracteres.");
                e.Cancel = true; // Cancelar el evento si la validación falla
            }
            else
            {
                errorProvider1.SetError(textBox2, string.Empty); // Limpiar el error
            }
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            string password = textBox3.Text;
            if (password.Length < 8)
            {
                errorProvider1.SetError(textBox3, "La contraseña debe tener al menos 8 caracteres.");
                e.Cancel = true; // Cancelar el evento si la validación falla
            }
            else if (!password.Any(char.IsUpper) || !password.Any(char.IsLower) || !password.Any(char.IsDigit) || !password.Any(ch => "!@#$%^&*()".Contains(ch)))
            {
                errorProvider1.SetError(textBox3, "La contraseña debe tener al menos una mayúscula, una minúscula, un número y un símbolo especial.");
                e.Cancel = true; // Cancelar el evento si la validación falla
            }
            else
            {
                errorProvider1.SetError(textBox3, string.Empty); // Limpiar el error
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y controlar la longitud
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // No permitir caracteres que no sean dígitos
            }

            // Limitar a 7 caracteres
            if (textBox4.Text.Length >= 7 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // No permitir más caracteres
            }
        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            // Validar que el teléfono tenga exactamente 8 dígitos
            if (textBox4.Text.Length != 7)
            {
                errorProvider1.SetError(textBox3, "El CI debe tener exactamente 8 dígitos.");
                e.Cancel = true; // Cancelar el evento si la validación falla
            }
            else
            {
                errorProvider1.SetError(textBox3, string.Empty); // Limpiar el error
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string userName = textBox6.Text.Trim();
            DataTable resultados = bss.BuscarUsuariosPorUserName(userName);

            if (resultados.Rows.Count > 0)
            {
                dataGridView1.DataSource = resultados;
            }
            else
            {
                MessageBox.Show("No se encontraron usuarios con ese nombre de usuario.", "Búsqueda de Usuarios");
                dataGridView1.DataSource = null;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bss.ListarUsuariosBss();
        }
    }
}
