<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 4557bed474d35d11258da463b6cd71b24e3171f1

namespace SistemaAquaFresh_1._0._0.Entidades
{
    public class Venta
    {
        private static int nextId = 1;
<<<<<<< HEAD
=======

>>>>>>> 4557bed474d35d11258da463b6cd71b24e3171f1
        private int id_venta;
        private Cliente cliente;
        private Producto producto;
        private int cantidad;
        private DateTime fechaVenta;
        private decimal total;

        public Venta(Cliente cliente, Producto producto, int cantidad)
        {
            if (cliente == null) throw new ArgumentNullException(nameof(cliente), "El cliente no puede ser nulo.");
            if (producto == null) throw new ArgumentNullException(nameof(producto), "El producto no puede ser nulo.");
            if (cantidad <= 0) throw new ArgumentException("La cantidad debe ser mayor que cero.", nameof(cantidad));
<<<<<<< HEAD
=======

>>>>>>> 4557bed474d35d11258da463b6cd71b24e3171f1
            this.id_venta = nextId++;
            this.Cliente = cliente;
            this.Producto = producto;
            this.Cantidad = cantidad;
            this.FechaVenta = DateTime.Now;
            RecalcularTotal();
        }

        public int Id_venta { get => id_venta; }
<<<<<<< HEAD
=======

>>>>>>> 4557bed474d35d11258da463b6cd71b24e3171f1
        public Cliente Cliente
        {
            get => cliente;
            set => cliente = value ?? throw new ArgumentNullException(nameof(Cliente), "El cliente no puede ser nulo.");
        }
<<<<<<< HEAD
=======

>>>>>>> 4557bed474d35d11258da463b6cd71b24e3171f1
        public Producto Producto
        {
            get => producto;
            set => producto = value ?? throw new ArgumentNullException(nameof(Producto), "El producto no puede ser nulo.");
        }
<<<<<<< HEAD
=======

>>>>>>> 4557bed474d35d11258da463b6cd71b24e3171f1
        public int Cantidad
        {
            get => cantidad;
            set
            {
                if (value <= 0) throw new ArgumentException("La cantidad no puede ser 0 ni negativa.");
                cantidad = value;
                RecalcularTotal();
            }
        }
<<<<<<< HEAD
=======

>>>>>>> 4557bed474d35d11258da463b6cd71b24e3171f1
        public DateTime FechaVenta
        {
            get => fechaVenta;
            private set => fechaVenta = value;
        }
<<<<<<< HEAD
=======

>>>>>>> 4557bed474d35d11258da463b6cd71b24e3171f1
        public decimal Total
        {
            get => total;
            private set => total = value;
        }

        private void RecalcularTotal()
        {
            Total = Cantidad * Producto.Precio_unitario;
        }
    }
}