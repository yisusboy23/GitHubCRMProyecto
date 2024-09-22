using MODELOS;
using System;
using System.Collections.Generic;
using System.Data;
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
            string consulta = "DELETE FROM Permiso WHERE IdPermiso = " + id;
            CONEXION.Ejecutar(consulta);
        }
    }
}
