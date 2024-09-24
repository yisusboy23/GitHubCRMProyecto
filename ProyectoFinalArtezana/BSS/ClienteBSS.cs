﻿using DAL;
using MODELOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSS
{
    public class ClienteBSS
    {
        ClienteDAL dal = new ClienteDAL();

        public DataTable ListarClientesBss()
        {
            return dal.ListarClientesDal();
        }

        public void InsertarClienteBss(Cliente cliente)
        {
            dal.InsertarClienteDal(cliente);
        }

        public Cliente ObtenerClientePorIdBss(int id)
        {
            return dal.ObtenerClientePorIdDal(id);
        }

        public void EditarClienteBss(Cliente cliente)
        {
            dal.EditarClienteDal(cliente);
        }

        public void EliminarClienteBss(int id)
        {
            dal.EliminarClienteDal(id);
        }
        // Nuevo método para obtener las credenciales del usuario
        // Método para obtener las credenciales del cliente
        public Cliente ObtenerCredencialesBss(string nombreUsuario, string contrasena)
        {
            return dal.ObtenerCredenciales(nombreUsuario, contrasena); // Asegúrate de que llame al método correcto en DAL
        }
    }
}
