using GestionDeInventario;
using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Inventario inventario = new Inventario();
        Console.WriteLine("Bienvenido al sistema de gestión de inventario.");

        Console.Write("¿Cuántos productos desea ingresar? ");
        int cantidad = int.Parse(Console.ReadLine());


        for (int i = 0; i < cantidad; i++)
        {
            Console.WriteLine($"\n Producto {i + 1}");
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Precio: ");
            decimal precio = decimal.Parse(Console.ReadLine());

            Producto producto = new Producto(nombre, precio);
            inventario.AgregarProducto(producto);
        }

        // Ingresar el precio mínimo para el filtro
        Console.Write("\n Ingrese el precio mínimo para filtrar los productos: ");
        decimal precioMinimo = decimal.Parse(Console.ReadLine());

        // Filtrar y mostrar productos
        var productosFiltrados = inventario.FiltrarYOrdenarProductos(precioMinimo);

        Console.WriteLine("\n Productos filtrados y ordenados:");
        foreach (var producto in productosFiltrados)
        {
            producto.MostrarInformacion(); // Muestra la información del producto
        }
    }
}
