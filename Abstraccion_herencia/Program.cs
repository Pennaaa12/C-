using System;

namespace Abstraccion_herencia
{
    // Clase abstracta Animal - proporciona una plantilla para las clases derivadas
    public abstract class Animal
    {
        // Propiedad común a todos los animales
        public string Nombre { get; set; }

        // Constructor para inicializar el nombre del animal
        public Animal(string nombre)
        {
            Nombre = nombre;
        }

        // Método abstracto - debe ser implementado por las clases derivadas
        public abstract void HacerSonido();
    }

    // Clase Perro que hereda de Animal
    public class Perro : Animal
    {
        // Constructor que llama al constructor de la clase base
        public Perro(string nombre) : base(nombre) { }

        // Implementación del método abstracto HacerSonido
        public override void HacerSonido()
        {
            Console.WriteLine(Nombre + " dice: ¡Guau!");
        }
    }

    // Clase Gato que hereda de Animal
    public class Gato : Animal
    {
        // Constructor que llama al constructor de la clase base
        public Gato(string nombre) : base(nombre) { }

        // Implementación del método abstracto HacerSonido
        public override void HacerSonido()
        {
            Console.WriteLine(Nombre + " dice: ¡Miau!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Crear instancia de Perro y llamar a su método HacerSonido
            Animal miPerro = new Perro("Perro");
            miPerro.HacerSonido();

            // Crear instancia de Gato y llamar a su método HacerSonido
            Animal miGato = new Gato("Gato");
            miGato.HacerSonido();

            // Esperar la entrada del usuario para mantener la consola abierta
            Console.WriteLine("Presiona cualquier tecla para salir.");
            Console.ReadKey();
        }
    }
}

