using AccesoDatos;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace APIREST.Controllers
{
    public class DetalleFacturasController : ApiController
    {
        DetalleFacturasNegocio detalleFacturasNegocio = new DetalleFacturasNegocio();

        //Get
        public IHttpActionResult Get()
        {
            var respuesta = detalleFacturasNegocio.All();
            return Ok(respuesta);
        }
        //Get/Id
        public IHttpActionResult Get(int id)
        {
            DetalleFactura detalleFactura = detalleFacturasNegocio.ById(id);
            if (detalleFactura != null)
            {
                return Ok(detalleFactura);
            }
            return NotFound();
        }
        //Post
        public IHttpActionResult Post(DetalleFactura detalleFactura)
        {
            try
            {
                detalleFacturasNegocio.insertarDetallesFacturas(detalleFactura);
                return Ok("Insertado Correctamente");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        //Put
        public IHttpActionResult Put(int id, DetalleFactura detalleFactura)
        {
            // Obtener el producto existente por su ID
            DetalleFactura detallefacturaExistente = detalleFacturasNegocio.ById(id);
            if (detallefacturaExistente == null)
            {
                return BadRequest("El detalle factura no existe.");
            }
            /*temp.idFactura = item.idFactura;
            temp.idProducto = item.idProducto;
            temp.cantidad = item.cantidad;
            temp.precio = item.precio;*/

            // Actualizar los valores del producto existente con los valores del producto recibido
            detallefacturaExistente.idFactura = detalleFactura.idFactura;
            detallefacturaExistente.idProducto = detalleFactura.idProducto;
            detallefacturaExistente.cantidad = detalleFactura.cantidad;
            detallefacturaExistente.precio = detalleFactura.precio;

            // Guardar los cambios en la base de datos
            if (detalleFacturasNegocio.actualizarDetallesFacturas(detalleFactura))
            {
                return Ok("Detalle Factura actualizada correctamente.");
            }
            else
            {
                return BadRequest();
            }
        }
        public IHttpActionResult Delete(int id)
        {
            try
            {
                DetalleFactura detallefacturaEliminar = detalleFacturasNegocio.ById(id);
                if (detallefacturaEliminar == null)
                {
                    return NotFound();
                }
                detalleFacturasNegocio.eliminarDetallesFacturas(detallefacturaEliminar);
                return Ok("Detalle Factura Eliminada Correctamente");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}