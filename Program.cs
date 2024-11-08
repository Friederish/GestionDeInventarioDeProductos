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
    }
}
