using BSS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VISTAS.RolVISTAS
{
    public partial class RolDetalleInterfaz : Form
    {
        int idRol; // Variable para almacenar el ID del rol
        RolBSS rolBss = new RolBSS();
        public RolDetalleInterfaz(int idRol)
        {
            InitializeComponent();
            this.idRol = idRol;
        }
        private void RolDetalleInterfaz_Load(object sender, EventArgs e)
        {
            // Cargar usuarios asociados al rol
            dataGridView1.DataSource = rolBss.ObtenerUsuariosPorRol(idRol);

            // Cargar permisos asociados al rol
            dataGridView2.DataSource = rolBss.ObtenerPermisosPorRol(idRol);
        }
    }
}
