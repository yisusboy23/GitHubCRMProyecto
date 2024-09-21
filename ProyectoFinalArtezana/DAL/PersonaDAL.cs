using MODELOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PersonaDAL
    {
        public DataTable ListarPersonasDal()
        {
            string consulta = "SELECT * FROM Persona";
            DataTable lista = CONEXION.EjecutarDataTabla(consulta, "Personas");
            return lista;
        }

        public void InsertarPersonaDal(Persona persona)
        {
            string consulta = "INSERT INTO Persona (Nombre, Apellido, Telefono, Correo, Estado) " +
                              "VALUES ('" + persona.Nombre + "', '" + persona.Apellido + "', '" + persona.Telefono + "', '" + persona.Correo + "', 'Activo')";
            CONEXION.Ejecutar(consulta);
        }

        public Persona ObtenerPersonaIdDal(int id)
        {
            string consulta = "SELECT * FROM Persona WHERE IdPersona = " + id;
            DataTable tabla = CONEXION.EjecutarDataTabla(consulta, "Persona");
            Persona persona = new Persona();

            if (tabla.Rows.Count > 0)
            {
                persona.IdPersona = Convert.ToInt32(tabla.Rows[0]["IdPersona"]);
                persona.Nombre = tabla.Rows[0]["Nombre"].ToString();
                persona.Apellido = tabla.Rows[0]["Apellido"].ToString();
                persona.Telefono = tabla.Rows[0]["Telefono"].ToString();
                persona.Correo = tabla.Rows[0]["Correo"].ToString();
                persona.Estado = tabla.Rows[0]["Estado"].ToString();
            }

            return persona;
        }

        public void EditarPersonaDal(Persona persona)
        {
            string consulta = "UPDATE Persona SET Nombre='" + persona.Nombre + "', Apellido='" + persona.Apellido + "', " +
                              "Telefono='" + persona.Telefono + "', Correo='" + persona.Correo + "', Estado='" + persona.Estado + "' " +
                              "WHERE IdPersona=" + persona.IdPersona;
            CONEXION.Ejecutar(consulta);
        }

        public void EliminarPersonaDal(int id)
        {
            string consulta = "DELETE FROM Persona WHERE IdPersona=" + id;
            CONEXION.Ejecutar(consulta);
        }
    }
}
