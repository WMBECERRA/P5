using AccesoDatos;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class DetalleFacturasNegocio
    {
        DetalleFacturaDatos detallesfacturas;
        public DetalleFacturasNegocio()
        {
            detallesfacturas = new DetalleFacturaDatos();
        }
        public List<DetalleFactura> All()
        {
            return detallesfacturas.Listar();
        }
        public DetalleFactura ById(int id)
        {
            return detallesfacturas.Listar().Where(df => df.id == id).SingleOrDefault();
        }
        public bool insertarDetallesFacturas(DetalleFactura detallesfacturasNueva)
        {
            return detallesfacturas.Nuevo(detallesfacturasNueva);
        }
        public bool actualizarDetallesFacturas(DetalleFactura detallefacturas)
        {
            return detallesfacturas.Actualizar(detallefacturas);
        }
        public bool eliminarDetallesFacturas(DetalleFactura detalleFactura)
        {
            return detallesfacturas.Eliminar(detalleFactura);
        }
    }
}
