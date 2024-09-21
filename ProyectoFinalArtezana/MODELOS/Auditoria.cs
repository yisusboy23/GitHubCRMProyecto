using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELOS
{
    public class Auditoria
    {
        public int IdAudit { get; set; }
        public string Accion { get; set; }
        public DateTime Timestamp { get; set; }
        public int UserId { get; set; }
    }
}
