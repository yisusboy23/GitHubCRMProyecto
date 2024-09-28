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
    public class KitBSS
    {
        KitDAL dal = new KitDAL();

        public DataTable ListarKitsBss()
        {
            return dal.ListarKitsDal();
        }

        public void InsertarKitBss(Kit kit)
        {
            dal.InsertarKitDal(kit);
        }

        public Kit ObtenerKitPorIdBss(int id)
        {
            return dal.ObtenerKitPorIdDal(id);
        }

        public void EditarKitBss(Kit kit)
        {
            dal.EditarKitDal(kit);
        }

        public void EliminarKitBss(int id)
        {
            dal.EliminarKitDal(id);
        }

        // Método para obtener el nombre del kit por ID
        public string ObtenerNombreKitPorId(int idKit)
        {
            return dal.ObtenerNombreKitPorId(idKit);
        }

        public DataTable ObtenerDetallesKitBSS(int idKit)
        {
            return dal.ObtenerDetallesKit(idKit);
        }


    }
}
