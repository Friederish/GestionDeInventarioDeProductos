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
        int cantidad = LeerNumeroPositivo();


        for (int i = 0; i < cantidad; i++)
        {
            Console.WriteLine($"\n Producto {i + 1}");
            Console.Write("Nombre: ");
            string nombre = LeerCadenaNoVacia("Nombre: ");
            decimal precio = LeerPrecioPositivo("Precio: ");


            Producto producto = new Producto(nombre, precio);
            inventario.AgregarProducto(producto);
        }
        decimal precioMinimo = LeerPrecioPositivo("\nIngrese el precio mínimo para filtrar los productos: ");

        var productosFiltrados = inventario.FiltrarYOrdenarProductos(precioMinimo);
       
        Console.Write("\n Ingrese el precio mínimo para filtrar los productos: ");
      


        Console.WriteLine("\n Productos filtrados y ordenados:");
        foreach (var producto in productosFiltrados)
        {
            producto.MostrarInformacion(); 
        }
        string nombreProductoActualizar = LeerCadenaNoVacia("\nIngrese el nombre del producto para actualizar su precio: ");
        decimal nuevoPrecio = LeerPrecioPositivo("Ingrese el nuevo precio: ");
        if (inventario.ActualizarPrecio(nombreProductoActualizar, nuevoPrecio))
        {
            Console.WriteLine("Precio actualizado con éxito.");
        }
        else
        {
            Console.WriteLine("Producto no encontrado.");
        }
        string nombreProductoEliminar = LeerCadenaNoVacia("\nIngrese el nombre del producto para eliminar: ");
        if (inventario.EliminarProducto(nombreProductoEliminar))
        {
            Console.WriteLine("Producto eliminado con éxito.");
        }
        else
        {
            Console.WriteLine("Producto no encontrado.");
        }


        inventario.ContarYAgruparProductos();


        inventario.GenerarReporte();
    }


    static int LeerNumeroPositivo()
    {
        int numero;
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out numero) && numero > 0)
            {
                return numero;
            }
            Console.WriteLine("Entrada inválida. Por favor, ingrese un número positivo.");
        }
    }


    static string LeerCadenaNoVacia(string mensaje)
    {
        string entrada;
        while (true)
        {
            Console.Write(mensaje);
            entrada = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(entrada))
            {
                return entrada;
            }
            Console.WriteLine("Entrada inválida. El texto no puede estar vacío.");
        }
    }


    static decimal LeerPrecioPositivo(string mensaje)
    {
        decimal precio;
        while (true)
        {
            Console.Write(mensaje);
            if (decimal.TryParse(Console.ReadLine(), out precio) && precio > 0)
            {
                return precio;
            }
            Console.WriteLine("Entrada inválida. Por favor, ingrese un precio positivo.");
        }
    }
}
