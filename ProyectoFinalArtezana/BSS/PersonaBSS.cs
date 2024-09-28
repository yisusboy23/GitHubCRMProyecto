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
    public class PersonaBSS
    {
        PersonaDAL dal = new PersonaDAL();

        public DataTable ListarPersonasBss()
        {
            return dal.ListarPersonasDal();
        }

        public void InsertarPersonaBss(Persona persona)
        {
            dal.InsertarPersonaDal(persona);
        }

        public Persona ObtenerPersonaIdBss(int id)
        {
            return dal.ObtenerPersonaIdDal(id);
        }

        public void EditarPersonaBss(Persona persona)
        {
            dal.EditarPersonaDal(persona);
        }

        public void EliminarPersonaBss(int id)
        {
            dal.EliminarPersonaDal(id);
        }


        // Método para insertar persona y cliente al mismo tiempo
        public Cliente InsertarPersonaYClienteBss(Persona persona, Cliente cliente)
        {
            // Llamar al método DAL y retornar el cliente con el nuevo IdCliente
            return dal.InsertarPersonaYClienteDal(persona, cliente);
        }


        public DataTable ObtenerCuentasPorPersonaBss(int idPersona)
        {
            return dal.ObtenerCuentasPorPersona(idPersona);
        }

    }
}
