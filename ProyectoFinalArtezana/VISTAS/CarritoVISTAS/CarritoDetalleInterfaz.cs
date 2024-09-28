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

namespace VISTAS.CarritoVISTAS
{
    public partial class CarritoDetalleInterfaz : Form
    {
        int idCarrito;
        CarritoBSS bss= new CarritoBSS();
        public CarritoDetalleInterfaz(int idPersona)
        {
            InitializeComponent();
            this.idCarrito = idPersona;
        }

        private void CarritoDetalleInterfaz_Load(object sender, EventArgs e)
        {
            // Cargar permisos asociados al rol
            dataGridView1.DataSource = bss.ObtenerDetallesCarritoBss(idCarrito);
        }
    }
}
