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
    public class AuditoriaClieDAL
    {
        public void InsertarAuditoria(AuditoriaClie auditoria)
        {
            string consulta = "INSERT INTO AuditoriaClie (Accion, Timestamp, IdCliente) VALUES (@Accion, @Timestamp, @IdCliente)";

            SqlParameter[] parametros = new SqlParameter[]
            {
            new SqlParameter("@Accion", auditoria.Accion),
            new SqlParameter("@Timestamp", auditoria.Timestamp),
            new SqlParameter("@IdCliente", auditoria.IdCliente)
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
        public DataTable ListarAuditoriaClieDAL()
        {
            string consulta = "SELECT * FROM AuditoriaClie"; // Ajustar la consulta según los campos necesarios
            return CONEXION.EjecutarDataTabla(consulta, "tablaAuditoriaClie");
        }

        // Método para filtrar auditorías por rango de fechas, cliente y acción
        public DataTable FiltrarAuditoriasClieDAL(DateTime? fechaInicio, DateTime? fechaFin, int? idCliente, string accion)
        {
            string consulta;
            List<SqlParameter> parametros = new List<SqlParameter>();

            // Comenzamos construyendo la consulta base
            consulta = "SELECT * FROM AuditoriaClie WHERE 1=1"; // Base para agregar condiciones

            // Filtros para rango de fechas
            if (fechaInicio.HasValue)
            {
                consulta += " AND timestamp >= @FechaInicio";
                parametros.Add(new SqlParameter("@FechaInicio", fechaInicio.Value));
            }

            if (fechaFin.HasValue)
            {
                consulta += " AND timestamp <= @FechaFin";
                parametros.Add(new SqlParameter("@FechaFin", fechaFin.Value));
            }

            // Filtro para el cliente
            if (idCliente.HasValue)
            {
                consulta += " AND idCliente = @IdCliente";
                parametros.Add(new SqlParameter("@IdCliente", idCliente.Value));
            }

            // Filtro para la acción
            if (!string.IsNullOrEmpty(accion))
            {
                consulta += " AND accion LIKE '%' + @Accion + '%'";
                parametros.Add(new SqlParameter("@Accion", accion));
            }

            // Ejecutar la consulta y devolver el resultado como DataTable
            return CONEXION.EjecutarDataTabla2(consulta, "tablaAuditoriaClieFiltrada", parametros.ToArray());
        }

    }
}
