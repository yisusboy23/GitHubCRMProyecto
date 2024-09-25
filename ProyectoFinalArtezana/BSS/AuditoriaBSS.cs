using DAL;
using MODELOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSS
{
    public class AuditoriaBSS
    {
        private AuditoriaDAL auditoriaDal = new AuditoriaDAL();

        public void RegistrarAuditoria(int userId, string accion)
        {
            Auditoria auditoria = new Auditoria
            {
                UserId = userId,
                Accion = accion,
                Timestamp = DateTime.Now
            };

            auditoriaDal.InsertarAuditoria(auditoria);
        }
    }
}
