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
    public class KitProductoBSS
    {
        KitProductoDAL dal = new KitProductoDAL();

        public DataTable ListarKitProductosBss()
        {
            return dal.ListarKitProductosDal();
        }

        public void InsertarKitProductoBss(KitProducto kitProducto)
        {
            dal.InsertarKitProductoDal(kitProducto);
        }

        public KitProducto ObtenerKitProductoPorIdBss(int id)
        {
            return dal.ObtenerKitProductoPorIdDal(id);
        }

        public void EditarKitProductoBss(KitProducto kitProducto)
        {
            dal.EditarKitProductoDal(kitProducto);
        }

        public void EliminarKitProductoBss(int id)
        {
            dal.EliminarKitProductoDal(id);
        }
    }
}
