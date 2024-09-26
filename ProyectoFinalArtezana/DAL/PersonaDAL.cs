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
            string consulta = "INSERT INTO Persona (nombre, apellido, telefono, correo, estado, Edad, Sexo) " +
                              "VALUES (@Nombre, @Apellido, @Telefono, @Correo, 'Activo', @Edad, @Sexo)";

            using (SqlConnection connection = new SqlConnection(CONEXION.CONECTAR))
            {
                SqlCommand command = new SqlCommand(consulta, connection);
                command.Parameters.AddWithValue("@Nombre", persona.Nombre);
                command.Parameters.AddWithValue("@Apellido", persona.Apellido);
                command.Parameters.AddWithValue("@Telefono", persona.Telefono);
                command.Parameters.AddWithValue("@Correo", persona.Correo);
                command.Parameters.AddWithValue("@Edad", (object)persona.Edad ?? DBNull.Value);
                command.Parameters.AddWithValue("@Sexo", (object)persona.Sexo ?? DBNull.Value);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public Persona ObtenerPersonaIdDal(int id)
        {
            string consulta = "SELECT * FROM Persona WHERE idPersona = @IdPersona";
            Persona persona = new Persona();

            using (SqlConnection connection = new SqlConnection(CONEXION.CONECTAR))
            {
                SqlCommand command = new SqlCommand(consulta, connection);
                command.Parameters.AddWithValue("@IdPersona", id);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        persona.IdPersona = Convert.ToInt32(reader["idPersona"]);
                        persona.Nombre = reader["nombre"].ToString();
                        persona.Apellido = reader["apellido"].ToString();
                        persona.Telefono = reader["telefono"].ToString();
                        persona.Correo = reader["correo"].ToString();
                        persona.Estado = reader["estado"].ToString();
                        persona.Edad = reader["Edad"] != DBNull.Value ? (int?)Convert.ToInt32(reader["Edad"]) : null;
                        persona.Sexo = reader["Sexo"] != DBNull.Value ? reader["Sexo"].ToString() : null;
                    }
                }
            }

            return persona;
        }

        public void EditarPersonaDal(Persona persona)
        {
            string consulta = "UPDATE Persona SET nombre=@Nombre, apellido=@Apellido, " +
                              "telefono=@Telefono, correo=@Correo, estado=@Estado, " +
                              "Edad=@Edad, Sexo=@Sexo " +
                              "WHERE idPersona=@IdPersona";

            using (SqlConnection connection = new SqlConnection(CONEXION.CONECTAR))
            {
                SqlCommand command = new SqlCommand(consulta, connection);
                command.Parameters.AddWithValue("@Nombre", persona.Nombre);
                command.Parameters.AddWithValue("@Apellido", persona.Apellido);
                command.Parameters.AddWithValue("@Telefono", persona.Telefono);
                command.Parameters.AddWithValue("@Correo", persona.Correo);
                command.Parameters.AddWithValue("@Estado", persona.Estado);
                command.Parameters.AddWithValue("@Edad", (object)persona.Edad ?? DBNull.Value);
                command.Parameters.AddWithValue("@Sexo", (object)persona.Sexo ?? DBNull.Value);
                command.Parameters.AddWithValue("@IdPersona", persona.IdPersona);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void EliminarPersonaDal(int id)
        {
            // Verificar si existen registros en Cliente que referencian a esta Persona
            string verificacionConsulta = "SELECT COUNT(*) FROM Cliente WHERE idPersona = @idPersona";

            using (SqlConnection connection = new SqlConnection(CONEXION.CONECTAR))
            {
                SqlCommand command = new SqlCommand(verificacionConsulta, connection);
                command.Parameters.AddWithValue("@idPersona", id);

                connection.Open();
                int conteoClientes = (int)command.ExecuteScalar();

                // Si hay clientes asociados, lanzar excepción
                if (conteoClientes > 0)
                {
                    throw new InvalidOperationException("No se puede eliminar la persona porque tiene clientes asociados.");
                }
            }

            // Proceder a eliminar la persona si no hay dependencias
            string consulta = "DELETE FROM Persona WHERE idPersona = @idPersona";

            using (SqlConnection connection = new SqlConnection(CONEXION.CONECTAR))
            {
                SqlCommand command = new SqlCommand(consulta, connection);
                command.Parameters.AddWithValue("@idPersona", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public Cliente InsertarPersonaYClienteDal(Persona persona, Cliente cliente)
        {
            // Insertar persona con los nuevos parámetros
            string consultaPersona = @"
    INSERT INTO Persona (Nombre, Apellido, Telefono, Correo, Estado, Edad, Sexo) 
    VALUES (@Nombre, @Apellido, @Telefono, @Correo, 'Activo', @Edad, @Sexo); 
    SELECT SCOPE_IDENTITY();"; // Para obtener el último IdPersona creado

            SqlParameter[] parametrosPersona = new SqlParameter[]
            {
        new SqlParameter("@Nombre", persona.Nombre),
        new SqlParameter("@Apellido", persona.Apellido),
        new SqlParameter("@Telefono", persona.Telefono),
        new SqlParameter("@Correo", persona.Correo),
        new SqlParameter("@Edad", persona.Edad), // Nuevo parámetro para Edad
        new SqlParameter("@Sexo", persona.Sexo)  // Nuevo parámetro para Sexo
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
