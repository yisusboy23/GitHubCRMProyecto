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
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
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
            else
            {
                Persona p = new Persona();
                p.Nombre = textBox1.Text;
                p.Apellido = textBox2.Text;
                p.Telefono = textBox3.Text;
                p.Correo = textBox5.Text;

                BSS.InsertarPersonaBss(p);
                MessageBox.Show("Se guardó correctamente");

                // Registrar auditoría
                string accion = $"Persona creada: Nombre={p.Nombre}, Apellido={p.Apellido}, Telefono={p.Telefono}, Correo={p.Correo}";
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
            else
            {

                int IdPersonaSeleccionada = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                Persona editarPersona = BSS.ObtenerPersonaIdBss(IdPersonaSeleccionada);
                editarPersona.Nombre = textBox1.Text;
                editarPersona.Apellido = textBox2.Text;
                editarPersona.Telefono = textBox3.Text;
                editarPersona.Correo = textBox5.Text;

                BSS.EditarPersonaBss(editarPersona);
                MessageBox.Show("Datos Actualizados");

                string accion = $"Persona actualizada: Id={IdPersonaSeleccionada}, Nombre={editarPersona.Nombre}, Apellido={editarPersona.Apellido}, Telefono={editarPersona.Telefono}, Correo={editarPersona.Correo}";
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
    }
}
