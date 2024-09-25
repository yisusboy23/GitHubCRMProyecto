using MODELOS;
using System;
using System.Collections.Generic;
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
    }
}
