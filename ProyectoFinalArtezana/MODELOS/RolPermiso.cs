using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELOS
{
    public class RolPermiso
    {
        public int IdRolPermiso { get; set; }
        public int IdPermiso { get; set; }
        public int IdRol { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaAsignacion { get; set; }
        public bool Bloqueado { get; set; }
        public DateTime? FechaBloq { get; set; }
    }
}
