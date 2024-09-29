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
    public class KitDAL
    {
        public DataTable ListarKitsDal()
        {
            string consulta = "SELECT * FROM Kits";
            return CONEXION.EjecutarDataTabla(consulta, "tabla");
        }

        public void InsertarKitDal(Kit kit)
        {
            string consulta = "INSERT INTO Kits (Nombre, Descripcion, Precio, Cantidad, Estado, Fecha) " +
                              "VALUES ('" + kit.Nombre + "', '" + kit.Descripcion + "', " +
                              kit.Precio + ", " + kit.Cantidad + ", '" + kit.Estado + "', '" + kit.Fecha + "')";
            CONEXION.Ejecutar(consulta);
        }

        public Kit ObtenerKitPorIdDal(int id)
        {
            string consulta = "SELECT * FROM Kits WHERE Id_Kit=" + id;
            DataTable tabla = CONEXION.EjecutarDataTabla(consulta, "tabla");
            Kit kit = new Kit();
            if (tabla.Rows.Count > 0)
            {
                kit.IdKit = Convert.ToInt32(tabla.Rows[0]["Id_Kit"]);
                kit.Nombre = tabla.Rows[0]["Nombre"].ToString();
                kit.Descripcion = tabla.Rows[0]["Descripcion"].ToString();
                kit.Precio = Convert.ToDecimal(tabla.Rows[0]["Precio"]);
                kit.Cantidad = Convert.ToInt32(tabla.Rows[0]["Cantidad"]);
                kit.Estado = tabla.Rows[0]["Estado"].ToString();
                kit.Fecha = Convert.ToDateTime(tabla.Rows[0]["Fecha"]);
            }
            return kit;
        }

        public void EditarKitDal(Kit kit)
        {
            string consulta = "UPDATE Kits SET Nombre='" + kit.Nombre + "', " +
                              "Descripcion='" + kit.Descripcion + "', " +
                              "Precio=" + kit.Precio + ", " +
                              "Cantidad=" + kit.Cantidad + ", " +
                              "Estado='" + kit.Estado + "', " +
                              "Fecha='" + kit.Fecha + "' " +
                              "WHERE Id_Kit=" + kit.IdKit;
            CONEXION.Ejecutar(consulta);
        }

        public void EliminarKitDal(int id)
        {
            string consulta = "DELETE FROM Kits WHERE Id_Kit=" + id;
            CONEXION.Ejecutar(consulta);
        }


        public string ObtenerNombreKitPorId(int idKit)
        {
            string nombreKit = string.Empty;
            string consulta = "SELECT Nombre FROM Kits WHERE Id_Kit = @IdKit";

            SqlParameter[] parametros = new SqlParameter[]
            {
            new SqlParameter("@IdKit", idKit)
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
                        nombreKit = result.ToString();
                    }
                }
            }

            return nombreKit;
        }


        public DataTable ObtenerDetallesKit(int idKit)
        {
            string consulta = @"
              SELECT 
                KP.Id_KitProducto AS IdDetalle, 
                P.Nombre AS NombreProducto, 
                KP.Cantidad, 
                P.Precio AS PrecioUnitario,
                K.Precio AS PrecioKit,
                SUM(P.Precio) OVER() AS SumaPreciosProductos
            FROM KitProductos KP
            INNER JOIN Productos P ON KP.Id_Producto = P.Id_Producto
            INNER JOIN Kits K ON KP.Id_Kit = K.Id_Kit
            WHERE KP.Id_Kit = @IdKit;";

            SqlParameter[] parametros = { new SqlParameter("@IdKit", idKit) };
            return CONEXION.EjecutarDataTabla2(consulta, "DetallesKit", parametros);
        }

        public DataTable BuscarKitsPorNombre(string nombre)
        {
            string consulta = @"
        SELECT 
            Id_Kit, Nombre, Descripcion, Precio, Cantidad, Estado, Fecha
        FROM Kits
        WHERE LOWER(Nombre) LIKE '%' + LOWER(@Nombre) + '%'";

            SqlParameter[] parametros = new SqlParameter[]
            {
            new SqlParameter("@Nombre", nombre)
            };

            return CONEXION.EjecutarDataTabla2(consulta, "Kits", parametros);
        }

    }
}
