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

namespace VISTAS.PermisoVISTAS
{
    public partial class PermisoInterfaz : Form
    {
        PermisoBSS bss = new PermisoBSS();
        public PermisoInterfaz()
        {
            InitializeComponent();
        }

        private void PermisoInterfaz_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bss.ListarPermisosBss();
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

            Permiso permiso = new Permiso
            {
                Nombre = textBox1.Text,
                Descripcion = textBox2.Text,
                Bloqueado = checkBox1.Checked,
                FechaBloq = checkBox1.Checked ? (DateTime?)DateTime.Now : null
            };

            bss.InsertarPermisoBss(permiso);
            MessageBox.Show("Permiso agregado correctamente.");
            dataGridView1.DataSource = bss.ListarPermisosBss();
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

            int idPermisoSeleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdPermiso"].Value);
            Permiso permiso = bss.ObtenerPermisoPorIdBss(idPermisoSeleccionado);
            permiso.Nombre = textBox1.Text;
            permiso.Descripcion = textBox2.Text;
            permiso.Bloqueado = checkBox1.Checked;
            permiso.FechaBloq = checkBox1.Checked ? (DateTime?)DateTime.Now : null;

            bss.EditarPermisoBss(permiso);
            MessageBox.Show("Datos actualizados correctamente.");
            dataGridView1.DataSource = bss.ListarPermisosBss();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int idPermisoSeleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdPermiso"].Value);
            DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar este permiso?", "Eliminar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                bss.EliminarPermisoBss(idPermisoSeleccionado);
                MessageBox.Show("Permiso eliminado correctamente.");
                dataGridView1.DataSource = bss.ListarPermisosBss();
            }
        }
    }
}
