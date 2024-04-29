using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class ProductoDatos : Interface1<Producto>
    {
        ServiciosEntities1 DBcontext;

        public ProductoDatos() { 
            DBcontext = new ServiciosEntities1();
        }
        public ObjectResult listarClientesCategoria() {
            return DBcontext.SP_Clientes();
        }
        public Producto BuscarId(int id) {
            return DBcontext.Producto.Where(P=>P.idProducto==id).FirstOrDefault();
        }
        public List<Producto> Listar()
        {
            return DBcontext.Producto.ToList();
        }

        public bool Actualizar(Producto item)
        {
            Producto temp = BuscarId(item.idProducto);
            //temp.idProducto = p.idProducto;
            temp.iva = item.iva;
            temp.precio_unitario = item.precio_unitario;
            temp.nombre = item.nombre;
            DBcontext.SaveChanges();
            return true;
        }

        public bool Nuevo(Producto producto)
        {
            if (DBcontext.Producto.Add(producto) != null)
            {
                DBcontext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Eliminar(Producto item)
        {
            Producto temp = BuscarId(item.idProducto);
            if (temp != null)
            {
                DBcontext.Producto.Remove(temp);
                DBcontext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
