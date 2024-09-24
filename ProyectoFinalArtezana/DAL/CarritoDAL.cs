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
        public DataTable ListarCarritoPendienteDal(int idCliente)
        {
            string consulta = "SELECT * FROM Carrito WHERE IdCliente = @IdCliente AND Estado = 'Pendiente'";
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdCliente", idCliente)
            };
            return EjecutarDataTabla(consulta, "Carrito", parametros);
        }

        public DataTable ListarCarritoCompletadoDal(int idCliente)
        {
            string consulta = "SELECT * FROM Carrito WHERE IdCliente = @IdCliente AND Estado IN ('Completado', 'Cancelado')";
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdCliente", idCliente)
            };
            return EjecutarDataTabla(consulta, "Carrito", parametros);
        }

        private DataTable EjecutarDataTabla(string consulta, string tabla, SqlParameter[] parametros)
        {
            using (SqlConnection conectar = new SqlConnection(CONEXION.CONECTAR))
            {
                using (SqlCommand cmd = new SqlCommand(consulta, conectar))
                {
                    cmd.Parameters.AddRange(parametros);
                    cmd.CommandTimeout = 5000;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable(tabla);
                    da.Fill(dt);
                    return dt;
                }
            }
        }



        public void InsertarCarritoDal()
        {
            string consulta = "INSERT INTO Carrito (IdCliente, Fecha, Precio_Total, Estado) VALUES (" +
                              "(SELECT MAX(IdCliente) FROM Cliente), " +
                              "DEFAULT, " + // Esto utilizará la fecha por defecto (CURRENT_TIMESTAMP)
                              "0.0, " + // PrecioTotal inicializado en 0
                              "'Pendiente')"; // Estado inicializado en 'Pendiente'

            CONEXION.Ejecutar(consulta);
        }

        // Método para obtener un carrito por su Id
        public Carrito ObtenerCarritoPorIdDal(int id)
        {
            string consulta = "SELECT * FROM Carrito WHERE Id_Carrito = " + id;
            DataTable tabla = CONEXION.EjecutarDataTabla(consulta, "Carrito");

            Carrito carrito = null;
            if (tabla.Rows.Count > 0)
            {
                carrito = new Carrito
                {
                    IdCarrito = Convert.ToInt32(tabla.Rows[0]["Id_Carrito"]),
                    IdCliente = Convert.ToInt32(tabla.Rows[0]["idCliente"]),
                    Fecha = Convert.ToDateTime(tabla.Rows[0]["Fecha"]),
                    PrecioTotal = Convert.ToDecimal(tabla.Rows[0]["Precio_Total"]),
                    Estado = tabla.Rows[0]["Estado"].ToString()
                };
            }
            return carrito;
        }

        // Método para actualizar un carrito
        public void EditarCarritoDal(Carrito carrito)
        {
            string consulta = "UPDATE Carrito SET " +
                              "idCliente = " + carrito.IdCliente + ", " +
                              "Fecha = '" + carrito.Fecha.ToString("yyyy-MM-dd HH:mm:ss") + "', " +
                              "Precio_Total = " + carrito.PrecioTotal + ", " +
                              "Estado = '" + carrito.Estado + "' " +
                              "WHERE Id_Carrito = " + carrito.IdCarrito;
            CONEXION.Ejecutar(consulta);
        }

        // Método para eliminar un carrito
        public void EliminarCarritoDal(int id)
        {
            string consulta = "DELETE FROM Carrito WHERE Id_Carrito = " + id;
            CONEXION.Ejecutar(consulta);
        }

        // Método para obtener el último carrito creado
        public int ObtenerUltimoCarritoDal()
        {
            string consulta = "SELECT MAX(Id_Carrito) FROM Carrito";
            object resultado = CONEXION.EjecutarEscalar(consulta);
            return resultado != DBNull.Value ? Convert.ToInt32(resultado) : 0;
        }


        public void CancelarCarritoDal(int idCarrito)
        {
            string consulta = "UPDATE Carrito SET Estado = 'Cancelado' WHERE Id_Carrito = @IdCarrito";
            SqlParameter[] parametros = new SqlParameter[]
            {
        new SqlParameter("@IdCarrito", idCarrito)
            };
            CONEXION.Ejecutar2(consulta, parametros);
        }
    }
}
