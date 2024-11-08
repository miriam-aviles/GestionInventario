using System;
using System.Collections.Generic;
using System.Linq;

namespace GestionInventario
{
    internal class Inventario
    {
        private List<Producto> productos = new List<Producto>();

        public void AgregarProducto(Producto producto)
        {
            productos.Add(producto);
        }

        public void ActualizarPrecio(string nombre, decimal nuevoPrecio)
        {
            var producto = productos.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (producto != null)
            {
                producto.Precio = nuevoPrecio;
                Console.WriteLine($"El precio de '{nombre}' ha sido actualizado a {nuevoPrecio:C}.");
            }
            else
            {
                Console.WriteLine($"Producto '{nombre}' no encontrado.");
            }
        }

        public void EliminarProducto(string nombre)
        {
            var producto = productos.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (producto != null)
            {
                productos.Remove(producto);
                Console.WriteLine($"El producto '{nombre}' ha sido eliminado.");
            }
            else
            {
                Console.WriteLine($"Producto '{nombre}' no encontrado.");
            }
        }

        public IEnumerable<Producto> FiltrarYOrdenarProducto(decimal precioMinimo)
        {
            return productos.Where(p => p.Precio > precioMinimo).OrderBy(p => p.Precio);
        }

        public int ContarProductosPorRango(decimal rangoMin, decimal rangoMax)
        {
            return productos.Count(p => p.Precio >= rangoMin && p.Precio <= rangoMax);
        }

        public void GenerarReporte()
        {
            Console.WriteLine("\nReporte de Inventario:");
            foreach (var producto in productos)
            {
                producto.MostrarInformacion();
            }
        }
    }
}
