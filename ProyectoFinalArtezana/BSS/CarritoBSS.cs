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

        public void InsertarCarritoBss()
        {
            dal.InsertarCarritoDal(); // Llama al método DAL para insertar el carrito
        }

        public DataTable ListarCarritosBss()
        {
            return dal.ListarCarritoDal();
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

        public int ObtenerUltimoCarritoBss()
        {
            return dal.ObtenerUltimoCarritoDal();
        }
    }
}
