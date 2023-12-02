using System;

class Distance
{
    public int Feet { get; private set; }
    public double Inches { get; private set; }

    private const int InchesInFeet = 12;

    public Distance()
    {
        Feet = 0;
        Inches = 0.0;
    }

    public Distance(int feet, double inches)
    {
        Feet = feet + (int)(inches / InchesInFeet);
        Inches = inches % InchesInFeet;
    }

    public static Distance operator +(Distance d1, Distance d2)
    {
        return new Distance(d1.Feet + d2.Feet, d1.Inches + d2.Inches);
    }

    public static Distance operator -(Distance d1, Distance d2)
    {
        int totalInches1 = d1.Feet * InchesInFeet + (int)d1.Inches;
        int totalInches2 = d2.Feet * InchesInFeet + (int)d2.Inches;
        int diff = Math.Abs(totalInches1 - totalInches2);
        return new Distance(diff / InchesInFeet, diff % InchesInFeet);
    }

    public override string ToString()
    {
        return $"{Feet}'- {Inches}\"";
    }

    public static bool operator ==(Distance d1, Distance d2)
    {
        return d1.Feet == d2.Feet && d1.Inches == d2.Inches;
    }

    public static bool operator !=(Distance d1, Distance d2)
    {
        return !(d1 == d2);
    }

    public override bool Equals(object obj)
    {
        if (obj is Distance)
        {
            Distance d = (Distance)obj;
            return this == d;
        }
        return false;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Distance d1 = ReadDistance();
        Distance d2 = ReadDistance();

        Distance sum = d1 + d2;
        Distance difference = d1 - d2;

        Console.WriteLine("Сумма расстояний:");
        Console.WriteLine(sum.ToString());

        Console.WriteLine("Разность расстояний:");
        Console.WriteLine(difference.ToString());

        Console.WriteLine($"Расстояния равны? {d1.Equals(d2)}");
        Console.WriteLine($"Расстояния равны? {d1 == d2}");
        Console.WriteLine($"Расстояния не равны? {d1 != d2}");
    }

    static Distance ReadDistance()
    {
        Console.Write("Введите футы: ");
        int feet = int.Parse(Console.ReadLine());

        Console.Write("Введите дюймы: ");
        double inches = double.Parse(Console.ReadLine());

        return new Distance(feet, inches);
    }
}
