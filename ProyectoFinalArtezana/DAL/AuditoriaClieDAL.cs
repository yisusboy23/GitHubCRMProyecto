using MODELOS;
using System;
using System.Collections.Generic;
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
    }
}
