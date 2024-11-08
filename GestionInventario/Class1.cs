using System;
using System.Linq;

namespace GestionInventario
{
    class Program
    {
        static void Main(string[] args)
        {
            Inventario inventario = new Inventario();

            Console.WriteLine("Bienvenido al sistema de gestión de inventario.");

            Console.WriteLine("¿Cuántos productos deseas agregar?");
            int cantidad = ValidarEntradaNumerica();

            for (int i = 0; i < cantidad; i++)
            {
                Console.WriteLine($"\nProducto {i + 1}:");
                Console.WriteLine("Nombre:");
                string nombre = Console.ReadLine();

                Console.WriteLine("Precio:");
                decimal precio = ValidarEntradaDecimal();

                Producto producto = new Producto(nombre, precio);
                inventario.AgregarProducto(producto);
            }

            Console.WriteLine("\n¿Deseas actualizar el precio de algún producto? (sí/no)");
            if (Console.ReadLine().ToLower() == "sí")
            {
                Console.WriteLine("Ingresa el nombre del producto a actualizar:");
                string nombreActualizar = Console.ReadLine();
                Console.WriteLine("Ingresa el nuevo precio:");
                decimal nuevoPrecio = ValidarEntradaDecimal();

                inventario.ActualizarPrecio(nombreActualizar, nuevoPrecio);
            }

           
            Console.WriteLine("\n¿Deseas eliminar algún producto? (sí/no)");
            if (Console.ReadLine().ToLower() == "sí")
            {
                Console.WriteLine("Ingresa el nombre del producto a eliminar:");
                string nombreEliminar = Console.ReadLine();
                inventario.EliminarProducto(nombreEliminar);
            }

        
            Console.WriteLine("\nIngrese el precio mínimo para filtrar productos:");
            decimal precioMinimo = ValidarEntradaDecimal();
            var productosFiltrados = inventario.FiltrarYOrdenarProducto(precioMinimo);

            Console.WriteLine("\nProductos filtrados y ordenados por precio:");
            foreach (var producto in productosFiltrados)
            {
                producto.MostrarInformacion();
            }

            Console.WriteLine("\nIngrese el rango de precios para contar productos.");
            Console.WriteLine("Precio mínimo:");
            decimal rangoMin = ValidarEntradaDecimal();
            Console.WriteLine("Precio máximo:");
            decimal rangoMax = ValidarEntradaDecimal();

            int cantidadEnRango = inventario.ContarProductosPorRango(rangoMin, rangoMax);
            Console.WriteLine($"\nCantidad de productos en el rango de {rangoMin:C} a {rangoMax:C}: {cantidadEnRango}");

            
            inventario.GenerarReporte();
        }

      
        static int ValidarEntradaNumerica()
        {
            int valor;
            while (!int.TryParse(Console.ReadLine(), out valor) || valor <= 0)
            {
                Console.WriteLine("Entrada inválida. Por favor, ingresa un número positivo.");
            }
            return valor;
        }

        static decimal ValidarEntradaDecimal()
        {
            decimal valor;
            while (!decimal.TryParse(Console.ReadLine(), out valor) || valor <= 0)
            {
                Console.WriteLine("Entrada inválida. Por favor, ingresa un número decimal positivo.");
            }
            return valor;
        }
    }
}
