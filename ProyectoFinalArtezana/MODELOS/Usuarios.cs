using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELOS
{
    public class Usuarios
    {
        public int IdUsuario { get; set; }
        public int IdPersona { get; set; }
        public string UserName { get; set; }
        public string Contraseña { get; set; }
        public string Ci { get; set; }
        public bool Bloqueado { get; set; }
        public DateTime? FechaBloq { get; set; }
    }
}
