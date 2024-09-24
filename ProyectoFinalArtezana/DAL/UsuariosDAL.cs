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
            string consulta = "DELETE FROM Usuarios WHERE IdUsuario = " + id;
            CONEXION.Ejecutar(consulta);
        }

        // Método para obtener las credenciales del usuario
        // Método para obtener las credenciales del usuario
        public Usuarios ObtenerCredenciales(string userName, string contraseña)
        {
            // Consulta SQL para obtener el usuario junto con su rol y si está bloqueado
            string consulta = @"
    SELECT U.IdUsuario, U.UserName, U.Contraseña, UR.IdRol, U.Bloqueado 
    FROM Usuarios AS U
    INNER JOIN UsuarioRol AS UR ON U.IdUsuario = UR.IdUsuario 
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
                    Bloqueado = Convert.ToBoolean(fila["Bloqueado"]) // Se mantiene la asignación
                };
            }

            // Considerar que Bloqueado es true (1) si el usuario está bloqueado
            if (usuario != null && usuario.Bloqueado) // Si el usuario está bloqueado
            {
                usuario = null; // Devolvemos null para indicar que el inicio de sesión no debe continuar
            }

            return usuario; // Devuelve null si está bloqueado o el usuario si está activo
        }
    }
}
