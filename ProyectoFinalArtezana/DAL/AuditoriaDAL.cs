using MODELOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AuditoriaDAL
    {
        public void InsertarAuditoria(Auditoria auditoria)
        {
            string consulta = "INSERT INTO Auditoria (Accion, Timestamp, UserId) VALUES (@Accion, @Timestamp, @UserId)";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Accion", auditoria.Accion),
                new SqlParameter("@Timestamp", auditoria.Timestamp),
                new SqlParameter("@UserId", auditoria.UserId)
            };

            using (SqlConnection conectar = new SqlConnection(CONEXION.CONECTAR))
            {
                conectar.Open();
                using (SqlCommand cmd = new SqlCommand(consulta, conectar))
                {
                    cmd.Parameters.AddRange(parametros);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Método para listar auditorías
        public DataTable ListarAuditoriaDAL()
        {
            string consulta = "SELECT * FROM Auditoria";  // Puedes ajustar esta consulta según los campos que desees mostrar
            return CONEXION.EjecutarDataTabla(consulta, "tablaAuditoria");
        }


        public DataTable FiltrarAuditoriasConFechaYUsuario(DateTime? fechaInicio, DateTime? fechaFin, int userId)
        {
            string consulta = @"
    SELECT * FROM Auditoria
    WHERE Timestamp >= @FechaInicio
    AND Timestamp <= @FechaFin
    AND UserId = @UserId";

            SqlParameter[] parametros = new SqlParameter[]
            {
        new SqlParameter("@FechaInicio", fechaInicio.HasValue ? (object)fechaInicio.Value : DBNull.Value),
        new SqlParameter("@FechaFin", fechaFin.HasValue ? (object)fechaFin.Value : DBNull.Value),
        new SqlParameter("@UserId", userId)
            };

            return CONEXION.EjecutarDataTabla2(consulta, "tablaAuditoriaFiltrada", parametros);
        }
        // Método para filtrar auditorías por rango de fechas, usuario y acción
        public DataTable FiltrarAuditoriasDAL(DateTime? fechaInicio, DateTime? fechaFin, int? userId, string accion)
        {
            string consulta;
            List<SqlParameter> parametros = new List<SqlParameter>();

            // Comenzamos construyendo la consulta base
            consulta = "SELECT * FROM Auditoria WHERE 1=1"; // Base para agregar condiciones

            // Filtros para rango de fechas
            if (fechaInicio.HasValue)
            {
                consulta += " AND Timestamp >= @FechaInicio";
                parametros.Add(new SqlParameter("@FechaInicio", fechaInicio.Value));
            }

            if (fechaFin.HasValue)
            {
                consulta += " AND Timestamp <= @FechaFin";
                parametros.Add(new SqlParameter("@FechaFin", fechaFin.Value));
            }

            // Filtro para el usuario
            if (userId.HasValue)
            {
                consulta += " AND UserId = @UserId";
                parametros.Add(new SqlParameter("@UserId", userId.Value));
            }

            // Filtro para la acción
            if (!string.IsNullOrEmpty(accion))
            {
                consulta += " AND Accion LIKE '%' + @Accion + '%'";
                parametros.Add(new SqlParameter("@Accion", accion));
            }

            // Ejecutar la consulta y devolver el resultado como DataTable
            return CONEXION.EjecutarDataTabla2(consulta, "tablaAuditoriaFiltrada", parametros.ToArray());
        }

    }
}
