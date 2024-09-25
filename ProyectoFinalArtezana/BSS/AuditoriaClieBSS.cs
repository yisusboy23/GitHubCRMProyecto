using DAL;
using MODELOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSS
{
    public class AuditoriaClieBSS
    {
        private AuditoriaClieDAL auditoriaDal = new AuditoriaClieDAL();

        public void RegistrarAuditoria(int idCliente, string accion)
        {
            AuditoriaClie auditoria = new AuditoriaClie
            {
                IdCliente = idCliente,
                Accion = accion,
                Timestamp = DateTime.Now
            };

            auditoriaDal.InsertarAuditoria(auditoria);
        }
    }
}
