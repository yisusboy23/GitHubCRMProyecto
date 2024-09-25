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

        public DataTable ListarCarritoBss()
        {
            return dal.ListarCarritosDal();
        }

        public void InsertarCarritoBss()
        {
            dal.InsertarCarritoDal(); // Llama al método DAL para insertar el carrito
        }

        // Método para listar carritos pendientes
        public DataTable ListarCarritoPendienteBss(int idCliente)
        {
            return dal.ListarCarritoPendienteDal(idCliente);
        }

        // Método para listar carritos completados o cancelados
        public DataTable ListarCarritoCompletadoBss(int idCliente)
        {
            return dal.ListarCarritoCompletadoDal(idCliente);
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

        public void CancelarCarritoBss(int idCarrito)
        {
            dal.CancelarCarritoDal(idCarrito);
        }
    }
}
