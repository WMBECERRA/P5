using AccesoDatos;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ClientesNegocio
    {
        ClienteDatos clientes;
        public ClientesNegocio()
        {
            clientes = new ClienteDatos();
        }
        public List<Cliente> All()
        {
            return clientes.Listar();
        }
        public Cliente ById(int id)
        {
            return clientes.Listar().Where(c => c.id == id).SingleOrDefault();
        }
        public bool insertarCliente(Cliente clienteNuevo)
        {
            return clientes.Nuevo(clienteNuevo);
        }
        public bool actualizarCliente(Cliente cliente)
        {
            return clientes.Actualizar(cliente);
        }
        public bool eliminarCliente(Cliente cliente)
        {
            return clientes.Eliminar(cliente);
        }
    }
}
