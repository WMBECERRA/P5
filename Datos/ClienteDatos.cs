using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class ClienteDatos : Interface1<Cliente>
    {
        ServiciosEntities1 contexto;
        public ClienteDatos()
        {
            contexto = new ServiciosEntities1();
        }
        public bool Nuevo(Cliente item)
        {
            if (contexto.Cliente.Add(item) != null)
            {
                contexto.SaveChanges();
                return true;
            }
            return false;
        }
        public List<Cliente> Listar()
        {
            return contexto.Cliente.ToList();
        }
        public Cliente BuscarId(int id)
        {
            return contexto.Cliente.Where(c => c.id == id).FirstOrDefault();
        }
        public bool Actualizar(Cliente item)
        {
            Cliente temp = BuscarId(item.id);
            temp.cedula = item.cedula;
            temp.nombre = item.nombre;
            temp.direccion = item.direccion;
            temp.telefono = item.telefono;
            temp.idCategoria = item.idCategoria;
            contexto.SaveChanges();
            return true;
        }

        public bool Eliminar(Cliente item)
        {
            Cliente temp = BuscarId(item.id);
            if (temp != null)
            {
                contexto.Cliente.Remove(temp);
                contexto.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
