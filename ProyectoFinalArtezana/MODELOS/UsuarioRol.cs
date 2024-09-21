using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELOS
{
    public class UsuarioRol
    {
        public int IdUsuarioRol { get; set; }
        public int IdRol { get; set; }
        public DateTime FechaAsignacion { get; set; }
        public bool Bloqueado { get; set; }
        public DateTime? FechaBloq { get; set; }
    }
}
