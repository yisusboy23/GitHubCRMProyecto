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
    public class RolDAL
    {
        public DataTable ListarRolesDal()
        {
            string consulta = "SELECT * FROM Rol";
            return CONEXION.EjecutarDataTabla(consulta, "Rol");
        }

        public void InsertarRolDal(Rol rol)
        {
            string consulta = "INSERT INTO Rol (NombreRol, Descripcion, Bloqueado, FechaBloq) " +
                              "VALUES ('" + rol.NombreRol + "', '" + rol.Descripcion + "', " +
                              (rol.Bloqueado ? 1 : 0) + ", " +
                              (rol.FechaBloq.HasValue ? "'" + rol.FechaBloq.Value.ToString("yyyy-MM-dd HH:mm:ss") + "'" : "NULL") + ")";
            CONEXION.Ejecutar(consulta);
        }

        public Rol ObtenerRolPorIdDal(int id)
        {
            string consulta = "SELECT * FROM Rol WHERE IdRol = " + id;
            DataTable tabla = CONEXION.EjecutarDataTabla(consulta, "Rol");
            Rol rol = new Rol();

            if (tabla.Rows.Count > 0)
            {
                rol.IdRol = Convert.ToInt32(tabla.Rows[0]["IdRol"]);
                rol.NombreRol = tabla.Rows[0]["NombreRol"].ToString();
                rol.Descripcion = tabla.Rows[0]["Descripcion"].ToString();
                rol.Bloqueado = Convert.ToBoolean(tabla.Rows[0]["Bloqueado"]);
                rol.FechaBloq = tabla.Rows[0]["FechaBloq"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(tabla.Rows[0]["FechaBloq"]) : null;
            }
            return rol;
        }

        public void EditarRolDal(Rol rol)
        {
            string consulta = "UPDATE Rol SET NombreRol = '" + rol.NombreRol + "', " +
                              "Descripcion = '" + rol.Descripcion + "', " +
                              "Bloqueado = " + (rol.Bloqueado ? 1 : 0) + ", " +
                              "FechaBloq = " + (rol.FechaBloq.HasValue ? "'" + rol.FechaBloq.Value.ToString("yyyy-MM-dd HH:mm:ss") + "'" : "NULL") + " " +
                              "WHERE IdRol = " + rol.IdRol;
            CONEXION.Ejecutar(consulta);
        }

        public void EliminarRolDal(int id)
        {
            // Verificar si existen registros en UsuarioRol que referencian a este Rol
            string verificacionUsuarioRolConsulta = "SELECT COUNT(*) FROM UsuarioRol WHERE IdRol = @IdRol";
            string verificacionRolPermisoConsulta = "SELECT COUNT(*) FROM RolPermiso WHERE IdRol = @IdRol";

            using (SqlConnection connection = new SqlConnection(CONEXION.CONECTAR)) // Cambiar ConnectionString por CONECTAR
            {
                // Verificación en UsuarioRol
                SqlCommand command = new SqlCommand(verificacionUsuarioRolConsulta, connection);
                command.Parameters.AddWithValue("@IdRol", id);

                connection.Open();
                int conteoUsuarioRol = (int)command.ExecuteScalar();

                // Si hay usuarios asociados, lanzar excepción
                if (conteoUsuarioRol > 0)
                {
                    throw new InvalidOperationException("No se puede eliminar el rol porque tiene usuarios asociados.");
                }

                // Verificación en RolPermiso
                command.CommandText = verificacionRolPermisoConsulta;
                int conteoRolPermiso = (int)command.ExecuteScalar();

                // Si hay permisos asociados, lanzar excepción
                if (conteoRolPermiso > 0)
                {
                    throw new InvalidOperationException("No se puede eliminar el rol porque tiene permisos asociados.");
                }
            }

            // Proceder a eliminar el rol si no hay dependencias
            string consulta = "DELETE FROM Rol WHERE IdRol = @IdRol";

            using (SqlConnection connection = new SqlConnection(CONEXION.CONECTAR)) // Cambiar ConnectionString por CONECTAR
            {
                SqlCommand command = new SqlCommand(consulta, connection);
                command.Parameters.AddWithValue("@IdRol", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Método para obtener la lista de usuarios asociados a un rol específico
        public DataTable ObtenerUsuariosPorRol(int idRol)
        {
            string consulta = @"SELECT U.IdUsuario, U.UserName   
                            FROM Usuarios U
                            INNER JOIN UsuarioRol UR ON U.IdUsuario = UR.IdUsuario
                            WHERE UR.IdRol = @IdRol";

            SqlParameter[] parametros = {
                new SqlParameter("@IdRol", idRol)
            };

            return CONEXION.EjecutarDataTabla2(consulta, "UsuariosRol", parametros);
        }

        // Método para obtener los permisos asociados a un rol
        public DataTable ObtenerPermisosPorRol(int idRol)
        {
            string consulta = @"SELECT P.IdPermiso, 
                            P.Nombre, 
                            RP.Descripcion, 
                            RP.Bloqueado, 
                            RP.FechaBloq 
                     FROM Permiso P
                     INNER JOIN RolPermiso RP ON P.IdPermiso = RP.IdPermiso
                     WHERE RP.IdRol = @IdRol";

            SqlParameter[] parametros = {
                new SqlParameter("@IdRol", idRol)
            };

            return CONEXION.EjecutarDataTabla2(consulta, "PermisosRol", parametros);
        }

    }
}
