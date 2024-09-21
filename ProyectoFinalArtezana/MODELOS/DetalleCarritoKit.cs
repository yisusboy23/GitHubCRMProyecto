using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELOS
{
    public class DetalleCarritoKit
    {
        public int IdDetalleCarritoK { get; set; }
        public int IdCarrito { get; set; }
        public int IdKitProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal PrecioTotal { get; set; }
        public DateTime Fecha { get; set; }
    }
}
