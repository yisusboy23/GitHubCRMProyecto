using MODELOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DetalleCarritoKitDAL
    {
        // Método para listar todos los detalles del carrito de kits
        public DataTable ListarDetalleCarritoKitDal()
        {
            string consulta = "SELECT * FROM DetalleCarritoKit";
            return CONEXION.EjecutarDataTabla(consulta, "DetalleCarritoKit");
        }

        // Método para insertar un nuevo detalle de carrito de kits
        public void InsertarDetalleCarritoKitDal(DetalleCarritoKit detalle)
        {
            string consulta = "INSERT INTO DetalleCarritoKit (IdCarrito, IdKitProducto, Cantidad, PrecioUnitario, Fecha) VALUES (" +
                              detalle.IdCarrito + ", " +
                              detalle.IdKitProducto + ", " +
                              detalle.Cantidad + ", " +
                              detalle.PrecioUnitario + ", " +
                              "'" + detalle.Fecha.ToString("yyyy-MM-dd HH:mm:ss") + "')";
            CONEXION.Ejecutar(consulta);
        }

        // Método para obtener un detalle por su Id
        public DetalleCarritoKit ObtenerDetallePorIdDal(int id)
        {
            string consulta = "SELECT * FROM DetalleCarritoKit WHERE IdDetalleCarritoK = " + id;
            DataTable tabla = CONEXION.EjecutarDataTabla(consulta, "DetalleCarritoKit");

            DetalleCarritoKit detalle = null;
            if (tabla.Rows.Count > 0)
            {
                detalle = new DetalleCarritoKit
                {
                    IdDetalleCarritoK = Convert.ToInt32(tabla.Rows[0]["IdDetalleCarritoK"]),
                    IdCarrito = Convert.ToInt32(tabla.Rows[0]["IdCarrito"]),
                    IdKitProducto = Convert.ToInt32(tabla.Rows[0]["IdKitProducto"]),
                    Cantidad = Convert.ToInt32(tabla.Rows[0]["Cantidad"]),
                    PrecioUnitario = Convert.ToDecimal(tabla.Rows[0]["PrecioUnitario"]),
                    Fecha = Convert.ToDateTime(tabla.Rows[0]["Fecha"])
                };
            }
            return detalle;
        }

        // Método para actualizar un detalle de carrito de kits
        public void EditarDetalleCarritoKitDal(DetalleCarritoKit detalle)
        {
            string consulta = "UPDATE DetalleCarritoKit SET " +
                              "IdCarrito = " + detalle.IdCarrito + ", " +
                              "IdKitProducto = " + detalle.IdKitProducto + ", " +
                              "Cantidad = " + detalle.Cantidad + ", " +
                              "PrecioUnitario = " + detalle.PrecioUnitario + ", " +
                              "Fecha = '" + detalle.Fecha.ToString("yyyy-MM-dd HH:mm:ss") + "' " +
                              "WHERE IdDetalleCarritoK = " + detalle.IdDetalleCarritoK;
            CONEXION.Ejecutar(consulta);
        }

        // Método para eliminar un detalle de carrito de kits
        public void EliminarDetalleCarritoKitDal(int id)
        {
            string consulta = "DELETE FROM DetalleCarritoKit WHERE IdDetalleCarritoK = " + id;
            CONEXION.Ejecutar(consulta);
        }
    }
}
