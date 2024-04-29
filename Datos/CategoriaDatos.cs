using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class CategoriaDatos : Interface1<Categoria>
    {
        ServiciosEntities1 contexto;
        public CategoriaDatos()
        {
            contexto = new ServiciosEntities1();
        }
        public bool Nuevo(Categoria item)
        {
            if (contexto.Categoria.Add(item) != null)
            {
                contexto.SaveChanges();
                return true;
            }
            return false;
        }
        public List<Categoria> Listar()
        {
            return contexto.Categoria.ToList();
        }
        public Categoria BuscarId(int id)
        {
            return contexto.Categoria.Where(c => c.id == id).FirstOrDefault();
        }
        public bool Actualizar(Categoria item)
        {
            Categoria temp = BuscarId(item.id);
            temp.nombre = item.nombre;
            contexto.SaveChanges();
            return true;
        }

        public bool Eliminar(Categoria item)
        {
            Categoria temp = BuscarId(item.id);
            if (temp != null)
            {
                contexto.Categoria.Remove(temp);
                contexto.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
