using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class FacturaDatos
    {
        ServiciosEntities1 contexto;
        public FacturaDatos()
        {
            contexto = new ServiciosEntities1();
        }
        public bool Nuevo(Factura item)
        {
            if (contexto.Factura.Add(item) != null)
            {
                contexto.SaveChanges();
                return true;
            }
            return false;
        }
        public List<Factura> Listar()
        {
            return contexto.Factura.ToList();
        }
        public Factura BuscarNumero(int numero)
        {
            return contexto.Factura.Where(f => f.numero == numero).FirstOrDefault();
        }
        public bool Actualizar(Factura item)
        {
            Factura temp = BuscarNumero(item.numero);
            temp.fecha = item.fecha;
            temp.idCliente = item.idCliente;
            contexto.SaveChanges();
            return true;
        }

        public bool Eliminar(Factura item)
        {
            Factura temp = BuscarNumero(item.numero);
            if (temp != null)
            {
                contexto.Factura.Remove(temp);
                contexto.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
