using AccesoDatos;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class FacturasNegocio
    {
        FacturaDatos facturas;
        public FacturasNegocio()
        {
            facturas = new FacturaDatos();
        }
        public List<Factura> All()
        {
            return facturas.Listar();
        }
        public Factura ByNumero(int numero)
        {
            return facturas.Listar().Where(f => f.numero == numero).SingleOrDefault();
        }
        public bool insertarFactura(Factura factNueva)
        {
            return facturas.Nuevo(factNueva);
        }
        public bool actualizarFactura(Factura factura)
        {
            return facturas.Actualizar(factura);
        }
        public bool eliminarFactura(Factura factura)
        {
            return facturas.Eliminar(factura);
        }
    }
}
