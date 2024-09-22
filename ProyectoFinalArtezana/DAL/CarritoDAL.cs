using MODELOS;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CarritoDAL
    {
        public void InsertarCarritoDal(Carrito carrito)
        {
            string consulta = "INSERT INTO Carrito (IdCliente, Fecha, PrecioTotal) VALUES (" +
                              carrito.IdCliente + ", '" + carrito.Fecha.ToString("yyyy-MM-dd") + "', " +
                              carrito.PrecioTotal + ")";
            CONEXION.Ejecutar(consulta);
        }

        public DataTable ListarCarritosDal()
        {
            string consulta = "SELECT * FROM Carrito";
            return CONEXION.EjecutarDataTabla(consulta, "Carritos");
        }

        public Carrito ObtenerCarritoPorIdDal(int id)
        {
            string consulta = "SELECT * FROM Carrito WHERE IdCarrito = " + id;
            DataTable tabla = CONEXION.EjecutarDataTabla(consulta, "Carrito");
            Carrito carrito = new Carrito();
            if (tabla.Rows.Count > 0)
            {
                carrito.IdCarrito = Convert.ToInt32(tabla.Rows[0]["IdCarrito"]);
                carrito.IdCliente = Convert.ToInt32(tabla.Rows[0]["IdCliente"]);
                carrito.Fecha = Convert.ToDateTime(tabla.Rows[0]["Fecha"]);
                carrito.PrecioTotal = Convert.ToDecimal(tabla.Rows[0]["PrecioTotal"]);
            }
            return carrito;
        }

        public void EditarCarritoDal(Carrito carrito)
        {
            string consulta = "UPDATE Carrito SET IdCliente = " + carrito.IdCliente +
                              ", Fecha = '" + carrito.Fecha.ToString("yyyy-MM-dd") +
                              "', PrecioTotal = " + carrito.PrecioTotal +
                              " WHERE IdCarrito = " + carrito.IdCarrito;
            CONEXION.Ejecutar(consulta);
        }

        public void EliminarCarritoDal(int id)
        {
            string consulta = "DELETE FROM Carrito WHERE IdCarrito = " + id;
            CONEXION.Ejecutar(consulta);
        }
    }
}
