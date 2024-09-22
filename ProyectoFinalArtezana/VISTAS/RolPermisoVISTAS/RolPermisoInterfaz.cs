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

namespace VISTAS.RolPermisoVISTAS
{
    public partial class RolPermisoInterfaz : Form
    {
        public RolPermisoInterfaz()
        {
            InitializeComponent();
        }
        RolPermisosBSS bss = new RolPermisosBSS();
        RolBSS rolBss = new RolBSS(); // Para obtener la lista de roles
        PermisoBSS permisoBss = new PermisoBSS(); // Para obtener la lista de permisos
        public static int IdRolSeleccionado = 0;
        public static int IdPermisoSeleccionado = 0;
        private void RolPermisoInterfaz_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
            }
            else
            {
                RolPermiso rp = new RolPermiso
                {
                    IdRol = IdRolSeleccionado,
                    IdPermiso = IdPermisoSeleccionado,
                    Descripcion = textBox3.Text,
                    FechaAsignacion = DateTime.Now
                };

                bss.InsertarRolPermisoBss(rp);
                MessageBox.Show("Rol-Permiso guardado correctamente.");
                dataGridView1.DataSource = bss.ListarRolPermisosBss();
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells["IdRol"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["IdPermiso"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
            bool estaBloqueado = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[5].Value);
            checkBox1.Checked = estaBloqueado;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
            }
            else
            {
                RolPermiso rp = new RolPermiso
                {
                    IdRol = IdRolSeleccionado,
                    IdPermiso = IdPermisoSeleccionado,
                    Descripcion = textBox3.Text,
                    FechaAsignacion = DateTime.Now
                };

                bss.InsertarRolPermisoBss(rp);
                MessageBox.Show("Rol-Permiso guardado correctamente.");
                dataGridView1.DataSource = bss.ListarRolPermisosBss();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            checkBox1.Checked = false;
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
                int idRolPermisoSeleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdRolPermiso"].Value);
                RolPermiso editarRolPermiso = bss.ObtenerRolPermisoPorIdBss(idRolPermisoSeleccionado);

                editarRolPermiso.IdRol = IdRolSeleccionado;
                editarRolPermiso.IdPermiso = IdPermisoSeleccionado;
                editarRolPermiso.Descripcion = textBox3.Text;
                editarRolPermiso.FechaAsignacion = DateTime.Now;

                bss.EditarRolPermisoBss(editarRolPermiso);
                MessageBox.Show("Rol-Permiso actualizado correctamente.");
                dataGridView1.DataSource = bss.ListarRolPermisosBss();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int idRolPermisoSeleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdRolPermiso"].Value);
            DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar este Rol-Permiso?", "ELIMINAR", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                bss.EliminarRolPermisoBss(idRolPermisoSeleccionado);
                dataGridView1.DataSource = bss.ListarRolPermisosBss();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Lógica para seleccionar un Rol
            RolVISTAS.RolListar rolForm = new RolVISTAS.RolListar();
            if (rolForm.ShowDialog() == DialogResult.OK)
            {
                IdRolSeleccionado = rolForm.IdRolSeleccionado; // Asume que tienes esta propiedad
                textBox1.Text = rolBss.ObtenerRolPorIdBss(IdRolSeleccionado).NombreRol; // Asume que tienes la propiedad Nombre en Rol
            }
            RolVISTAS.RolListar kitForm = new RolVISTAS.RolListar();
            if (kitForm.ShowDialog() == DialogResult.OK)
            {
                Rol k = rolBss.ObtenerRolPorIdBss(IdRolSeleccionado);
                textBox1.Text = k.NombreRol;
            }
        }
    }
}
