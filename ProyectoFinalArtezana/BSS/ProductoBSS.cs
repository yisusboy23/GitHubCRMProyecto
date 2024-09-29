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
    public class ProductoBSS
    {
        ProductoDAL dal = new ProductoDAL();

        public DataTable ListarProductosBss()
        {
            return dal.ListarProductosDal();
        }

        public void InsertarProductoBss(Producto producto)
        {
            dal.InsertarProductoDal(producto);
        }

        public Producto ObtenerProductoPorIdBss(int id)
        {
            return dal.ObtenerProductoPorIdDal(id);
        }

        public void EditarProductoBss(Producto producto)
        {
            dal.EditarProductoDal(producto);
        }

        public void EliminarProductoBss(int id)
        {
            dal.EliminarProductoDal(id);
        }


        // Método para obtener el nombre del producto por ID
        public string ObtenerNombreProductoPorId(int idProducto)
        {
            return dal.ObtenerNombreProductoPorId(idProducto);
        }

        public DataTable BuscarProductosPorNombre(string nombreProducto)
        {
            return dal.BuscarProductosPorNombre(nombreProducto);
        }
    }
}
