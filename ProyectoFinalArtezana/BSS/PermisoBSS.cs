using DAL;
using MODELOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSS
{
    public class PermisoBSS
    {
        PermisoDAL dal = new PermisoDAL();

        public DataTable ListarPermisosBss()
        {
            return dal.ListarPermisosDal();
        }

        public void InsertarPermisoBss(Permiso permiso)
        {
            dal.InsertarPermisoDal(permiso);
        }

        public Permiso ObtenerPermisoPorIdBss(int id)
        {
            return dal.ObtenerPermisoPorIdDal(id);
        }

        public void EditarPermisoBss(Permiso permiso)
        {
            dal.EditarPermisoDal(permiso);
        }

        public void EliminarPermisoBss(int id)
        {
            dal.EliminarPermisoDal(id);
        }

        public bool VerificarPermisoBloqueoBss(string nombrePermiso)
        {
            // Llamar al método en la DAL para verificar el estado del permiso
            return dal.VerificarPermisoBloqueoDAL(nombrePermiso);
        }

        public DataTable BuscarPermisosPorNombre(string nombrePermiso)
        {
            return dal.BuscarPermisosPorNombre(nombrePermiso);
        }

    }
}
