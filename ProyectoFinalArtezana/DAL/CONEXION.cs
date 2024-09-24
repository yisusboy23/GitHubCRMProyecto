using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class CONEXION
    {
        public static string CONECTAR
        {
            //PCA-03
            //DESKTOP-JDKQ9F6\SQLEXPRESS
            get { return @"Data Source=DESKTOP-JDKQ9F6\SQLEXPRESS; Initial Catalog=ECOLABDB; Integrated Security=True; TrustServerCertificate=true;"; }
            //get { return ConfigurationManager.ConnectionStrings["cadena"].ToString(); }
        }
        public static DataSet EjecutarDataSet(string consulta)
        {
            string p = CONEXION.CONECTAR;
            SqlConnection conectar = new SqlConnection(CONEXION.CONECTAR);
            conectar.Open();
            SqlCommand cmd = new SqlCommand(consulta, conectar);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds, "TABLA");
            return ds;
        }

        public static void Ejecutar(string consulta)
        {
            SqlConnection conectar = new SqlConnection(CONEXION.CONECTAR);
            conectar.Open();
            SqlCommand cmd = new SqlCommand(consulta, conectar);
            cmd.CommandTimeout = 5000;
            cmd.ExecuteNonQuery();
        }

        public static int EjecutarEscalar(string consulta)
        {
            SqlConnection conectar = new SqlConnection(CONEXION.CONECTAR);
            conectar.Open();

            SqlCommand cmd = new SqlCommand(consulta, conectar);
            cmd.CommandTimeout = 5000;
            int dev = Convert.ToInt32(cmd.ExecuteScalar());
            return dev;
        }
        public static DataTable EjecutarDataTabla(string consulta, string tabla)
        {
            string p = CONEXION.CONECTAR;
            SqlConnection conectar = new SqlConnection(CONEXION.CONECTAR);
            SqlCommand cmd = new SqlCommand(consulta, conectar);
            cmd.CommandTimeout = 5000;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable(tabla);
            da.Fill(dt);
            return dt;
        }

        public static DataTable EjecutarDataTabla2(string consulta, string tabla, SqlParameter[] parametros)
        {
            using (SqlConnection conectar = new SqlConnection(CONEXION.CONECTAR))
            {
                using (SqlCommand cmd = new SqlCommand(consulta, conectar))
                {
                    cmd.CommandTimeout = 5000;

                    if (parametros != null)
                    {
                        cmd.Parameters.AddRange(parametros); // Añade los parámetros a la consulta
                    }

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable(tabla);
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public static void Ejecutar2(string consulta, SqlParameter[] parametros)
        {
            using (SqlConnection conectar = new SqlConnection(CONECTAR))
            {
                using (SqlCommand cmd = new SqlCommand(consulta, conectar))
                {
                    cmd.Parameters.AddRange(parametros);
                    conectar.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
