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
    }
}
