using System;

namespace SistemaAquaFresh_1._0._0.Entidades
{
    public class Producto
    {
        private int id_producto;
        private string nombre;
        private string tipo_envase;
        private decimal precio_unitario;

        public Producto() { }
        public Producto(int id_producto, string nombre, string tipo_envase, decimal precio_unitario)
        {
            this.Id_producto = id_producto;
            this.Nombre = nombre;
            this.Tipo_envase = tipo_envase;
            this.Precio_unitario = precio_unitario;
        }

        public int Id_producto { get => id_producto; set => id_producto = value; }
        public string Nombre { get => nombre; set => nombre = value?.Trim(); }
        public string Tipo_envase { get => tipo_envase; set => tipo_envase = value?.Trim(); }
        public decimal Precio_unitario
        {
            get => precio_unitario;
            set => precio_unitario = value < 0
                ? throw new ArgumentException("El precio unitario no puede ser negativo.")
                : value;
        }
    }
}