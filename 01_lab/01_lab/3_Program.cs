using System;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("Введите периметр равностороннего треугольника:");
        string input = Console.ReadLine();

        if (double.TryParse(input, out double perimeter) && perimeter > 0)
        {
            double side = perimeter / 3;
            double area = Math.Sqrt(3) / 4 * Math.Pow(side, 2);

            Console.WriteLine("Сторона\tПлощадь");
            Console.WriteLine($"{side:F2}\t{area:F2}");
        }
        else
        {
            Console.WriteLine("Некорректный ввод");
        }
    }
}
