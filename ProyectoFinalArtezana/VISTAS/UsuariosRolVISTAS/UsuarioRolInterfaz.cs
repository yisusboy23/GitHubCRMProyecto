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
using VISTAS.UsuariosVISTAS;

namespace VISTAS.UsuariosRolVISTAS
{
    public partial class UsuarioRolInterfaz : Form
    {
        UsuarioRolBSS bss = new UsuarioRolBSS();
        UsuarioBSS usuarioBss = new UsuarioBSS(); // Para obtener la lista de usuarios
        RolBSS rolBss = new RolBSS(); // Para obtener la lista de roles
        public static int IdUsuarioSeleccionado = 0;
        public static int IdRolSeleccionado = 0;
        public UsuarioRolInterfaz()
        {
            InitializeComponent();
        }

        private void UsuarioRolInterfaz_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bss.ListarUsuarioRolesBss();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            bool estaBloqueado = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[4].Value);
            checkBox1.Checked = estaBloqueado;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (IdUsuarioSeleccionado == 0 || IdRolSeleccionado == 0)
            {
                MessageBox.Show("Por favor, seleccione un Usuario y un Rol.");
                return;
            }

            UsuarioRol ur = new UsuarioRol
            {
                IdUsuario = IdUsuarioSeleccionado,
                IdRol = IdRolSeleccionado,
                FechaAsignacion = DateTime.Now,
                Bloqueado = false, // Puedes cambiar esto según tu lógica
                FechaBloq = null // O el valor que desees
            };

            bss.InsertarUsuarioRolBss(ur);
            MessageBox.Show("Usuario-Rol guardado correctamente.");
            dataGridView1.DataSource = bss.ListarUsuarioRolesBss();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox5.Clear();
            checkBox1.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int idUsuarioRolSeleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdUsuarioRol"].Value);
                UsuarioRol editarUsuarioRol = bss.ObtenerUsuarioRolPorIdBss(idUsuarioRolSeleccionado);

                editarUsuarioRol.IdUsuario = IdUsuarioSeleccionado;
                editarUsuarioRol.IdRol = IdRolSeleccionado;
                editarUsuarioRol.Bloqueado = checkBox1.Checked;

                bss.EditarUsuarioRolBss(editarUsuarioRol);
                MessageBox.Show("Usuario-Rol actualizado correctamente.");
                dataGridView1.DataSource = bss.ListarUsuarioRolesBss();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int idUsuarioRolSeleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdUsuarioRol"].Value);
                DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar este Usuario-Rol?", "ELIMINAR", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    bss.EliminarUsuarioRolBss(idUsuarioRolSeleccionado);
                    dataGridView1.DataSource = bss.ListarUsuarioRolesBss();
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            UsuariosVISTAS.UsuarioListar usuarioForm = new UsuariosVISTAS.UsuarioListar();
            if (usuarioForm.ShowDialog() == DialogResult.OK)
            {
                Usuarios u = usuarioBss.ObtenerUsuarioPorIdBss(IdUsuarioSeleccionado);
                textBox1.Text = u.UserName; // Asumiendo que quieres mostrar el nombre de usuario
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RolVISTAS.RolListar rolForm = new RolVISTAS.RolListar();
            if (rolForm.ShowDialog() == DialogResult.OK)
            {
                Rol r = rolBss.ObtenerRolPorIdBss(IdRolSeleccionado);
                textBox5.Text = r.NombreRol; // Asumiendo que quieres mostrar la descripción del rol
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
