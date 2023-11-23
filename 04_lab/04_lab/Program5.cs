
using System;

public class FactorialTest
{
    public static void Main1()
    {
        int x;
        bool ok;

        Console.WriteLine("Enter n fo Factorial: ");
        x = int.Parse(Console.ReadLine());

        ok = Factorial(x, out int f);

        if (ok)
        {
            Console.WriteLine($"Factorial {x} is {f}");
        }
        else
        {
            Console.WriteLine("Oops");
        };
    }

    public static bool Factorial(int n, out int answer)
    {
        int k;
        int f;
        bool ok = true;


        if (n < 0)
        {
            ok = false;
        }

        try
        {
            checked
            {
                f = 1;
                for (k = 2; k <= n; k++)
                {
                    f *= k;
                }
            }
        }
        catch(Exception)
        {
            f = 0;
            ok = false;
        }

        answer = f;

        return ok; 
    }
}
