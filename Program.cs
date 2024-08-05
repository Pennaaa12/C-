using System;
using System.Collections.Generic;

// Principio de Responsabilidad Única (SRP)
// Esta clase solo se encarga de almacenar la información del estudiante.
public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}

// Principio de Abierto/Cerrado (OCP)
// Esta interfaz permite extender el repositorio sin modificar la interfaz existente.
public interface IStudentRepository
{
    void AddStudent(Student student);
    List<Student> GetAllStudents();
    void UpdateStudent(Student student);
    void RemoveStudent(int id);
}

// Principio de Sustitución de Liskov (LSP)
// La implementación de la interfaz IStudentRepository puede ser sustituida por cualquier otra implementación que respete la interfaz.
public class StudentRepository : IStudentRepository
{
    private List<Student> students = new List<Student>();

    public void AddStudent(Student student)
    {
        students.Add(student);
    }

    public List<Student> GetAllStudents()
    {
        return students;
    }

    public void UpdateStudent(Student student)
    {
        var existingStudent = students.Find(s => s.Id == student.Id);
        if (existingStudent != null)
        {
            existingStudent.Name = student.Name;
            existingStudent.Age = student.Age;
        }
    }

    public void RemoveStudent(int id)
    {
        var student = students.Find(s => s.Id == id);
        if (student != null)
        {
            students.Remove(student);
        }
    }
}

// Principio de Segregación de Interfaces (ISP)
// Las interfaces deben ser específicas y no obligar a implementar métodos innecesarios.
public interface IStudentService
{
    void RegisterStudent(Student student);
    List<Student> RetrieveAllStudents();
    void ModifyStudent(Student student);
    void DeleteStudent(int id);
}

// Principio de Inversión de Dependencia (DIP)
// Esta clase depende de abstracciones (interfaces) en lugar de implementaciones concretas.
public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;

    public StudentService(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public void RegisterStudent(Student student)
    {
        _studentRepository.AddStudent(student);
    }

    public List<Student> RetrieveAllStudents()
    {
        return _studentRepository.GetAllStudents();
    }

    public void ModifyStudent(Student student)
    {
        _studentRepository.UpdateStudent(student);
    }

    public void DeleteStudent(int id)
    {
        _studentRepository.RemoveStudent(id);
    }
}

// Programa principal para probar el sistema de gestión de estudiantes
class Program
{
    static void Main(string[] args)
    {
        IStudentRepository studentRepository = new StudentRepository();
        IStudentService studentService = new StudentService(studentRepository);

        // Registrar nuevos estudiantes
        studentService.RegisterStudent(new Student { Id = 1, Name = "Juan", Age = 20 });
        studentService.RegisterStudent(new Student { Id = 2, Name = "Ana", Age = 22 });

        // Listar todos los estudiantes registrados
        var students = studentService.RetrieveAllStudents();
        Console.WriteLine("Estudiantes registrados:");
        foreach (var student in students)
        {
            Console.WriteLine($"ID: {student.Id}, Nombre: {student.Name}, Edad: {student.Age}");
        }

        // Actualizar la información de un estudiante
        studentService.ModifyStudent(new Student { Id = 1, Name = "Juan Pérez", Age = 21 });

        // Eliminar un estudiante
        studentService.DeleteStudent(2);

        // Listar todos los estudiantes después de las actualizaciones
        students = studentService.RetrieveAllStudents();
        Console.WriteLine("\nEstudiantes después de las actualizaciones:");
        foreach (var student in students)
        {
            Console.WriteLine($"ID: {student.Id}, Nombre: {student.Name}, Edad: {student.Age}");
        }
    }
}

