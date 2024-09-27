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

namespace VISTAS.AuditoriaVISTAS
{
    public partial class FiltroAuditoriaInterfaz : Form
    {
        public FiltroAuditoriaInterfaz()
        {
            InitializeComponent();
        }
        UsuarioBSS usuarioBss = new UsuarioBSS(); // Para obtener la lista de usuarios
        AuditoriaBSS bss = new AuditoriaBSS();
        public static int IdUsuarioSeleccionado = 0;

        private void button1_Click(object sender, EventArgs e)
        { // Verificar si se aplicarán filtros por fecha
            DateTime? fechaInicio = checkBox1.Checked ? (DateTime?)null : dateTimePicker1.Value;
            DateTime? fechaFin = checkBox1.Checked ? (DateTime?)null : dateTimePicker2.Value;

            // Verificar si se aplicarán filtros por usuario
            int? idUsuario = checkBox2.Checked ? (int?)null : IdUsuarioSeleccionado;

            // Obtener la acción seleccionada
            string accionSeleccionada = comboBox1.SelectedItem?.ToString();

            // Llamar a la capa BSS para obtener los registros de auditoría filtrados
            DataTable auditoriaFiltrada = bss.FiltrarAuditorias(fechaInicio, fechaFin, idUsuario, accionSeleccionada);

            // Mostrar los datos en un DataGridView
            dataGridView1.DataSource = auditoriaFiltrada;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UsuariosVISTAS.UsuarioListar usuarioForm = new UsuariosVISTAS.UsuarioListar();
            if (usuarioForm.ShowDialog() == DialogResult.OK)
            {
                Usuarios u = usuarioBss.ObtenerUsuarioPorIdBss(IdUsuarioSeleccionado);
                textBox1.Text = u.UserName; // Asumiendo que quieres mostrar el nombre de usuario
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Si el checkbox está marcado, deshabilitar los DateTimePickers
            bool sinFechas = checkBox1.Checked;
            dateTimePicker1.Enabled = !sinFechas;
            dateTimePicker2.Enabled = !sinFechas;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            // Si el checkbox está marcado, deshabilitar el TextBox, el Button y el IdUsuarioSeleccionado
            bool sinUsuario = checkBox2.Checked;
            textBox1.Enabled = !sinUsuario;
            button5.Enabled = !sinUsuario; // Botón para seleccionar usuario
            IdUsuarioSeleccionado = sinUsuario ? 0 : IdUsuarioSeleccionado;
        }
    }
}
