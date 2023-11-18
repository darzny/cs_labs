using System;

struct Distance
{
    public int Feet;
    public int Inches;
    private const int InchesPerFoot = 12;

    public Distance(int feet, int inches)
    {
        Feet = feet + inches / InchesPerFoot;
        Inches = inches % InchesPerFoot;
    }

    public static Distance Add(Distance d1, Distance d2)
    {
        return new Distance(d1.Feet + d2.Feet, d1.Inches + d2.Inches);
    }

    public void PrintResult()
    {
        Console.WriteLine($"{Feet}'- {Inches}\"");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Distance? d1 = ReadDistance();
        if (!d1.HasValue)
        {
            return;
        }

        Distance? d2 = ReadDistance();
        if (!d2.HasValue)
        {
            return;
        }

        Distance sum = Distance.Add(d1.Value, d2.Value);

        Console.WriteLine("Сумма расстояний:");
        sum.PrintResult();
    }

    static Distance? ReadDistance()
    {
        Console.Write("Введите футы: ");
        if (!int.TryParse(Console.ReadLine(), out int feet))
        {
            Console.WriteLine("Некорректный ввод футов.");
            return null;
        }

        Console.Write("Введите дюймы: ");
        if (!int.TryParse(Console.ReadLine(), out int inches))
        {
            Console.WriteLine("Некорректный ввод дюймов.");
            return null;
        }

        return new Distance(feet, inches);
    }
}
