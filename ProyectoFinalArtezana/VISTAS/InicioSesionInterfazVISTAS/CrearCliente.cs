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

        private void CrearCliente_Load(object sender, EventArgs e)
        {
            textBox3.KeyPress += textBox3_KeyPress;
            textBox5.Validating += textBox5_Validating;
            textBox4.Validating += textBox4_Validating;
            textBox7.Validating += textBox7_Validating;
            textBox6.Validating += textBox6_Validating;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y controlar la longitud
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // No permitir caracteres que no sean dígitos
            }

            // Limitar a 8 caracteres
            if (textBox3.Text.Length >= 8 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // No permitir más caracteres
            }
        }

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {
            string email = textBox5.Text;
            if (!email.EndsWith("@gmail.com") && !email.EndsWith("@hotmail.com") && !email.EndsWith("@yahoo.com"))
            {
                errorProvider1.SetError(textBox5, "El correo debe terminar con @gmail.com, @hotmail.com o @yahoo.com.");
                e.Cancel = true; // Cancelar el evento si la validación falla
            }
            else
            {
                errorProvider1.SetError(textBox5, string.Empty); // Limpiar el error
            }
        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            if (int.TryParse(textBox4.Text, out int edad))
            {
                if (edad < 16 || edad > 130)
                {
                    errorProvider1.SetError(textBox4, "La edad debe estar entre 16 y 130 años.");
                    e.Cancel = true; // Cancelar el evento si la validación falla
                }
                else
                {
                    errorProvider1.SetError(textBox4, string.Empty); // Limpiar el error
                }
            }
            else
            {
                errorProvider1.SetError(textBox4, "La edad debe ser un número válido.");
                e.Cancel = true; // Cancelar el evento si la validación falla
            }
        }

        private void textBox7_Validating(object sender, CancelEventArgs e)
        {
            if (textBox7.Text.Length < 3)
            {
                errorProvider1.SetError(textBox7, "El nombre de usuario debe tener al menos 3 caracteres.");
                e.Cancel = true; // Cancelar el evento si la validación falla
            }
            else
            {
                errorProvider1.SetError(textBox7, string.Empty); // Limpiar el error
            }
        }

        private void textBox6_Validating(object sender, CancelEventArgs e)
        {
            string password = textBox6.Text;
            if (password.Length < 8)
            {
                errorProvider1.SetError(textBox6, "La contraseña debe tener al menos 8 caracteres.");
                e.Cancel = true; // Cancelar el evento si la validación falla
            }
            else if (!password.Any(char.IsUpper) || !password.Any(char.IsLower) || !password.Any(char.IsDigit) || !password.Any(ch => "!@#$%^&*()".Contains(ch)))
            {
                errorProvider1.SetError(textBox6, "La contraseña debe tener al menos una mayúscula, una minúscula, un número y un símbolo especial.");
                e.Cancel = true; // Cancelar el evento si la validación falla
            }
            else
            {
                errorProvider1.SetError(textBox6, string.Empty); // Limpiar el error
            }
        }
    }
}
