using MODELOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UsuarioRolDAL
    {
        public DataTable ListarUsuarioRolesDal()
        {
            string consulta = "SELECT * FROM UsuarioRol";
            return CONEXION.EjecutarDataTabla(consulta, "UsuarioRol");
        }

        public void InsertarUsuarioRolDal(UsuarioRol usuarioRol)
        {
            string consulta = "INSERT INTO UsuarioRol (IdUsuario, IdRol, FechaAsignacion, Bloqueado, FechaBloq) " +
                              "VALUES (" + usuarioRol.IdUsuario + ", " + usuarioRol.IdRol + ", '" +
                              usuarioRol.FechaAsignacion.ToString("yyyy-MM-dd HH:mm:ss") + "', " +
                              (usuarioRol.Bloqueado ? 1 : 0) + ", " +
                              (usuarioRol.FechaBloq.HasValue ? "'" + usuarioRol.FechaBloq.Value.ToString("yyyy-MM-dd HH:mm:ss") + "'" : "NULL") + ")";
            CONEXION.Ejecutar(consulta);
        }

        public UsuarioRol ObtenerUsuarioRolPorIdDal(int id)
        {
            string consulta = "SELECT * FROM UsuarioRol WHERE IdUsuarioRol = " + id;
            DataTable tabla = CONEXION.EjecutarDataTabla(consulta, "UsuarioRol");
            UsuarioRol usuarioRol = new UsuarioRol();

            if (tabla.Rows.Count > 0)
            {
                usuarioRol.IdUsuarioRol = Convert.ToInt32(tabla.Rows[0]["IdUsuarioRol"]);
                usuarioRol.IdUsuario = Convert.ToInt32(tabla.Rows[0]["IdUsuario"]);
                usuarioRol.IdRol = Convert.ToInt32(tabla.Rows[0]["IdRol"]);
                usuarioRol.FechaAsignacion = Convert.ToDateTime(tabla.Rows[0]["FechaAsignacion"]);
                usuarioRol.Bloqueado = Convert.ToBoolean(tabla.Rows[0]["Bloqueado"]);
                usuarioRol.FechaBloq = tabla.Rows[0]["FechaBloq"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(tabla.Rows[0]["FechaBloq"]) : null;
            }
            return usuarioRol;
        }

        public void EditarUsuarioRolDal(UsuarioRol usuarioRol)
        {
            string consulta = "UPDATE UsuarioRol SET IdUsuario = " + usuarioRol.IdUsuario + ", " +
                              "IdRol = " + usuarioRol.IdRol + ", " +
                              "Bloqueado = " + (usuarioRol.Bloqueado ? 1 : 0) + ", " +
                              "FechaBloq = " + (usuarioRol.FechaBloq.HasValue ? "'" + usuarioRol.FechaBloq.Value.ToString("yyyy-MM-dd HH:mm:ss") + "'" : "NULL") + " " +
                              "WHERE IdUsuarioRol = " + usuarioRol.IdUsuarioRol;
            CONEXION.Ejecutar(consulta);
        }

        public void EliminarUsuarioRolDal(int id)
        {
            string consulta = "DELETE FROM UsuarioRol WHERE IdUsuarioRol = " + id;
            CONEXION.Ejecutar(consulta);
        }

        public DataTable ObtenerUsuariosDal()
        {
            string consulta = "SELECT IdUsuario, UserName FROM Usuarios"; // Asegúrate de que 'UserName' o el campo que desees esté en la tabla
            return CONEXION.EjecutarDataTabla(consulta, "Usuarios");
        }

        public DataTable ObtenerRolesDal()
        {
            string consulta = "SELECT IdRol, NombreRol FROM Rol"; // Asegúrate de que 'NombreRol' o el campo que desees esté en la tabla
            return CONEXION.EjecutarDataTabla(consulta, "Rol");
        }
    }
}
