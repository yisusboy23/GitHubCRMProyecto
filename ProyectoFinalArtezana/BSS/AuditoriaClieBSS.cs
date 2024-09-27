using DAL;
using MODELOS;
using System;
using System.Collections.Generic;
using System.Data;
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


        // Método para obtener la lista de auditorías
        public DataTable ListarAuditoriaClieBSS()
        {
            return auditoriaDal.ListarAuditoriaClieDAL();
        }

        // Método para filtrar auditorías por rango de fechas, usuario y acción
        public DataTable FiltrarAuditoriasClie(DateTime? fechaInicio, DateTime? fechaFin, int? userId, string accion)
        {
            return auditoriaDal.FiltrarAuditoriasClieDAL(fechaInicio, fechaFin, userId, accion);
        }
    }
}
