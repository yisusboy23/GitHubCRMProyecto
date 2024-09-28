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
    public class RolBSS
    {
        RolDAL rolDAL = new RolDAL();

        public DataTable ListarRolesBss()
        {
            return rolDAL.ListarRolesDal();
        }

        public void InsertarRolBss(Rol rol)
        {
            rolDAL.InsertarRolDal(rol);
        }

        public Rol ObtenerRolPorIdBss(int id)
        {
            return rolDAL.ObtenerRolPorIdDal(id);
        }

        public void EditarRolBss(Rol rol)
        {
            rolDAL.EditarRolDal(rol);
        }

        public void EliminarRolBss(int id)
        {
            rolDAL.EliminarRolDal(id);
        }

        public DataTable ObtenerUsuariosPorRol(int idRol)
        {
            return rolDAL.ObtenerUsuariosPorRol(idRol);
        }

        public DataTable ObtenerPermisosPorRol(int idRol)
        {
            return rolDAL.ObtenerPermisosPorRol(idRol);
        }
    }
}
