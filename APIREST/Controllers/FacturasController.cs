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
    public class FacturasController : ApiController
    {
        FacturasNegocio facturaNegocio = new FacturasNegocio();

        //Get
        public IHttpActionResult Get()
        {
            var respuesta = facturaNegocio.All();
            return Ok(respuesta);
        }
        //Get/Id
        public IHttpActionResult Get(int numero)
        {
            Factura factura = facturaNegocio.ByNumero(numero);
            if (factura != null)
            {
                return Ok(factura);
            }
            return NotFound();
        }
        //Post
        public IHttpActionResult Post(Factura factura)
        {
            try
            {
                facturaNegocio.insertarFactura(factura);
                return Ok("Insertado Correctamente");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        //Put
        public IHttpActionResult Put(int numero, Factura factura)
        {
            // Obtener el producto existente por su ID
            Factura facturaExistente = facturaNegocio.ByNumero(numero);
            if (facturaExistente == null)
            {
                return BadRequest("La factura no existe.");
            }

            // Actualizar los valores del producto existente con los valores del producto recibido
            facturaExistente.fecha = factura.fecha;
            facturaExistente.idCliente = factura.idCliente;

            // Guardar los cambios en la base de datos
            if (facturaNegocio.actualizarFactura(facturaExistente))
            {
                return Ok("Factura actualizada correctamente.");
            }
            else
            {
                return BadRequest();
            }
        }
        public IHttpActionResult Delete(int numero)
        {
            try
            {
                Factura facturaEliminar = facturaNegocio.ByNumero(numero);
                if (facturaEliminar == null)
                {
                    return NotFound();
                }
                facturaNegocio.eliminarFactura(facturaEliminar);
                return Ok("Factura Eliminada Correctamente");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}