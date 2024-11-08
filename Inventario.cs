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
        public void ContarYAgruparProductos()
        {
            var grupo1 = productos.Count(p => p.Precio < 100);
            var grupo2 = productos.Count(p => p.Precio >= 100 && p.Precio <= 500);
            var grupo3 = productos.Count(p => p.Precio > 500);
            Console.WriteLine($"Productos con precio < 100: {grupo1}");
            Console.WriteLine($"Productos con precio entre 100 y 500: {grupo2}");
            Console.WriteLine($"Productos con precio > 500: {grupo3}");
        }
        public void GenerarReporte()
        {
            var totalProductos = productos.Count;
            var precioPromedio = productos.Average(p => p.Precio);
            var productoMasCaro = productos.OrderByDescending(p => p.Precio).FirstOrDefault();
            var productoMasBarato = productos.OrderBy(p => p.Precio).FirstOrDefault();
            Console.WriteLine($"\nNúmero total de productos: {totalProductos}");
            Console.WriteLine($"Precio promedio de los productos: {precioPromedio:C}");
            Console.WriteLine($"Producto con el precio más alto: {productoMasCaro.Nombre} - {productoMasCaro.Precio:C}");
            Console.WriteLine($"Producto con el precio más bajo: {productoMasBarato.Nombre} - {productoMasBarato.Precio:C}");
        }
    }
}
