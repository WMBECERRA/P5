using AccesoDatos;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace APIREST.Controllers
{
    public class CategoriasController : ApiController
    {
        CategoriasNegocio categoriasNegocio = new CategoriasNegocio();

        //Get
        public IHttpActionResult Get()
        {
            var respuesta = categoriasNegocio.All();
            return Ok(respuesta);
        }
        //Get/Id
        public IHttpActionResult Get(int id)
        {
            Categoria categoria = categoriasNegocio.ById(id);
            if (categoria != null)
            {
                return Ok(categoria);
            }
            return NotFound();
        }
        //Post
        public IHttpActionResult Post(Categoria categoria)
        {
            try
            {
                categoriasNegocio.insertarCategoria(categoria);
                return Ok("Insertado Correctamente");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        //Put
        public IHttpActionResult Put(int id, Categoria categoria)
        {
            // Obtener el producto existente por su ID
            Categoria categoriaExistente = categoriasNegocio.ById(id);
            if (categoriaExistente == null)
            {
                return BadRequest("El producto no existe.");
            }

            // Actualizar los valores del producto existente con los valores del producto recibido
            categoriaExistente.nombre = categoria.nombre;

            // Guardar los cambios en la base de datos
            if (categoriasNegocio.actualizarCategoria(categoriaExistente))
            {
                return Ok("Categoria actualizada correctamente.");
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
                Categoria categoriaEliminar = categoriasNegocio.ById(id);
                if (categoriaEliminar == null)
                {
                    return NotFound();
                }
                categoriasNegocio.eliminarCategoria(categoriaEliminar);
                return Ok("Categoría Eliminada Correctamente");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}