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

        // Método para obtener la lista de auditorías
        public DataTable ListarAuditoriaBSS()
        {
            return auditoriaDal.ListarAuditoriaDAL();
        }

        // Método para filtrar auditorías en la capa BSS
        // Método para filtrar auditorías por rango de fechas y usuario
        public DataTable FiltrarAuditoriasConFechaYUsuario(DateTime? fechaInicio, DateTime? fechaFin, int userId)
        {
            return auditoriaDal.FiltrarAuditoriasConFechaYUsuario(fechaInicio, fechaFin, userId);
        }

        // Método para filtrar auditorías por rango de fechas, usuario y acción
        public DataTable FiltrarAuditorias(DateTime? fechaInicio, DateTime? fechaFin, int? userId, string accion)
        {
            return auditoriaDal.FiltrarAuditoriasDAL(fechaInicio, fechaFin, userId, accion);
        }
    }

}
