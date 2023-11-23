using System;

public class SquareRootSolver
{
    public static int SolveSquareRoot(double a, double b, double c, out double x1, out double x2)
    {
        double discriminant = b * b - 4 * a * c;

        if (discriminant > 0)
        {
            x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
            x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
            return 1;
        }
        else if (discriminant == 0)
        {
            x1 = x2 = -b / (2 * a);
            return 0;
        }
        else
        {
            x1 = x2 = 0;
            return -1;
        }
    }
}

class TestProgram
{
    static void Main()
    {
        Console.WriteLine("Введите коэффициенты квадратного уравнения (a, b, c):");
        double a = Convert.ToDouble(Console.ReadLine());
        double b = Convert.ToDouble(Console.ReadLine());
        double c = Convert.ToDouble(Console.ReadLine());

        double x1, x2;
        int result = SquareRootSolver.SolveSquareRoot(a, b, c, out x1, out x2);

        if (result == 1)
        {
            Console.WriteLine($"Корни уравнения с коэффициентами a = {a}, b = {b}, c = {c}: x1 = {x1}, x2 = {x2}");
        }
        else if (result == 0)
        {
            Console.WriteLine($"Корень уравнения с коэффициентами a = {a}, b = {b}, c = {c}: x1 = x2 = {x1}");
        }
        else
        {
            Console.WriteLine($"Корней уравнения с коэффициентами a = {a}, b = {b}, c = {c} нет.");
        }
    }
}
