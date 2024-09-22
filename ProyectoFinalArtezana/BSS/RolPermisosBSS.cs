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
    public class RolPermisosBSS
    {
        RolPermisoDAL dal = new RolPermisoDAL();

        public DataTable ListarRolPermisosBss()
        {
            return dal.ListarRolPermisosDal();
        }

        public void InsertarRolPermisoBss(RolPermiso rolPermiso)
        {
            dal.InsertarRolPermisoDal(rolPermiso);
        }

        public RolPermiso ObtenerRolPermisoPorIdBss(int id)
        {
            return dal.ObtenerRolPermisoPorIdDal(id);
        }

        public void EditarRolPermisoBss(RolPermiso rolPermiso)
        {
            dal.EditarRolPermisoDal(rolPermiso);
        }

        public void EliminarRolPermisoBss(int id)
        {
            dal.EliminarRolPermisoDal(id);
        }
    }
}
