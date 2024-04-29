using AccesoDatos;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace prueba
{
    public class Program
    {
        static void Main(string[] args)
        {
            All();
            
            Console.ReadKey();
        }
        
        public static List<Producto> All()
        {
            ProductoDatos productos = new ProductoDatos();
            List<Producto> list = productos.Listar();
            foreach (var item in list)
            {
                Console.WriteLine($"ID: {item.idProducto}, Nombre: {item.nombre}, Precio: {item.precio_unitario}");
            }
            return productos.Listar();

        }
    }
}
