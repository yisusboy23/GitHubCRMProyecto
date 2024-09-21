using MODELOS;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSS
{
    public class UsuarioBSS
    {
        UsuariosDAL dal = new UsuariosDAL();

        public DataTable ListarUsuariosBss()
        {
            return dal.ListarUsuariosDal();
        }

        public void InsertarUsuarioBss(Usuarios usuario)
        {
            dal.InsertarUsuarioDal(usuario);
        }

        public Usuarios ObtenerUsuarioPorIdBss(int id)
        {
            return dal.ObtenerUsuarioPorIdDal(id);
        }

        public void EditarUsuarioBss(Usuarios usuario)
        {
            dal.EditarUsuarioDal(usuario);
        }

        public void EliminarUsuarioBss(int id)
        {
            dal.EliminarUsuarioDal(id);
        }
    }
}
