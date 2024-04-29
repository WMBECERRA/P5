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
    public class ProductosController : ApiController
    {
        ProductoNegocio productoNegocio = new ProductoNegocio();

        // get
        public IHttpActionResult Get() {
            var respuesta = productoNegocio.All();
            return Ok(respuesta);
        }
        public IHttpActionResult Get(int id) { 
            Producto respuesta = productoNegocio.ById(id);
            if (respuesta != null)
            {
                return Ok(respuesta);
            }
            return NotFound();
        }
        //Post
        public IHttpActionResult Post(Producto producto)
        {
            try
            {
                productoNegocio.insertarProducto(producto);
                return Ok("Insertado Correctamente");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        //Put
        public IHttpActionResult Put(int id, Producto producto)
        {
            // Obtener el producto existente por su ID
            Producto productoExistente = productoNegocio.ById(id);
            if (productoExistente == null)
            {
                return BadRequest("El producto no existe.");
            }

            // Actualizar los valores del producto existente con los valores del producto recibido
            productoExistente.nombre = producto.nombre;
            productoExistente.precio_unitario = producto.precio_unitario;
            productoExistente.iva = producto.iva;

            // Guardar los cambios en la base de datos
            if (productoNegocio.actualizarProducto(productoExistente))
            {
                return Ok("Producto actualizado correctamente.");
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
                Producto productoEliminar = productoNegocio.ById(id);
                if (productoEliminar == null)
                {
                    return NotFound();
                }
                productoNegocio.eliminarProducto(productoEliminar);
                return Ok("Producto Eliminado Correctamente");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}