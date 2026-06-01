using SistemaAquaFresh_1._0._0.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaAquaFresh_1._0._0.Controlador
{
    public static class Venta_Controler
    {
        public static List<Producto> Lista_Productos = new List<Producto>();
        public static List<Cliente> Lista_Clientes = new List<Cliente>();

        static Venta_Controler()
        {
            CargarDatosDePrueba();
        }

        private static void CargarDatosDePrueba()
        {
            Lista_Productos.Add(new Producto(101, "Bidón de Agua 20L", "Retornable", 2.50m));
            Lista_Productos.Add(new Producto(102, "Galón de Agua 5L", "Desechable", 1.25m));
            Lista_Productos.Add(new Producto(103, "Botella de Agua 500ml", "Desechable", 0.50m));

            Lista_Clientes.Add(new Cliente(1, "Natural", "Efectivo", 0706050403, "Eduardo", "Endara", "Machala Central", "0987654321"));
            Lista_Clientes.Add(new Cliente(2, "Corporativo", "Transferencia", 0701020304, "Luis", "Salinas", "El Cambio", "0999999999"));
        }

        public static void AñadirProducto(Producto nuevoProducto)
        {
            if (nuevoProducto == null) throw new ArgumentNullException(nameof(nuevoProducto));

            bool existe = Lista_Productos.Any(p => p.Id_producto == nuevoProducto.Id_producto);
            if (existe) throw new InvalidOperationException($"El código {nuevoProducto.Id_producto} ya existe.");

            Lista_Productos.Add(nuevoProducto);
        }

        public static void ProcesarVentaDirecta(Cliente cliente, Producto producto, int cantidad, decimal precioPactado, string tipoPago, string estado)
        {
            if (cliente == null) throw new ArgumentNullException(nameof(cliente), "Debe seleccionar un cliente válido.");
            if (producto == null) throw new ArgumentNullException(nameof(producto), "Debe seleccionar un producto válido.");

            if (precioPactado <= 0)
                throw new ArgumentException("El precio de venta debe ser estrictamente mayor a $0.00.");

            cliente.Producto_comprado = producto;
            cliente.Cantidad_comprada = cantidad;
            cliente.Precio_venta_pactado = precioPactado;
            cliente.Tipo_pago = tipoPago;
            cliente.Estado_venta = estado;
            cliente.Fecha_hora_venta = DateTime.Now;
        }
    }
}