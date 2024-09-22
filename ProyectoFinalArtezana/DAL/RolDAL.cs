using MODELOS;
using System;
using System.Collections.Generic;
using System.Data;
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
            string consulta = "DELETE FROM Rol WHERE IdRol = " + id;
            CONEXION.Ejecutar(consulta);
        }
    }
}
