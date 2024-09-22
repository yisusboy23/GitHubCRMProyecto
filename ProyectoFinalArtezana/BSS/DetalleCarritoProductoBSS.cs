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
    public class DetalleCarritoProductoBSS
    {
        DetalleCarritoProductoDAl dal = new DetalleCarritoProductoDAl();

        // Método para listar todos los detalles del carrito de productos
        public DataTable ListarDetalleCarritoProductoBss()
        {
            return dal.ListarDetalleCarritoProductoDal();
        }

        // Método para insertar un nuevo detalle del carrito
        public void InsertarDetalleCarritoProductoBss(DetalleCarritoProducto detalle)
        {
            dal.InsertarDetalleCarritoProductoDal(detalle);
        }

        // Método para obtener un detalle por su Id
        public DetalleCarritoProducto ObtenerDetallePorIdBss(int id)
        {
            return dal.ObtenerDetallePorIdDal(id);
        }

        // Método para editar un detalle del carrito
        public void EditarDetalleCarritoProductoBss(DetalleCarritoProducto detalle)
        {
            dal.EditarDetalleCarritoProductoDal(detalle);
        }

        // Método para eliminar un detalle del carrito
        public void EliminarDetalleCarritoProductoBss(int id)
        {
            dal.EliminarDetalleCarritoProductoDal(id);
        }
    }
}
