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

namespace VISTAS.MenuClienteVISTAS
{
    public partial class MenuQuejaClienteInterfaz : Form
    {
        public MenuQuejaClienteInterfaz()
        {
            InitializeComponent();
        }
        AuditoriaClieBSS bss = new AuditoriaClieBSS();
        private void button1_Click(object sender, EventArgs e)
        {
            // Obtener la queja seleccionada del ComboBox
            string quejaSeleccionada = comboBox1.SelectedItem.ToString();

            // Obtener el comentario del cliente
            string comentarioCliente = textBox1.Text;

            // Registrar la queja en la auditoría
            string accion = $"Queja registrada: Tipo de queja={quejaSeleccionada}, Comentario del cliente={comentarioCliente}";

            // Registrar auditoría (suponiendo que ya tienes un método en la capa BSS para registrar auditorías)
            bss.RegistrarAuditoria(Sesion.IdClienteSeleccionado, accion);

            // Mensaje de confirmación
            MessageBox.Show("La queja ha sido registrada exitosamente.", "Queja Registrada");

            // Limpiar campos después del envío
            comboBox1.SelectedIndex = -1; // Deselecciona cualquier opción
            textBox1.Clear(); // Limpia el campo de comentario
        }
    }
}
