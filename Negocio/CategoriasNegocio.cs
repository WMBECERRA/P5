using AccesoDatos;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CategoriasNegocio
    {
        CategoriaDatos categorias;
        public CategoriasNegocio()
        {
            categorias = new CategoriaDatos();
        }
        public List<Categoria> All()
        {
            return categorias.Listar();
        }
        public Categoria ById(int id)
        {
            return categorias.Listar().Where(c => c.id == id).SingleOrDefault();
        }
        public bool insertarCategoria(Categoria categoriaNuevo)
        {
            return categorias.Nuevo(categoriaNuevo);
        }
        public bool actualizarCategoria(Categoria categoria)
        {
            return categorias.Actualizar(categoria);
        }
        public bool eliminarCategoria(Categoria categoria)
        {
            return categorias.Eliminar(categoria);
        }
    }
}
