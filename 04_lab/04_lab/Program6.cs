using System;

public class Operation
{
    public static double CalculateTriangleArea(double a, double b, double c)
    {
        if (IsValidTriangle(a, b, c))
        {
            double s = (a + b + c) / 2;
            return Math.Round(Math.Sqrt(s * (s - a) * (s - b) * (s - c)), 2);
        }
        else
        {
            Console.WriteLine("Треугольник с заданными сторонами не существует.");
            return -1;
        }
    }

    private static bool IsValidTriangle(double a, double b, double c)
    {
        return a + b > c && a + c > b && b + c > a;
    }

    public static double CalculateEquilateralTriangleArea(double side)
    {
        if (IsValidTriangle(side, side, side))
        {
            return Math.Round((Math.Sqrt(3) / 4) * Math.Pow(side, 2), 2);
        }
        else
        {
            Console.WriteLine("Равносторонний треугольник с заданной стороной не существует.");
            return -1;
        }
    }

    class Program
    {
        static void Main1()
        {
            Console.WriteLine("Выберите тип треугольника:");
            Console.WriteLine("1. Обычный треугольник");
            Console.WriteLine("2. Равносторонний треугольник");
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                Console.WriteLine("Введите стороны треугольника:");
                double side1 = Convert.ToDouble(Console.ReadLine());
                double side2 = Convert.ToDouble(Console.ReadLine());
                double side3 = Convert.ToDouble(Console.ReadLine());

                double area = Operation.CalculateTriangleArea(side1, side2, side3);

                if (area != -1)
                {
                    Console.WriteLine($"Площадь треугольника: {area}");
                }
            }
            else if (choice == 2)
            {
                Console.WriteLine("Введите сторону равностороннего треугольника:");
                double side = Convert.ToDouble(Console.ReadLine());

                double area = Operation.CalculateEquilateralTriangleArea(side);

                if (area != -1)
                {
                    Console.WriteLine($"Площадь равностороннего треугольника: {area}");
                }
            }
            else
            {
                Console.WriteLine("Некорректный выбор.");
            };
        }
    }
}
