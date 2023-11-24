using System;

public class SquareRootSolver
{
    public static (int flag, double x1, double x2) SolveSquareRoot(double a, double b, double c)
    {
        double discriminant = b * b - 4 * a * c;

        if (discriminant > 0)
        {
            double x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
            double x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
            return (1, x1, x2);
        }
        else if (discriminant == 0)
        {
            double x = -b / (2 * a);
            return (0, x, x);
        }
        else
        {
            return (-1, 0, 0);
        }
    }
}

class Program
{
    static void Main1()
    {
        Console.WriteLine("Введите коэффициенты квадратного уравнения (a, b, c):");
        double a = Convert.ToDouble(Console.ReadLine());
        double b = Convert.ToDouble(Console.ReadLine());
        double c = Convert.ToDouble(Console.ReadLine());

        var result = SquareRootSolver.SolveSquareRoot(a, b, c);

        if (result.flag == 1)
        {
            Console.WriteLine($"Корни уравнения с коэффициентами a = {a}, b = {b}, c = {c}: x1 = {result.x1}, x2 = {result.x2}");
        }
        else if (result.flag == 0)
        {
            Console.WriteLine($"Корень уравнения с коэффициентами a = {a}, b = {b}, c = {c}: x1 = x2 = {result.x1}");
        }
        else
        {
            Console.WriteLine($"Корней уравнения с коэффициентами a = {a}, b = {b}, c = {c} нет.");
        }
    }
}
