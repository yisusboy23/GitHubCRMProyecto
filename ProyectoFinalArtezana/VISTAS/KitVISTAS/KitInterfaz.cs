﻿using BSS;
using DAL;
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

namespace VISTAS.KitVISTAS
{
    public partial class KitInterfaz : Form
    {
        KitBSS bss = new KitBSS();
        AuditoriaBSS auditoriaBss = new AuditoriaBSS(); // Instancia de BSS para auditoría
        PermisoBSS permisosBss = new PermisoBSS(); // Instancia de PermisosDAL

        public KitInterfaz()
        {
            InitializeComponent();
        }

        private void KitInterfaz_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bss.ListarKitsBss();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["Precio"].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells["Cantidad"].Value.ToString();
            comboBox1.SelectedItem = dataGridView1.CurrentRow.Cells["Estado"].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            // Verificar permiso para insertar
            if (permisosBss.VerificarPermisoBloqueoBss("Insertar Kit"))
            {
                MessageBox.Show("El permiso para insertar kits está bloqueado.");
                return;
            }

            Kit kit = new Kit
            {
                Nombre = textBox1.Text,
                Descripcion = textBox2.Text,
                Precio = decimal.Parse(textBox3.Text),
                Cantidad = int.Parse(textBox4.Text),
                Estado = comboBox1.SelectedItem.ToString(),
                Fecha = DateTime.Now
            };

            bss.InsertarKitBss(kit);
            MessageBox.Show("Kit guardado correctamente.");
            dataGridView1.DataSource = bss.ListarKitsBss();

            // Registrar auditoría
            string accion = $"Gerende de tienda: Kit creado: Nombre={kit.Nombre}, Descripción={kit.Descripcion}, Precio={kit.Precio}, Cantidad={kit.Cantidad}, Estado={kit.Estado}";
            auditoriaBss.RegistrarAuditoria(Sesion.IdUsuarioSeleccionado, accion);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Verificar permiso para insertar
            if (permisosBss.VerificarPermisoBloqueoBss("Editar Kit"))
            {
                MessageBox.Show("El permiso para insertar kits está bloqueado.");
                return;
            }

            int idKitSeleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            Kit kit = bss.ObtenerKitPorIdBss(idKitSeleccionado);
            kit.Nombre = textBox1.Text;
            kit.Descripcion = textBox2.Text;
            kit.Precio = decimal.Parse(textBox3.Text);
            kit.Cantidad = int.Parse(textBox4.Text);
            kit.Estado = comboBox1.SelectedItem.ToString();

            bss.EditarKitBss(kit);
            MessageBox.Show("Kit actualizado.");

            string accion = $"Gerende de tienda: Kit actualizado: Id={idKitSeleccionado}, Nombre={kit.Nombre}, Descripción={kit.Descripcion}, Precio={kit.Precio}, Cantidad={kit.Cantidad}, Estado={kit.Estado}";
            auditoriaBss.RegistrarAuditoria(Sesion.IdUsuarioSeleccionado, accion);


            dataGridView1.DataSource = bss.ListarKitsBss();

        }

        private void button4_Click(object sender, EventArgs e)
        {

            // Verificar permiso para insertar
            if (permisosBss.VerificarPermisoBloqueoBss("Eliminar Kit"))
            {
                MessageBox.Show("El permiso para insertar kits está bloqueado.");
                return;
            }

            // Obtener el ID del kit seleccionado
            int idKitSeleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);

            // Mostrar un cuadro de diálogo de confirmación
            DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar este kit?", "ELIMINAR", MessageBoxButtons.YesNo);

            // Si el usuario confirma la eliminación
            if (result == DialogResult.Yes)
            {
                Kit kit = bss.ObtenerKitPorIdBss(idKitSeleccionado); // Obtener el kit para la auditoría
                bss.EliminarKitBss(idKitSeleccionado);
                MessageBox.Show("Kit eliminado.");

                // Registrar auditoría
                string accion = $"Gerende de tienda: Kit eliminado: Id={idKitSeleccionado}, Nombre={kit.Nombre}, Descripción={kit.Descripcion}, Precio={kit.Precio}, Cantidad={kit.Cantidad}, Estado={kit.Estado}";
                auditoriaBss.RegistrarAuditoria(Sesion.IdUsuarioSeleccionado, accion);

                dataGridView1.DataSource = bss.ListarKitsBss();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Verifica que se haya seleccionado un rol en el DataGridView
            if (dataGridView1.CurrentRow != null)
            {
                // Obtiene el ID del rol seleccionado
                int idRolSeleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id_Kit"].Value);

                // Crea una nueva instancia de RolDetalleInterfaz pasando el ID del rol
                KitDetalleInterfaz detalleForm = new KitDetalleInterfaz(idRolSeleccionado);

                // Muestra el formulario como un diálogo
                detalleForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un Kit para ver los detalles.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string nombreKit = textBox5.Text.Trim();

            if (!string.IsNullOrEmpty(nombreKit))
            {
                DataTable resultados = bss.BuscarKitsPorNombre(nombreKit);
                dataGridView1.DataSource = resultados;
            }
            else
            {
                MessageBox.Show("Por favor ingrese un nombre para la búsqueda.");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bss.ListarKitsBss();
        }
    }
}
