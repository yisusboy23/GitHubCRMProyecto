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
    public class PermisoDAL
    {
        public DataTable ListarPermisosDal()
        {
            string consulta = "SELECT * FROM Permiso";
            return CONEXION.EjecutarDataTabla(consulta, "Permisos");
        }

        public void InsertarPermisoDal(Permiso permiso)
        {
            string consulta = "INSERT INTO Permiso (Nombre, Descripcion, Bloqueado, FechaBloq) " +
                              "VALUES ('" + permiso.Nombre + "', '" + permiso.Descripcion + "', " +
                              (permiso.Bloqueado ? 1 : 0) + ", " +
                              (permiso.FechaBloq.HasValue ? "'" + permiso.FechaBloq.Value.ToString("yyyy-MM-dd HH:mm:ss") + "'" : "NULL") + ")";
            CONEXION.Ejecutar(consulta);
        }

        public Permiso ObtenerPermisoPorIdDal(int id)
        {
            string consulta = "SELECT * FROM Permiso WHERE IdPermiso = " + id;
            DataTable tabla = CONEXION.EjecutarDataTabla(consulta, "Permisos");
            Permiso permiso = new Permiso();

            if (tabla.Rows.Count > 0)
            {
                permiso.IdPermiso = Convert.ToInt32(tabla.Rows[0]["IdPermiso"]);
                permiso.Nombre = tabla.Rows[0]["Nombre"].ToString();
                permiso.Descripcion = tabla.Rows[0]["Descripcion"].ToString();
                permiso.Bloqueado = Convert.ToBoolean(tabla.Rows[0]["Bloqueado"]);
                permiso.FechaBloq = tabla.Rows[0]["FechaBloq"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(tabla.Rows[0]["FechaBloq"]) : null;
            }
            return permiso;
        }

        public void EditarPermisoDal(Permiso permiso)
        {
            string consulta = "UPDATE Permiso SET Nombre = '" + permiso.Nombre + "', " +
                              "Descripcion = '" + permiso.Descripcion + "', " +
                              "Bloqueado = " + (permiso.Bloqueado ? 1 : 0) + ", " +
                              "FechaBloq = " + (permiso.FechaBloq.HasValue ? "'" + permiso.FechaBloq.Value.ToString("yyyy-MM-dd HH:mm:ss") + "'" : "NULL") + " " +
                              "WHERE IdPermiso = " + permiso.IdPermiso;
            CONEXION.Ejecutar(consulta);
        }

        public void EliminarPermisoDal(int id)
        {
            // Verificar si existen registros en RolPermiso que referencian a este Permiso
            string verificacionConsulta = "SELECT COUNT(*) FROM RolPermiso WHERE IdPermiso = @IdPermiso";

            using (SqlConnection connection = new SqlConnection(CONEXION.CONECTAR)) // Cambiar ConnectionString por CONECTAR
            {
                SqlCommand command = new SqlCommand(verificacionConsulta, connection);
                command.Parameters.AddWithValue("@IdPermiso", id);

                connection.Open();
                int conteoRolesPermisos = (int)command.ExecuteScalar();

                // Si hay roles asociados, lanzar excepción
                if (conteoRolesPermisos > 0)
                {
                    throw new InvalidOperationException("No se puede eliminar el permiso porque tiene roles asociados.");
                }
            }

            // Proceder a eliminar el permiso si no hay dependencias
            string consulta = "DELETE FROM Permiso WHERE IdPermiso = @IdPermiso";

            using (SqlConnection connection = new SqlConnection(CONEXION.CONECTAR)) // Cambiar ConnectionString por CONECTAR
            {
                SqlCommand command = new SqlCommand(consulta, connection);
                command.Parameters.AddWithValue("@IdPermiso", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public bool VerificarPermisoBloqueoDAL(string nombrePermiso)
        {
            bool estaBloqueado = false;

            string consulta = @"
            SELECT P.Bloqueado AS PermisoBloqueado, 
           RP.Bloqueado AS RolPermisoBloqueado
            FROM Permiso P
            JOIN RolPermiso RP ON P.IdPermiso = RP.IdPermiso
            WHERE P.Nombre = @NombrePermiso";

            SqlParameter[] parametros = new SqlParameter[]
            {
        new SqlParameter("@NombrePermiso", nombrePermiso)
            };

            try
            {
                // Ejecutar la consulta y obtener el DataTable
                DataTable resultado = CONEXION.EjecutarDataTabla2(consulta, "PermisoRol", parametros);

                if (resultado.Rows.Count > 0)
                {
                    // Obtener los valores de bloqueo
                    bool permisoBloqueado = Convert.ToBoolean(resultado.Rows[0]["PermisoBloqueado"]);
                    bool rolPermisoBloqueado = Convert.ToBoolean(resultado.Rows[0]["RolPermisoBloqueado"]);

                    // Si el permiso o el rol permiso están bloqueados, se establece la variable
                    estaBloqueado = permisoBloqueado || rolPermisoBloqueado;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar el permiso: " + ex.Message);
            }

            return estaBloqueado;
        }

        public DataTable BuscarPermisosPorNombre(string nombrePermiso)
        {
            string consulta = @"
            SELECT * 
            FROM Permiso 
            WHERE LOWER(Nombre) LIKE '%' + LOWER(@NombrePermiso) + '%'";

            SqlParameter[] parametros = {
            new SqlParameter("@NombrePermiso", nombrePermiso)
        };

            return CONEXION.EjecutarDataTabla2(consulta, "Permiso", parametros);
        }

    }
}
