﻿using System;

namespace HelloWorld
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Введите число");
            if (!int.TryParse(Console.ReadLine(), out int number) || number < 0)
            {
                Console.WriteLine("Неверное число");
                return;
            }

            int sum = 0;

            while (number > 0)
            {
                sum += number % 10;
                number = number / 10;
            }


            Console.WriteLine(sum);
        }
    }
}
