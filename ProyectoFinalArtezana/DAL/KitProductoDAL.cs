using MODELOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class KitProductoDAL
    {
  public DataTable ListarKitProductosDal()
        {
            string consulta = "SELECT * FROM KitProductos";
            return CONEXION.EjecutarDataTabla(consulta, "KitProductos");
        }

        public void InsertarKitProductoDal(KitProducto kitProducto)
        {
            string consulta = "INSERT INTO KitProductos (Id_Kit, Id_Producto, Cantidad, Fecha) " +
                              "VALUES (" + kitProducto.IdKit + ", " + kitProducto.IdProducto + ", " +
                              kitProducto.Cantidad + ", '" + kitProducto.Fecha.ToString("yyyy-MM-dd HH:mm:ss") + "')";
            CONEXION.Ejecutar(consulta);
        }

        public KitProducto ObtenerKitProductoPorIdDal(int id)
        {
            string consulta = "SELECT * FROM KitProductos WHERE Id_KitProducto = " + id;
            DataTable tabla = CONEXION.EjecutarDataTabla(consulta, "KitProductos");
            KitProducto kitProducto = new KitProducto();

            if (tabla.Rows.Count > 0)
            {
                kitProducto.IdKitProducto = Convert.ToInt32(tabla.Rows[0]["Id_KitProducto"]);
                kitProducto.IdKit = Convert.ToInt32(tabla.Rows[0]["Id_Kit"]);
                kitProducto.IdProducto = Convert.ToInt32(tabla.Rows[0]["Id_Producto"]);
                kitProducto.Cantidad = Convert.ToInt32(tabla.Rows[0]["Cantidad"]);
                kitProducto.Fecha = Convert.ToDateTime(tabla.Rows[0]["Fecha"]);
            }
            return kitProducto;
        }

        public void EditarKitProductoDal(KitProducto kitProducto)
        {
            string consulta = "UPDATE KitProductos SET Id_Kit = " + kitProducto.IdKit + ", " +
                              "Id_Producto = " + kitProducto.IdProducto + ", " +
                              "Cantidad = " + kitProducto.Cantidad + ", " +
                              "Fecha = '" + kitProducto.Fecha.ToString("yyyy-MM-dd HH:mm:ss") + "' " +
                              "WHERE Id_KitProducto = " + kitProducto.IdKitProducto;
            CONEXION.Ejecutar(consulta);
        }

        public void EliminarKitProductoDal(int id)
        {
            string consulta = "DELETE FROM KitProductos WHERE Id_KitProducto = " + id;
            CONEXION.Ejecutar(consulta);
        }
    }
}
