using DAL;
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

        public void CambiarContraseñaBss(int idCliente, string nuevaContraseña)
        {
            // Valida la longitud y contenido de la nueva contraseña (puedes agregar más reglas)
            if (string.IsNullOrEmpty(nuevaContraseña) || nuevaContraseña.Length < 6)
            {
                throw new Exception("La contraseña debe tener al menos 6 caracteres.");
            }

            // Llama al método en la capa DAL para cambiar la contraseña
            dal.CambiarContraseña(idCliente, nuevaContraseña);
        }


        ClienteDAL clienteDAL = new ClienteDAL();

        public DataTable BuscarClientePorUserName(string userName)
        {
            return clienteDAL.BuscarClientePorUserName(userName);
        }

    }
}
