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
    public class UsuariosDAL
    {
        public DataTable ListarUsuariosDal()
        {
            string consulta = "SELECT * FROM Usuarios";
            return CONEXION.EjecutarDataTabla(consulta, "Usuarios");
        }

        public void InsertarUsuarioDal(Usuarios usuario)
        {
            string consulta = "INSERT INTO Usuarios (IdPersona, UserName, Contraseña, Ci, Bloqueado, FechaBloq) " +
                              "VALUES (" + usuario.IdPersona + ", '" + usuario.UserName + "', '" + usuario.Contraseña + "', '" + usuario.Ci + "', " +
                              (usuario.Bloqueado ? 1 : 0) + ", " +
                              (usuario.FechaBloq.HasValue ? "'" + usuario.FechaBloq.Value.ToString("yyyy-MM-dd HH:mm:ss") + "'" : "NULL") + ")";
            CONEXION.Ejecutar(consulta);
        }

        public Usuarios ObtenerUsuarioPorIdDal(int id)
        {
            string consulta = "SELECT * FROM Usuarios WHERE IdUsuario = " + id;
            DataTable tabla = CONEXION.EjecutarDataTabla(consulta, "Usuarios");
            Usuarios usuario = new Usuarios();

            if (tabla.Rows.Count > 0)
            {
                usuario.IdUsuario = Convert.ToInt32(tabla.Rows[0]["IdUsuario"]);
                usuario.IdPersona = Convert.ToInt32(tabla.Rows[0]["IdPersona"]);
                usuario.UserName = tabla.Rows[0]["UserName"].ToString();
                usuario.Contraseña = tabla.Rows[0]["Contraseña"].ToString();
                usuario.Ci = tabla.Rows[0]["Ci"].ToString();
                usuario.Bloqueado = Convert.ToBoolean(tabla.Rows[0]["Bloqueado"]);
                usuario.FechaBloq = tabla.Rows[0]["FechaBloq"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(tabla.Rows[0]["FechaBloq"]) : null;
            }
            return usuario;
        }

        public void EditarUsuarioDal(Usuarios usuario)
        {
            string consulta = "UPDATE Usuarios SET UserName = '" + usuario.UserName + "', " +
                              "Contraseña = '" + usuario.Contraseña + "', " +
                              "Ci = '" + usuario.Ci + "', " +
                              "Bloqueado = " + (usuario.Bloqueado ? 1 : 0) + ", " +
                              "FechaBloq = " + (usuario.FechaBloq.HasValue ? "'" + usuario.FechaBloq.Value.ToString("yyyy-MM-dd HH:mm:ss") + "'" : "NULL") + " " +
                              "WHERE IdUsuario = " + usuario.IdUsuario;
            CONEXION.Ejecutar(consulta);
        }

        public void EliminarUsuarioDal(int id)
        {
            // Verificar si existen registros en Rol que referencian a este Usuario
            string verificacionConsulta = "SELECT COUNT(*) FROM UsuarioRol WHERE IdUsuario = @IdUsuario";

            using (SqlConnection connection = new SqlConnection(CONEXION.CONECTAR))
            {
                SqlCommand command = new SqlCommand(verificacionConsulta, connection);
                command.Parameters.AddWithValue("@IdUsuario", id);

                connection.Open();
                int conteoRoles = (int)command.ExecuteScalar();

                // Si hay roles asociados, lanzar excepción
                if (conteoRoles > 0)
                {
                    throw new InvalidOperationException("No se puede eliminar el usuario porque tiene roles asociados.");
                }
            }

            // Proceder a eliminar el usuario si no hay dependencias
            string consulta = "DELETE FROM Usuarios WHERE IdUsuario = @IdUsuario";

            using (SqlConnection connection = new SqlConnection(CONEXION.CONECTAR))
            {
                SqlCommand command = new SqlCommand(consulta, connection);
                command.Parameters.AddWithValue("@IdUsuario", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }


        // Método para obtener las credenciales del usuario
        public Usuarios ObtenerCredenciales(string userName, string contraseña)
        {
            // Consulta SQL para obtener el usuario, rol, y estado de bloqueos
            string consulta = @"
            SELECT U.IdUsuario, U.UserName, U.Contraseña, UR.IdRol, U.Bloqueado AS UsuarioBloqueado, 
            UR.Bloqueado AS UsuarioRolBloqueado, R.Bloqueado AS RolBloqueado
            FROM Usuarios AS U
            INNER JOIN UsuarioRol AS UR ON U.IdUsuario = UR.IdUsuario 
            INNER JOIN Rol AS R ON UR.IdRol = R.IdRol
            WHERE U.UserName = @UserName AND U.Contraseña = @Contraseña";

            SqlParameter[] parametros = new SqlParameter[]
            {
        new SqlParameter("@UserName", userName),
        new SqlParameter("@Contraseña", contraseña)
            };

            DataTable tabla = new DataTable();
            using (SqlConnection conectar = new SqlConnection(CONEXION.CONECTAR))
            {
                conectar.Open();
                using (SqlCommand cmd = new SqlCommand(consulta, conectar))
                {
                    cmd.Parameters.AddRange(parametros);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(tabla);
                }
            }

            Usuarios usuario = null;
            if (tabla.Rows.Count > 0)
            {
                DataRow fila = tabla.Rows[0];
                usuario = new Usuarios
                {
                    IdUsuario = Convert.ToInt32(fila["IdUsuario"]),
                    UserName = fila["UserName"].ToString(),
                    Contraseña = fila["Contraseña"].ToString(),
                    IdRol = Convert.ToInt32(fila["IdRol"]),
                    Bloqueado = Convert.ToBoolean(fila["UsuarioBloqueado"]),
                    UsuarioRolBloqueado = Convert.ToBoolean(fila["UsuarioRolBloqueado"]),
                    RolBloqueado = Convert.ToBoolean(fila["RolBloqueado"])
                };

                // Registrar auditoría de inicio de sesión
                Auditoria auditoria = new Auditoria
                {
                    Accion = $"{usuario.UserName} inició sesión.",
                    Timestamp = DateTime.Now,
                    UserId = usuario.IdUsuario
                };

                AuditoriaDAL auditoriaDal = new AuditoriaDAL();
                auditoriaDal.InsertarAuditoria(auditoria);
            }

            return usuario;
        }


        public DataTable BuscarUsuariosPorUserName(string userName)
        {
            string consulta = @"
        SELECT idUsuario, UserName, ci, Bloqueado, FechaBloq
        FROM Usuarios
        WHERE LOWER(UserName) LIKE LOWER(@UserName)";

            SqlParameter[] parametros = {
        new SqlParameter("@UserName", "%" + userName + "%")
    };

            return CONEXION.EjecutarDataTabla2(consulta, "Usuarios", parametros);
        }


    }
}
