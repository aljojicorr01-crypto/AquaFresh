using System;

namespace AquaFresh.Entidades
{
    /// <summary>
    /// Clase base para representar una persona en el sistema
    /// </summary>
    public class Persona
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

        /// <summary>
        /// Constructor de la clase Persona
        /// </summary>
        public Persona(string cedula, string nombre, string apellido, string direccion = "", string telefono = "")
        {
            ValidarDatos(cedula, nombre, apellido);
            
            Cedula = cedula;
            Nombre = nombre;
            Apellido = apellido;
            Direccion = direccion;
            Telefono = telefono;
        }

        /// <summary>
        /// Valida los datos obligatorios de una persona
        /// </summary>
        private void ValidarDatos(string cedula, string nombre, string apellido)
        {
            if (string.IsNullOrWhiteSpace(cedula))
                throw new ArgumentException("La cédula no puede estar vacía");
            
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre no puede estar vacío");
            
            if (string.IsNullOrWhiteSpace(apellido))
                throw new ArgumentException("El apellido no puede estar vacío");
        }

        public override string ToString()
        {
            return $"{Nombre} {Apellido} (Cédula: {Cedula})";
        }
    }
}
