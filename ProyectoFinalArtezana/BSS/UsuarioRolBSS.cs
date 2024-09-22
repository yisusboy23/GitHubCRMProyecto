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
    public class UsuarioRolBSS
    {
        private UsuarioRolDAL usuarioRolDAL = new UsuarioRolDAL();

        public DataTable ListarUsuarioRolesBss()
        {
            return usuarioRolDAL.ListarUsuarioRolesDal();
        }

        public void InsertarUsuarioRolBss(UsuarioRol usuarioRol)
        {
            usuarioRolDAL.InsertarUsuarioRolDal(usuarioRol);
        }

        public UsuarioRol ObtenerUsuarioRolPorIdBss(int id)
        {
            return usuarioRolDAL.ObtenerUsuarioRolPorIdDal(id);
        }

        public void EditarUsuarioRolBss(UsuarioRol usuarioRol)
        {
            usuarioRolDAL.EditarUsuarioRolDal(usuarioRol);
        }

        public void EliminarUsuarioRolBss(int id)
        {
            usuarioRolDAL.EliminarUsuarioRolDal(id);
        }

        public DataTable ObtenerUsuariosBss()
        {
            return usuarioRolDAL.ObtenerUsuariosDal();
        }

        public DataTable ObtenerRolesBss()
        {
            return usuarioRolDAL.ObtenerRolesDal();
        }
    }
}
