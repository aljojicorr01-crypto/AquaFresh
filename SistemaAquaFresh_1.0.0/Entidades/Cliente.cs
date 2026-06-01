using System;

namespace SistemaAquaFresh_1._0._0.Entidades
{
    public class Cliente : Persona
    {
        private int id_cliente;
        private string tipo_cliente;
        private string tipo_pago;

        // Campos de la transacción
        private Producto producto_comprado;
        private int cantidad_comprada;
        private decimal precio_venta_pactado;
        private DateTime fecha_hora_venta;
        private string estado_venta;

        public Cliente()
        {
            this.fecha_hora_venta = DateTime.Now;
            this.estado_venta = "Pendiente";
        }

        public Cliente(int id_cliente, string tipo_cliente, string tipo_pago, int id_cedula, string nombre, string apellido, string direccion, string telefono)
            : base(id_cedula, nombre, apellido, direccion, telefono)
        {
            this.Id_cliente = id_cliente;
            this.Tipo_cliente = tipo_cliente;
            this.Tipo_pago = tipo_pago;
            this.estado_venta = "Pendiente";
            this.fecha_hora_venta = DateTime.Now;
        }

        public int Id_cliente { get => id_cliente; set => id_cliente = value; }
        public string Tipo_cliente { get => tipo_cliente; set => tipo_cliente = value?.Trim(); }
        public string Tipo_pago { get => tipo_pago; set => tipo_pago = value?.Trim(); }
        public Producto Producto_comprado { get => producto_comprado; set => producto_comprado = value; }

        public int Cantidad_comprada
        {
            get => cantidad_comprada;
            set => cantidad_comprada = value < 0 ? throw new ArgumentException("La cantidad no puede ser negativa.") : value;
        }

        public decimal Precio_venta_pactado
        {
            get => precio_venta_pactado;
            set => precio_venta_pactado = value < 0 ? throw new ArgumentException("El precio no puede ser negativo.") : value;
        }

        public DateTime Fecha_hora_venta { get => fecha_hora_venta; set => fecha_hora_venta = value; }

        public string Estado_venta
        {
            get => estado_venta;
            set
            {
                if (value != "Pendiente" && value != "Realizada")
                    throw new ArgumentException("El estado solo puede ser 'Pendiente' o 'Realizada'.");
                estado_venta = value;
            }
        }

        public decimal TotalTransaccion => Cantidad_comprada * Precio_venta_pactado;
    }
}