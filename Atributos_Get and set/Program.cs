using System;

namespace Atributos_Getandset
{
    // Definimos la clase Persona
    class Persona
    {
        // Atributo privado para almacenar el nombre
        private string nombre;

        // Atributo privado para almacenar la edad
        private int edad;

        // Atributo privado para almacenar el correo
        private string correo;

        // Propiedad pública para acceder y modificar el nombre
        public string Nombre
        {
            get { return nombre; } // Retorna el valor del atributo nombre
            set { nombre = value; } // Asigna un valor al atributo nombre
        }

        // Propiedad pública para acceder y modificar la edad
        public int Edad
        {
            get { return edad; } // Retorna el valor del atributo edad
            set
            {
                // Validamos que la edad sea mayor o igual a 0
                if (value >= 0)
                {
                    edad = value;
                }
                else
                {
                    Console.WriteLine("La edad no puede ser negativa.");
                }
            }
        }

        // Propiedad pública para acceder y modificar el correo
        public string Correo
        {
            get { return correo; } // Retorna el valor del atributo correo
            set
            {
                // Validamos que el correo contenga un '@'
                if (value.Contains("@"))
                {
                    correo = value;
                }
                else
                {
                    Console.WriteLine("El correo no es válido.");
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Creamos una nueva instancia de la clase Persona
            Persona persona = new Persona();

            // Usamos las propiedades para asignar valores a los atributos
            persona.Nombre = "Juan Perez";
            persona.Edad = 30;
            persona.Correo = "juan.perez@example.com";

            // Imprimimos los valores de los atributos usando las propiedades
            Console.WriteLine("Nombre: " + persona.Nombre);
            Console.WriteLine("Edad: " + persona.Edad);
            Console.WriteLine("Correo: " + persona.Correo);

            // Intentamos asignar una edad negativa
            persona.Edad = -5; // Esto mostrará un mensaje de error

            // Intentamos asignar un correo no válido
            persona.Correo = "juan.perezexample.com"; // Esto mostrará un mensaje de error
        }
    }
}

