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
    public class DetalleCarritoKitBSS
    {
        DetalleCarritoKitDAL dal = new DetalleCarritoKitDAL();

        // Método para listar todos los detalles del carrito de kits
        public DataTable ListarDetalleCarritoKitBss()
        {
            return dal.ListarDetalleCarritoKitDal();
        }

        // Método para insertar un nuevo detalle de carrito de kits
        public void InsertarDetalleCarritoKitBss(DetalleCarritoKit detalle)
        {
            dal.InsertarDetalleCarritoKitDal(detalle);
        }

        // Método para obtener un detalle por su Id
        public DetalleCarritoKit ObtenerDetallePorIdBss(int id)
        {
            return dal.ObtenerDetallePorIdDal(id);
        }

        // Método para editar un detalle de carrito de kits
        public void EditarDetalleCarritoKitBss(DetalleCarritoKit detalle)
        {
            dal.EditarDetalleCarritoKitDal(detalle);
        }

        // Método para eliminar un detalle de carrito de kits
        public void EliminarDetalleCarritoKitBss(int id)
        {
            dal.EliminarDetalleCarritoKitDal(id);
        }
    }
}
