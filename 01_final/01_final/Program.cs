using System;

public enum Faculty
{
    Mathematics,
    Physics,
    Literature,
    // Другие факультеты...
}

public enum Position
{
    JuniorManager,
    SeniorManager,
    SeniorTeacher,
    // Другие должности...
}

public interface IEmployee
{
    decimal CalculateSalary();
    int CalculateWorkExperience();
}

public abstract class Person
{
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }

    protected Person(string lastName, DateTime dateOfBirth)
    {
        LastName = lastName;
        DateOfBirth = dateOfBirth;
    }

    public int CalculateAge()
    {
        int age = DateTime.Now.Year - DateOfBirth.Year;
        if (DateOfBirth.Date > DateTime.Now.AddYears(-age)) age--;
        return age;
    }

    protected int CalculateYearsSince(DateTime startDate)
    {
        int years = DateTime.Now.Year - startDate.Year;
        if (startDate.Date > DateTime.Now.AddYears(-years)) years--;
        return years;
    }

    public abstract void DisplayInfo();
}

public abstract class Employee : Person, IEmployee
{
    public Position? Position { get; set; }
    public DateTime? StartDate { get; set; }

    protected Employee(string lastName, DateTime dateOfBirth, Position? position, DateTime? startDate)
        : base(lastName, dateOfBirth)
    {
        Position = position;
        StartDate = startDate;
    }

    public abstract decimal CalculateSalary();

    public virtual int CalculateWorkExperience()
    {
        return StartDate.HasValue ? CalculateYearsSince(StartDate.Value) : 0;
    }
}

public class Student : Person
{
    public Faculty Faculty { get; set; }
    public string Group { get; set; }

    public Student(string lastName, DateTime dateOfBirth, Faculty faculty, string group)
        : base(lastName, dateOfBirth)
    {
        Faculty = faculty;
        Group = group;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Студент: {LastName}, {CalculateAge()} лет, Факультет: {Faculty}, Группа: {Group}");
    }
}

public class Administrator : Employee
{
    public string Laboratory { get; set; }

    public Administrator(string lastName, DateTime dateOfBirth, string laboratory)
        : base(lastName, dateOfBirth, null, null)
    {
        Laboratory = laboratory;
    }

    public override decimal CalculateSalary()
    {
        return 0;
    }

    public override void DisplayInfo()
    {
        string experienceDisplay = StartDate.HasValue ? $", Стаж: {CalculateWorkExperience()} год(а)" : "";
        Console.WriteLine($"Администратор: {LastName}, {CalculateAge()} лет, Лаборатория: {Laboratory}{experienceDisplay}");
    }
}
public class Teacher : Employee
{
    public Faculty Faculty { get; set; }

    public Teacher(string lastName, DateTime dateOfBirth, Faculty faculty, Position position, DateTime startDate)
        : base(lastName, dateOfBirth, position, startDate)
    {
        Faculty = faculty;
    }

    public override decimal CalculateSalary()
    {
        return 10 * CalculateWorkExperience();
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Преподаватель: {LastName}, {CalculateAge()} лет, Факультет: {Faculty}, Должность: {Position}, Стаж: {CalculateWorkExperience()} год(а)");
    }
}

public class Manager : Employee
{
    public string Department { get; set; }

    public Manager(string lastName, DateTime dateOfBirth, string department, Position position, DateTime startDate)
        : base(lastName, dateOfBirth, position, startDate)
    {
        Department = department;
    }

    public override decimal CalculateSalary()
    {
        return 4 * CalculateWorkExperience();
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Менеджер: {LastName}, {CalculateAge()} лет, Отдел: {Department}, Должность: {Position}, Стаж: {CalculateWorkExperience()} год(а)");
    }
}

class Program
{
    static void Main(string[] args)
    {
        var persons = new List<Person>
        {
            new Administrator("Иванов", new DateTime(1980, 5, 20), "Лаборатория 1"),
            new Student("Петров", new DateTime(2000, 8, 15), Faculty.Physics, "Группа 101"),
            new Teacher("Сидоров", new DateTime(1995, 1, 15), Faculty.Mathematics, Position.SeniorTeacher, new DateTime(2010, 1, 15)),
            new Manager("Ким", new DateTime(1985, 1, 1), "Отдел 1", Position.JuniorManager, new DateTime(2022, 8, 11)),
        };

        foreach (var person in persons)
        {
            person.DisplayInfo();
        }
    }
}