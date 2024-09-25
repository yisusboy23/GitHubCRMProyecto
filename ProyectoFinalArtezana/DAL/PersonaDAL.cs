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
            // Verificar si existen registros en Cliente que referencian a esta Persona
            string verificacionConsulta = "SELECT COUNT(*) FROM Cliente WHERE IdPersona = @IdPersona";

            using (SqlConnection connection = new SqlConnection(CONEXION.CONECTAR)) // Cambiar ConnectionString por CONECTAR
            {
                SqlCommand command = new SqlCommand(verificacionConsulta, connection);
                command.Parameters.AddWithValue("@IdPersona", id);

                connection.Open();
                int conteoClientes = (int)command.ExecuteScalar();

                // Si hay clientes asociados, lanzar excepción
                if (conteoClientes > 0)
                {
                    throw new InvalidOperationException("No se puede eliminar la persona porque tiene clientes asociados.");
                }
            }

            // Proceder a eliminar la persona si no hay dependencias
            string consulta = "DELETE FROM Persona WHERE IdPersona = @IdPersona";

            using (SqlConnection connection = new SqlConnection(CONEXION.CONECTAR)) // Cambiar ConnectionString por CONECTAR
            {
                SqlCommand command = new SqlCommand(consulta, connection);
                command.Parameters.AddWithValue("@IdPersona", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }



        public Cliente InsertarPersonaYClienteDal(Persona persona, Cliente cliente)
        {
            // Insertar persona
            string consultaPersona = @"
        INSERT INTO Persona (Nombre, Apellido, Telefono, Correo, Estado) 
        VALUES (@Nombre, @Apellido, @Telefono, @Correo, 'Activo'); 
        SELECT SCOPE_IDENTITY();"; // Para obtener el último IdPersona creado

            SqlParameter[] parametrosPersona = new SqlParameter[]
            {
        new SqlParameter("@Nombre", persona.Nombre),
        new SqlParameter("@Apellido", persona.Apellido),
        new SqlParameter("@Telefono", persona.Telefono),
        new SqlParameter("@Correo", persona.Correo)
            };

            // Ejecutar la consulta e insertar la persona
            object resultadoPersona = CONEXION.EjecutarEscalar2(consultaPersona, parametrosPersona);
            int idPersona = resultadoPersona != DBNull.Value ? Convert.ToInt32(resultadoPersona) : 0;

            // Asignar el IdPersona obtenido al cliente
            cliente.IdPersona = idPersona;

            // Insertar cliente usando el IdPersona obtenido
            string consultaCliente = @"
        INSERT INTO Cliente (IdPersona, UserName, Contraseña, Bloqueado, FechaBloq) 
        VALUES (@IdPersona, @UserName, @Contraseña, @Bloqueado, @FechaBloq);
        SELECT SCOPE_IDENTITY();"; // Para obtener el último IdCliente creado

            SqlParameter[] parametrosCliente = new SqlParameter[]
            {
        new SqlParameter("@IdPersona", cliente.IdPersona),
        new SqlParameter("@UserName", cliente.UserName),
        new SqlParameter("@Contraseña", cliente.Contraseña),
        new SqlParameter("@Bloqueado", cliente.Bloqueado ? 1 : 0),
        new SqlParameter("@FechaBloq", cliente.Bloqueado ? (object)cliente.FechaBloq.Value : DBNull.Value)
            };

            // Ejecutar la consulta e insertar el cliente y obtener el IdCliente
            object resultadoCliente = CONEXION.EjecutarEscalar2(consultaCliente, parametrosCliente);
            int nuevoIdCliente = resultadoCliente != DBNull.Value ? Convert.ToInt32(resultadoCliente) : 0;

            // Crear un objeto Cliente con el nuevo IdCliente
            cliente.IdCliente = nuevoIdCliente; // Asignar el nuevo IdCliente
            return cliente; // Retornar el cliente completo con el nuevo ID
        }
    }
}
