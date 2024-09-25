﻿using MODELOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ClienteDAL
    {
        // Listar clientes
        public DataTable ListarClientesDal()
        {
            string consulta = "SELECT * FROM Cliente";
            return CONEXION.EjecutarDataTabla(consulta, "tablaClientes");
        }

        // Insertar cliente
        public void InsertarClienteDal(Cliente cliente)
        {
            string consulta = "INSERT INTO Cliente (IdPersona, UserName, Contraseña, Bloqueado, FechaBloq) " +
                              "VALUES (" + cliente.IdPersona + ", '" + cliente.UserName + "', '" + cliente.Contraseña + "', " +
                              (cliente.Bloqueado ? 1 : 0) + ", " + (cliente.Bloqueado ? "'" + cliente.FechaBloq.Value.ToString("yyyy-MM-dd HH:mm:ss") + "'" : "NULL") + ")";
            CONEXION.Ejecutar(consulta);
        }

        // Obtener cliente por ID
        public Cliente ObtenerClientePorIdDal(int id)
        {
            string consulta = "SELECT * FROM Cliente WHERE IdCliente = " + id;
            DataTable tabla = CONEXION.EjecutarDataTabla(consulta, "tablaCliente");
            Cliente cliente = new Cliente();
            if (tabla.Rows.Count > 0)
            {
                cliente.IdCliente = Convert.ToInt32(tabla.Rows[0]["IdCliente"]);
                cliente.IdPersona = Convert.ToInt32(tabla.Rows[0]["IdPersona"]);
                cliente.UserName = tabla.Rows[0]["UserName"].ToString();
                cliente.Contraseña = tabla.Rows[0]["Contraseña"].ToString();
                cliente.Bloqueado = Convert.ToBoolean(tabla.Rows[0]["Bloqueado"]);
                cliente.FechaBloq = tabla.Rows[0]["FechaBloq"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(tabla.Rows[0]["FechaBloq"]) : null;
            }
            return cliente;
        }

        // Editar cliente
        public void EditarClienteDal(Cliente cliente)
        {
            string consulta = "UPDATE Cliente SET IdPersona = " + cliente.IdPersona + ", " +
                              "UserName = '" + cliente.UserName + "', " +
                              "Contraseña = '" + cliente.Contraseña + "', " +
                              "Bloqueado = " + (cliente.Bloqueado ? 1 : 0) + ", " +
                              "FechaBloq = " + (cliente.Bloqueado ? "'" + cliente.FechaBloq.Value.ToString("yyyy-MM-dd HH:mm:ss") + "'" : "NULL") +
                              " WHERE IdCliente = " + cliente.IdCliente;
            CONEXION.Ejecutar(consulta);
        }

        // Eliminar cliente
        public void EliminarClienteDal(int id)
        {
            string consulta = "DELETE FROM Cliente WHERE IdCliente = " + id;
            CONEXION.Ejecutar(consulta);
        }

        public Cliente ObtenerCredenciales(string userName, string contraseña)
        {
            // Consulta SQL para obtener el cliente
            string consulta = @"
    SELECT IdCliente, UserName, Contraseña, Bloqueado 
    FROM Cliente 
    WHERE UserName = @UserName AND Contraseña = @Contraseña";

            SqlParameter[] parametros = new SqlParameter[]
            {
        new SqlParameter("@UserName", userName),
        new SqlParameter("@Contraseña", contraseña)
            };

            DataTable tabla = new DataTable();
            using (SqlConnection conectar = new SqlConnection(CONEXION.CONECTAR))
            {
                conectar.Open();
                using (SqlCommand cmd = new SqlCommand(consulta, conectar))
                {
                    cmd.Parameters.AddRange(parametros);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(tabla);
                }
            }

            Cliente cliente = null;
            if (tabla.Rows.Count > 0)
            {
                DataRow fila = tabla.Rows[0];
                cliente = new Cliente
                {
                    IdCliente = Convert.ToInt32(fila["IdCliente"]),
                    UserName = fila["UserName"].ToString(),
                    Contraseña = fila["Contraseña"].ToString(),
                    Bloqueado = Convert.ToBoolean(fila["Bloqueado"]) // Asegúrate de que el tipo coincida
                };

                // Registrar auditoría de inicio de sesión
                AuditoriaClie auditoria = new AuditoriaClie
                {
                    Accion = $"{cliente.UserName} inició sesión.",
                    Timestamp = DateTime.Now,
                    IdCliente = cliente.IdCliente
                };

                AuditoriaClieDAL auditoriaDal = new AuditoriaClieDAL();
                auditoriaDal.InsertarAuditoria(auditoria);
            }

            return cliente;
        }
    }
}
