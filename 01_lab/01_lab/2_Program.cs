using System;
using Internal;

internal class Program
{
    private static void Main(string[] args)
    {
        DivideIt();
    }

    private static void DivideIt()
    {
        try
        {
            Console.WriteLine("Please enter the first integer:");
            if (!int.TryParse(Console.ReadLine(), out int i))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
                return;
            }

            Console.WriteLine("Please enter the second integer:");
            if (!int.TryParse(Console.ReadLine(), out int j) || j == 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid non-zero integer.");
                return;
            }

            int k = i / j;

            string resultMessage = $"The result of dividing {i} by {j} is {k}";

            Console.WriteLine(resultMessage);
        }
        catch (Exception e)
        {
            Console.WriteLine("An exception was thrown: {0}", e.Message);
        }
    }
}
