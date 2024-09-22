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
            DataTable lista = CONEXION.EjecutarDataTabla(consulta, "tabla");
            return lista;
        }

        // Método para insertar un nuevo KitProducto
        public void InsertarKitProductoDal(KitProducto kitProducto)
        {
            string consulta = "INSERT INTO KitProductos (Id_Kit, Id_Producto, Cantidad, Fecha) " +
                              "VALUES (" + kitProducto.IdKit + ", " + kitProducto.IdProducto + ", " +
                              kitProducto.Cantidad + ", '" + kitProducto.Fecha.ToString("yyyy-MM-dd HH:mm:ss") + "')";
            CONEXION.Ejecutar(consulta);
        }

        // Método para obtener un KitProducto por su ID
        public KitProducto ObtenerKitProductoPorIdDal(int id)
        {
            string consulta = "SELECT * FROM KitProductos WHERE Id_KitProducto=" + id;
            DataTable tabla = CONEXION.EjecutarDataTabla(consulta, "tabla");
            KitProducto kp = new KitProducto();
            if (tabla.Rows.Count > 0)
            {
                kp.IdKitProducto = Convert.ToInt32(tabla.Rows[0]["Id_KitProducto"]);
                kp.IdKit = Convert.ToInt32(tabla.Rows[0]["Id_Kit"]);
                kp.IdProducto = Convert.ToInt32(tabla.Rows[0]["Id_Producto"]);
                kp.Cantidad = Convert.ToInt32(tabla.Rows[0]["Cantidad"]);
                kp.Fecha = Convert.ToDateTime(tabla.Rows[0]["Fecha"]);
            }
            return kp;
        }

        // Método para editar un KitProducto existente
        public void EditarKitProductoDal(KitProducto kitProducto)
        {
            string consulta = "UPDATE KitProductos SET Id_Kit=" + kitProducto.IdKit + ", " +
                              "Id_Producto=" + kitProducto.IdProducto + ", " +
                              "Cantidad=" + kitProducto.Cantidad + ", " +
                              "Fecha='" + kitProducto.Fecha.ToString("yyyy-MM-dd HH:mm:ss") + "' " +
                              "WHERE Id_KitProducto=" + kitProducto.IdKitProducto;
            CONEXION.Ejecutar(consulta);
        }

        // Método para eliminar un KitProducto por su ID
        public void EliminarKitProductoDal(int id)
        {
            string consulta = "DELETE FROM KitProductos WHERE Id_KitProducto=" + id;
            CONEXION.Ejecutar(consulta);
        }
    }
}
