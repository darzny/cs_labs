
using System;

public class SwapTest
{
    public static void Main1()
    {
        int x;
        int y;

        Console.WriteLine("Enter the first value: ");
        x = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the second value: ");
        y = int.Parse(Console.ReadLine());


        Console.WriteLine($"Before swap: x was {x}, and y was {y}");

        Swap(ref x, ref y);

        Console.WriteLine($"After swap: x is {x}, and y is {y}");
    }

    public static void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        a = b;
        b = temp;
    }
}
