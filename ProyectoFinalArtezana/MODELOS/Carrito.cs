using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELOS
{
    public class Carrito
    {
        public int IdCarrito { get; set; }
        public int IdCliente { get; set; }
        public DateTime Fecha { get; set; }
        public decimal PrecioTotal { get; set; }
    }
}
