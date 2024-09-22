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
    public class CarritoBSS
    {
        CarritoDAL dal = new CarritoDAL();

        public void InsertarCarritoBss(Carrito carrito)
        {
            dal.InsertarCarritoDal(carrito);
        }

        public DataTable ListarCarritosBss()
        {
            return dal.ListarCarritosDal();
        }

        public Carrito ObtenerCarritoPorIdBss(int id)
        {
            return dal.ObtenerCarritoPorIdDal(id);
        }

        public void EditarCarritoBss(Carrito carrito)
        {
            dal.EditarCarritoDal(carrito);
        }

        public void EliminarCarritoBss(int id)
        {
            dal.EliminarCarritoDal(id);
        }
    }
}
