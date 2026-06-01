using System;

namespace SistemaAquaFresh_1._0._0.Entidades
{
    public class Persona
    {
        private int id_cedula;
        private string nombre;
        private string apellido;
        private string direccion;
        private string telefono;

        public Persona() { }

        public Persona(int id_cedula, string nombre, string apellido, string direccion, string telefono)
        {
            this.Id_cedula = id_cedula;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Direccion = direccion;
            this.Telefono = telefono;
        }

        public int Id_cedula
        {
            get => id_cedula;
            set => id_cedula = value <= 0 ? throw new ArgumentException("La cédula de persona debe ser válida.") : value;
        }
        public string Nombre
        {
            get => nombre;
            set => nombre = string.IsNullOrWhiteSpace(value) ? throw new ArgumentException("El nombre es requerido.") : value.Trim();
        }
        public string Apellido
        {
            get => apellido;
            set => apellido = string.IsNullOrWhiteSpace(value) ? throw new ArgumentException("El apellido es requerido.") : value.Trim();
        }
        public string Direccion { get => direccion; set => direccion = value?.Trim(); }
        public string Telefono { get => telefono; set => telefono = value?.Trim(); }

        public string ObtenerNombreCompleto() => $"{Nombre} {Apellido}".Trim();
    }
}