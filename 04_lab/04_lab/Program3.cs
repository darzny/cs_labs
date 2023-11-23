using System;

public class Test
{
    public static void Main1()
    {
        int x;
        int y;
        int greater;

        Console.WriteLine("Enter the first value: ");
        x = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the second value: ");
        y = int.Parse(Console.ReadLine());

        greater = Greater(x, y);
        Console.WriteLine($"The greater value is {greater}");
    }

    public static int Greater(int a, int b)
    {
        if (a > b) return a;
        else return b;
    }
}
