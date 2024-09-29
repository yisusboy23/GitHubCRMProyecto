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
using VISTAS.PersonaVISTAS;
using VISTAS.RolVISTAS;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VISTAS.AuditoriaClieVISTAS
{
    public partial class PersonaInterfaz : Form
    {
        PersonaBSS BSS = new PersonaBSS();
        AuditoriaBSS auditoriaBss = new AuditoriaBSS(); // Instancia para manejar la auditoría
        public PersonaInterfaz()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BSS.ListarPersonasBss();
            textBox3.MaxLength = 8;
            textBox3.KeyPress += textBox3_KeyPress;
            textBox5.Validating += textBox5_Validating;
            textBox4.Validating += textBox4_Validating;
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString(); // Nombre
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString(); // Apellido
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString(); // Teléfono
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString(); // Correo

            // Cargar Edad y Sexo
            textBox4.Text = dataGridView1.CurrentRow.Cells[6].Value != DBNull.Value ? dataGridView1.CurrentRow.Cells[5].Value.ToString() : ""; // Edad
            comboBox1.SelectedItem = dataGridView1.CurrentRow.Cells[7].Value != DBNull.Value ? dataGridView1.CurrentRow.Cells[6].Value.ToString() : ""; // Sexo
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("El campo Nombre está vacío.");
            }
            else if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("El campo Apellido está vacío.");
            }
            else if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("El campo Teléfono está vacío.");
            }
            else if (string.IsNullOrWhiteSpace(textBox5.Text))
            {
                MessageBox.Show("El campo Correo está vacío.");
            }
            else if (!int.TryParse(textBox4.Text, out int edad))
            {
                MessageBox.Show("La Edad debe ser un número válido.");
            }
            else if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un Sexo.");
            }
            else
            {
                Persona p = new Persona
                {
                    Nombre = textBox1.Text,
                    Apellido = textBox2.Text,
                    Telefono = textBox3.Text,
                    Correo = textBox5.Text,
                    Edad = edad,
                    Sexo = comboBox1.SelectedItem.ToString()
                };

                BSS.InsertarPersonaBss(p);
                MessageBox.Show("Se guardó correctamente");

                // Registrar auditoría
                string accion = $"Persona creada: Nombre={p.Nombre}, Apellido={p.Apellido}, Telefono={p.Telefono}, Correo={p.Correo}, Edad={p.Edad}, Sexo={p.Sexo}";
                auditoriaBss.RegistrarAuditoria(Sesion.IdUsuarioSeleccionado, accion);

                dataGridView1.DataSource = BSS.ListarPersonasBss();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox5.Clear();
            textBox4.Clear();
            comboBox1.SelectedIndex = -1; // Limpiar el ComboBox
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("El campo Nombre está vacío.");
            }
            else if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("El campo Apellido está vacío.");
            }
            else if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("El campo Teléfono está vacío.");
            }
            else if (string.IsNullOrWhiteSpace(textBox5.Text))
            {
                MessageBox.Show("El campo Correo está vacío.");
            }
            else if (!int.TryParse(textBox4.Text, out int edad))
            {
                MessageBox.Show("La Edad debe ser un número válido.");
            }
            else if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un Sexo.");
            }
            else
            {
                int IdPersonaSeleccionada = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                Persona editarPersona = BSS.ObtenerPersonaIdBss(IdPersonaSeleccionada);
                editarPersona.Nombre = textBox1.Text;
                editarPersona.Apellido = textBox2.Text;
                editarPersona.Telefono = textBox3.Text;
                editarPersona.Correo = textBox5.Text;
                editarPersona.Edad = edad;
                editarPersona.Sexo = comboBox1.SelectedItem.ToString();

                BSS.EditarPersonaBss(editarPersona);
                MessageBox.Show("Datos Actualizados");

                string accion = $"Persona actualizada: Id={IdPersonaSeleccionada}, Nombre={editarPersona.Nombre}, Apellido={editarPersona.Apellido}, Telefono={editarPersona.Telefono}, Correo={editarPersona.Correo}, Edad={editarPersona.Edad}, Sexo={editarPersona.Sexo}";
                auditoriaBss.RegistrarAuditoria(Sesion.IdUsuarioSeleccionado, accion);

                dataGridView1.DataSource = BSS.ListarPersonasBss();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Asegúrate de que haya una fila seleccionada en el DataGridView
            if (dataGridView1.CurrentRow != null)
            {
                int idPersonaSeleccionada = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar a esta persona?", "ELIMINAR", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        BSS.EliminarPersonaBss(idPersonaSeleccionada);
                        dataGridView1.DataSource = BSS.ListarPersonasBss(); // Actualiza el DataGridView
                        MessageBox.Show("Persona eliminada correctamente.");
                    }
                    catch (InvalidOperationException ex) // Captura la excepción específica
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex) // Captura cualquier otra excepción
                    {
                        MessageBox.Show("Error al eliminar la persona: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una persona para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permitir números y controlar la longitud
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Evitar entrada si no es número
            }
            else if (textBox3.Text.Length >= 8 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Evitar si ya hay 8 caracteres
            }
        }

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {
            string correo = textBox5.Text;
            if (!correo.Contains("@") || (!correo.EndsWith("@gmail.com") && !correo.EndsWith("@hotmail.com") && !correo.EndsWith("@yahoo.com")))
            {
                errorProvider1.SetError(textBox5, "El correo debe finalizar en un dominio válido (ej. @gmail.com, @hotmail.com, @yahoo.com).");
                e.Cancel = true; // Evitar perder el foco si es inválido
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            if (int.TryParse(textBox4.Text, out int edad))
            {
                if (edad < 16 || edad > 130)
                {
                    errorProvider2.SetError(textBox4, "La edad debe estar entre 16 y 130 años.");
                    e.Cancel = true; // Evitar perder el foco si es inválido
                }
                else
                {
                    errorProvider2.Clear();
                }
            }
            else
            {
                errorProvider2.SetError(textBox4, "Debe ingresar una edad válida.");
                e.Cancel = true; // Evitar perder el foco si no es un número válido
            }
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            // Validar que el teléfono tenga exactamente 8 dígitos
            if (textBox3.Text.Length != 8)
            {
                errorProvider1.SetError(textBox3, "El teléfono debe tener exactamente 8 dígitos.");
                e.Cancel = true; // Cancelar el evento si la validación falla
            }
            else
            {
                errorProvider1.SetError(textBox3, string.Empty); // Limpiar el error
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Verifica que se haya seleccionado un rol en el DataGridView
            if (dataGridView1.CurrentRow != null)
            {
                // Obtiene el ID del rol seleccionado
                int idRolSeleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells["idPersona"].Value);

                // Crea una nueva instancia de RolDetalleInterfaz pasando el ID del rol
                PersonaDetalliInterfaz detalleForm = new PersonaDetalliInterfaz(idRolSeleccionado);

                // Muestra el formulario como un diálogo
                detalleForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un rol para ver los detalles.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string filtro = textBox6.Text.Trim();

            if (!string.IsNullOrEmpty(filtro))
            {
                DataTable resultado = BSS.BuscarPersonas(filtro);
                dataGridView1.DataSource = resultado;  // Asumiendo que tienes un DataGridView llamado dgvResultados
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un nombre o apellido para buscar.");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BSS.ListarPersonasBss();
        }
    }
}
