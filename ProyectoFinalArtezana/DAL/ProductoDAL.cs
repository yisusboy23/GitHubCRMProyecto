using MODELOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProductoDAL
    {
        public DataTable ListarProductosDal()
        {
            string consulta = "SELECT * FROM Productos";
            DataTable lista = CONEXION.EjecutarDataTabla(consulta, "tabla");
            return lista;
        }

        public void InsertarProductoDal(Producto producto)
        {
            string consulta = "INSERT INTO Productos (Nombre, Descripcion, Precio, Cantidad, Estado, Fecha) " +
                              "VALUES ('" + producto.Nombre + "', '" + producto.Descripcion + "', " +
                              producto.Precio + ", " + producto.Cantidad + ", '" + producto.Estado + "', '" + producto.Fecha + "')";
            CONEXION.Ejecutar(consulta);
        }

        public Producto ObtenerProductoPorIdDal(int id)
        {
            string consulta = "SELECT * FROM Productos WHERE Id_Producto=" + id;
            DataTable tabla = CONEXION.EjecutarDataTabla(consulta, "tabla");
            Producto p = new Producto();
            if (tabla.Rows.Count > 0)
            {
                p.IdProducto = Convert.ToInt32(tabla.Rows[0]["Id_Producto"]);
                p.Nombre = tabla.Rows[0]["Nombre"].ToString();
                p.Descripcion = tabla.Rows[0]["Descripcion"].ToString();
                p.Precio = Convert.ToDecimal(tabla.Rows[0]["Precio"]);
                p.Cantidad = Convert.ToInt32(tabla.Rows[0]["Cantidad"]);
                p.Estado = tabla.Rows[0]["Estado"].ToString();
                p.Fecha = Convert.ToDateTime(tabla.Rows[0]["Fecha"]);
            }
            return p;
        }

        public void EditarProductoDal(Producto producto)
        {
            string consulta = "UPDATE Productos SET Nombre='" + producto.Nombre + "', " +
                              "Descripcion='" + producto.Descripcion + "', " +
                              "Precio=" + producto.Precio + ", " +
                              "Cantidad=" + producto.Cantidad + ", " +
                              "Estado='" + producto.Estado + "', " +
                              "Fecha='" + producto.Fecha + "' " +
                              "WHERE Id_Producto=" + producto.IdProducto;
            CONEXION.Ejecutar(consulta);
        }

        public void EliminarProductoDal(int id)
        {
            string consulta = "DELETE FROM Productos WHERE Id_Producto=" + id;
            CONEXION.Ejecutar(consulta);
        }


        // Método para obtener el nombre del producto por ID
        public string ObtenerNombreProductoPorId(int idProducto)
        {
            string nombreProducto = string.Empty;
            string consulta = "SELECT Nombre FROM Productos WHERE Id_Producto = @IdProducto";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdProducto", idProducto)
            };

            using (SqlConnection conectar = new SqlConnection(CONEXION.CONECTAR))
            {
                conectar.Open();
                using (SqlCommand cmd = new SqlCommand(consulta, conectar))
                {
                    cmd.Parameters.AddRange(parametros);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        nombreProducto = result.ToString();
                    }
                }
            }

            return nombreProducto;
        }

    }
}
