using System;

// Clase Empleado
abstract class Empleado
{
    // Atributo encapsulado
    private string nombre;

    // Constructor de la clase Empleado
    public Empleado(string nombre)
    {
        this.nombre = nombre;
    }

    // un metodo publico para obtener el nombre del empleado encapsulamiento
    public string Nombre
    {
        get { return nombre; }
    }

    // Método abstracto para calcular el salario se implementara en las clases derivadas
    public abstract double CalcularSalario();
}

// Clase derivada Desarrollador
class Desarrollador : Empleado
{
    // Atributo encapsulado
    private double salarioBase;

    // Constructor de la clase Desarrollador
    public Desarrollador(string nombre, double salarioBase) : base(nombre)
    {
        this.salarioBase = salarioBase;
    }

    // Propiedad para obtener el salario base encapsulamiento
    public double SalarioBase
    {
        get { return salarioBase; }
    }

    // Sobrescribir el metodo CalcularSalario
    public override double CalcularSalario()
    {
        return salarioBase + 500; // Salario base más un bono fijo
    }
}

// Clase derivada Diseñador
class Diseñador : Empleado
{
    // Atributo encapsulado
    private double salarioBase;

    // Constructor de la clase Diseñador
    public Diseñador(string nombre, double salarioBase) : base(nombre)
    {
        this.salarioBase = salarioBase;
    }

    // Propiedad para obtener el salario base encapsulamiento
    public double SalarioBase
    {
        get { return salarioBase; }
    }

    // Sobrescribir el metodo CalcularSalario
    public override double CalcularSalario()
    {
        return salarioBase + 300; // Salario base más un bono fijo
    }
}

// Clase principal para ejecutar el programa
class Program
{
    static void Main()
    {
        // Crear instancias de Desarrollador y Diseñador
        Empleado dev = new Desarrollador("Muñoz", 1500);
        Empleado dis = new Diseñador("Penna", 1200);

        // Mostrar el nombre y el salario de cada empleado
        Console.WriteLine($"{dev.Nombre} tiene un salario de: {dev.CalcularSalario()}");
        Console.WriteLine($"{dis.Nombre} tiene un salario de: {dis.CalcularSalario()}");
    }
}
