using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELOS
{
    public class Permiso
    {
        public int IdPermiso { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Bloqueado { get; set; }
        public DateTime? FechaBloq { get; set; }
    }
}
