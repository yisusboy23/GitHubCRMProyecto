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

        public DataTable BuscarProductosPorNombre(string nombreProducto)
        {
            string consulta = @"
            SELECT * 
            FROM Productos 
            WHERE LOWER(Nombre) LIKE '%' + LOWER(@NombreProducto) + '%'";

            SqlParameter[] parametros = {
            new SqlParameter("@NombreProducto", nombreProducto)
        };

            return CONEXION.EjecutarDataTabla2(consulta, "Productos", parametros);
        }
        // Método para filtrar productos más vendidos por rango de fechas
        public DataTable FiltrarProductosMasVendidos(DateTime? fechaInicio, DateTime? fechaFin, string nombreProducto = null)
        {
            string consulta = @"
            SELECT 
                P.Nombre AS NombreProducto,
                SUM(DCP.Cantidad) AS TotalVendidos
            FROM 
                DetalleCarritoProducto DCP
            INNER JOIN 
                Productos P ON DCP.Id_Producto = P.Id_Producto
            INNER JOIN 
                Carrito C ON DCP.Id_Carrito = C.Id_Carrito
            WHERE 
                1=1"; // Base para agregar condiciones

            List<SqlParameter> parametros = new List<SqlParameter>();

            // Filtros para rango de fechas
            if (fechaInicio.HasValue)
            {
                consulta += " AND C.Fecha >= @FechaInicio";
                parametros.Add(new SqlParameter("@FechaInicio", fechaInicio.Value));
            }

            if (fechaFin.HasValue)
            {
                consulta += " AND C.Fecha <= @FechaFin";
                parametros.Add(new SqlParameter("@FechaFin", fechaFin.Value));
            }

            // Filtro para nombre del producto
            if (!string.IsNullOrEmpty(nombreProducto))
            {
                consulta += " AND P.Nombre LIKE '%' + @NombreProducto + '%'";
                parametros.Add(new SqlParameter("@NombreProducto", nombreProducto));
            }

            consulta += @"
            GROUP BY 
                P.Nombre
            ORDER BY 
                TotalVendidos DESC"; // Ordenar por cantidad vendida

            // Ejecutar la consulta y devolver el resultado como DataTable
            return CONEXION.EjecutarDataTabla2(consulta, "ProductosMasVendidos", parametros.ToArray());
        }
    }
}

