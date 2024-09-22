using MODELOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DetalleCarritoProductoDAl
    {
        // Método para listar todos los detalles del carrito de productos
        public DataTable ListarDetalleCarritoProductoDal()
        {
            string consulta = "SELECT * FROM DetalleCarritoProducto";
            return CONEXION.EjecutarDataTabla(consulta, "DetalleCarritoProducto");
        }

        // Método para insertar un nuevo detalle del carrito
        public void InsertarDetalleCarritoProductoDal(DetalleCarritoProducto detalle)
        {
            string consulta = "INSERT INTO DetalleCarritoProducto (Id_Carrito, Id_Producto, Cantidad, Precio_Unitario, Fecha) VALUES (" +
                              detalle.IdCarrito + ", " +
                              detalle.IdProducto + ", " +
                              detalle.Cantidad + ", " +
                              detalle.PrecioUnitario + ", " +
                              "'" + detalle.Fecha.ToString("yyyy-MM-dd HH:mm:ss") + "')";

            CONEXION.Ejecutar(consulta);
        }

        // Método para obtener un detalle por su Id
        public DetalleCarritoProducto ObtenerDetallePorIdDal(int id)
        {
            string consulta = "SELECT * FROM DetalleCarritoProducto WHERE Id_DetalleCarritoP = " + id;
            DataTable tabla = CONEXION.EjecutarDataTabla(consulta, "DetalleCarritoProducto");

            DetalleCarritoProducto detalle = null;
            if (tabla.Rows.Count > 0)
            {
                detalle = new DetalleCarritoProducto
                {
                    IdDetalleCarritoP = Convert.ToInt32(tabla.Rows[0]["Id_DetalleCarritoP"]),
                    IdCarrito = Convert.ToInt32(tabla.Rows[0]["Id_Carrito"]),
                    IdProducto = Convert.ToInt32(tabla.Rows[0]["Id_Producto"]),
                    Cantidad = Convert.ToInt32(tabla.Rows[0]["Cantidad"]),
                    PrecioUnitario = Convert.ToDecimal(tabla.Rows[0]["Precio_Unitario"]),
                    Fecha = Convert.ToDateTime(tabla.Rows[0]["Fecha"])
                };
            }
            return detalle;
        }

        // Método para actualizar un detalle del carrito
        public void EditarDetalleCarritoProductoDal(DetalleCarritoProducto detalle)
        {
            string consulta = "UPDATE DetalleCarritoProducto SET " +
                              "Id_Carrito = " + detalle.IdCarrito + ", " +
                              "Id_Producto = " + detalle.IdProducto + ", " +
                              "Cantidad = " + detalle.Cantidad + ", " +
                              "Precio_Unitario = " + detalle.PrecioUnitario + ", " +
                              "Fecha = '" + detalle.Fecha.ToString("yyyy-MM-dd HH:mm:ss") + "' " +
                              "WHERE Id_DetalleCarritoP = " + detalle.IdDetalleCarritoP;

            CONEXION.Ejecutar(consulta);
        }

        // Método para eliminar un detalle del carrito
        public void EliminarDetalleCarritoProductoDal(int id)
        {
            string consulta = "DELETE FROM DetalleCarritoProducto WHERE Id_DetalleCarritoP = " + id;
            CONEXION.Ejecutar(consulta);
        }
    }
}
