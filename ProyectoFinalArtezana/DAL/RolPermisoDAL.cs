using MODELOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RolPermisoDAL
    {
        public DataTable ListarRolPermisosDal()
        {
            string consulta = "SELECT * FROM RolPermiso";
            DataTable lista = CONEXION.EjecutarDataTabla(consulta, "tabla");
            return lista;
        }

        public void InsertarRolPermisoDal(RolPermiso rolPermiso)
        {
            string consulta = "INSERT INTO RolPermiso (IdRol, IdPermiso, Descripcion, FechaAsignacion, Bloqueado, FechaBloq) " +
                              "VALUES (" + rolPermiso.IdRol + ", " + rolPermiso.IdPermiso + ", '" + rolPermiso.Descripcion + "', " +
                              "GETDATE(), " + (rolPermiso.Bloqueado ? 1 : 0) + ", " + (rolPermiso.FechaBloq.HasValue ? "'" + rolPermiso.FechaBloq.Value.ToString("yyyy-MM-dd") + "'" : "NULL") + ")";
            CONEXION.Ejecutar(consulta);
        }

        public RolPermiso ObtenerRolPermisoPorIdDal(int idRolPermiso)
        {
            string consulta = "SELECT * FROM RolPermiso WHERE IdRolPermiso=" + idRolPermiso;
            DataTable tabla = CONEXION.EjecutarDataTabla(consulta, "tabla");
            RolPermiso rp = new RolPermiso();
            if (tabla.Rows.Count > 0)
            {
                rp.IdRolPermiso = Convert.ToInt32(tabla.Rows[0]["IdRolPermiso"]);
                rp.IdRol = Convert.ToInt32(tabla.Rows[0]["IdRol"]);
                rp.IdPermiso = Convert.ToInt32(tabla.Rows[0]["IdPermiso"]);
                rp.Descripcion = tabla.Rows[0]["Descripcion"].ToString();
                rp.FechaAsignacion = Convert.ToDateTime(tabla.Rows[0]["FechaAsignacion"]);
                rp.Bloqueado = Convert.ToBoolean(tabla.Rows[0]["Bloqueado"]);
                rp.FechaBloq = tabla.Rows[0]["FechaBloq"] as DateTime?;
            }
            return rp;
        }

        public void EditarRolPermisoDal(RolPermiso rolPermiso)
        {
            string consulta = "UPDATE RolPermiso SET IdRol=" + rolPermiso.IdRol + ", " +
                              "IdPermiso=" + rolPermiso.IdPermiso + ", " +
                              "Descripcion='" + rolPermiso.Descripcion + "', " +
                              "Bloqueado=" + (rolPermiso.Bloqueado ? 1 : 0) + ", " +
                              "FechaBloq=" + (rolPermiso.FechaBloq.HasValue ? "'" + rolPermiso.FechaBloq.Value.ToString("yyyy-MM-dd") + "'" : "NULL") + " " +
                              "WHERE IdRolPermiso=" + rolPermiso.IdRolPermiso;
            CONEXION.Ejecutar(consulta);
        }

        public void EliminarRolPermisoDal(int idRolPermiso)
        {
            string consulta = "DELETE FROM RolPermiso WHERE IdRolPermiso=" + idRolPermiso;
            CONEXION.Ejecutar(consulta);
        }
    }
}
