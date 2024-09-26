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
using VISTAS.MenuClienteVISTAS;

namespace VISTAS.InicioSesionInterfazVISTAS
{
    public partial class CrearCliente : Form
    {
        public CrearCliente()
        {
            InitializeComponent();
        }
        private PersonaBSS personaBss = new PersonaBSS();
        private AuditoriaClieBSS auditoriaBss = new AuditoriaClieBSS(); // Instancia para manejar la auditoría

        private void button3_Click(object sender, EventArgs e)
        {
            // Validar que todos los campos estén completos
            if (string.IsNullOrWhiteSpace(textBox1.Text) || // Nombre
                string.IsNullOrWhiteSpace(textBox2.Text) || // Apellido
                string.IsNullOrWhiteSpace(textBox3.Text) || // Teléfono
                string.IsNullOrWhiteSpace(textBox5.Text) || // Correo
                string.IsNullOrWhiteSpace(textBox7.Text) || // UserName
                string.IsNullOrWhiteSpace(textBox6.Text) || // Contraseña
                string.IsNullOrWhiteSpace(textBox4.Text) || // Edad
                comboBox1.SelectedItem == null)            // Sexo
            {
                MessageBox.Show("Por favor, completa todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Crear una nueva persona con los datos ingresados
            Persona nuevaPersona = new Persona
            {
                Nombre = textBox1.Text,
                Apellido = textBox2.Text,
                Telefono = textBox3.Text,
                Correo = textBox5.Text,
                Edad = int.Parse(textBox4.Text), // Asignar Edad
                Sexo = comboBox1.SelectedItem.ToString() // Asignar Sexo
            };

            // Crear un nuevo cliente
            Cliente nuevoCliente = new Cliente
            {
                UserName = textBox7.Text,
                Contraseña = textBox6.Text,
                Bloqueado = false,
                FechaBloq = null
            };

            try
            {
                // Llamar al método para insertar la persona y el cliente y recibir el cliente completo
                nuevoCliente = personaBss.InsertarPersonaYClienteBss(nuevaPersona, nuevoCliente);

                // Guardar el IdCliente y Nombre en la sesión
                Sesion.IdClienteSeleccionado = nuevoCliente.IdCliente; // Asignar IdCliente del cliente recién creado
                Sesion.NombreCliente = nuevoCliente.UserName; // Guardar el nombre en la sesión

                MessageBox.Show("Cuenta creada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                string accionCrearCliente = $"Cliente creado: IdCliente={nuevoCliente.IdCliente}, NombreUsuario={nuevoCliente.UserName}";
                auditoriaBss.RegistrarAuditoria(Sesion.IdClienteSeleccionado, accionCrearCliente);

                string accionInicioSesion = $"{nuevoCliente.UserName} Inicio de sesión";
                auditoriaBss.RegistrarAuditoria(Sesion.IdClienteSeleccionado, accionInicioSesion);

                // Redirigir al menú del cliente y cerrar esta ventana
                MenuClienteInterfaz menuCliente = new MenuClienteInterfaz();
                menuCliente.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al crear la cuenta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
