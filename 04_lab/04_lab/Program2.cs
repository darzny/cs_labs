using System;
using System;

public class Program
{
    public static void Main1()
    {
        double target = 2023;
        double result = CalculateSquareRoot(target);

        Console.WriteLine(result);
        Console.WriteLine(result * result);
    }

    private static double CalculateSquareRoot(double number)
    {
        double x = 1;
        double oldx;
        do
        {
            oldx = x;
            x = (x + number / x) / 2;
        }
        while (oldx != x);

        return x;
    }
}
