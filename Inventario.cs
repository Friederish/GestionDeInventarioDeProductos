using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeInventario
{
    public class Inventario
    {
        private List<Producto> productos;


        public Inventario()
        {
            productos = new List<Producto>();
        }


        public void AgregarProducto(Producto producto)
        {
            productos.Add(producto);
        }
        public bool ActualizarPrecio(string nombre, decimal nuevoPrecio)
        {
            var producto = productos.FirstOrDefault(p => p.Nombre == nombre);
            if (producto != null)
            {
                producto.Precio = nuevoPrecio;
                return true;
            }
            return false;
        }
        public bool EliminarProducto(string nombre)
        {
            var producto = productos.FirstOrDefault(p => p.Nombre == nombre);
            if (producto != null)
            {
                productos.Remove(producto);
                return true;
            }
            return false;
        }

        // Método para filtrar y ordenar los productos por precio mínimo
        public IEnumerable<Producto> FiltrarYOrdenarProductos(decimal precioMinimo)
        {
            // Filtrar y ordenar productos con LINQ y expresiones Lambda
            return productos
               .Where(p => p.Precio > precioMinimo) 
               .OrderBy(p => p.Precio); 
        }
    }
}
