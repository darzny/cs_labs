using System;

namespace TriangleLab
{
    class Triangle
    {
        private double sideA;
        private double sideB;
        private double sideC;

        public Triangle(double a, double b, double c)
        {
            sideA = a;
            sideB = b;
            sideC = c;
        }

        public bool IsValidTriangle()
        {
            return (sideA + sideB > sideC) && (sideA + sideC > sideB) && (sideB + sideC > sideA);
        }

        public double CalculateArea()
        {
            if (!IsValidTriangle())
            {
                return 0;
            }

            double s = (sideA + sideB + sideC) / 2;
            return Math.Sqrt(s * (s - sideA) * (s - sideB) * (s - sideC));
        }

        public double CalculatePerimeter()
        {
            if (!IsValidTriangle())
            {
                return 0;
            }
            return sideA + sideB + sideC;
        }

        public void PrintSides()
        {
            Console.WriteLine($"SideA: {sideA}; SideB: {sideB}; SideC: {sideC}");
        }

        public void PrintIsValid()
        {
            bool isValid = IsValidTriangle();
            string answer = isValid ? "valid" : "not valid";

            Console.WriteLine($"Triangle is {answer}");
        }

        public void PrintArea()
        {
            Console.WriteLine($"Triangle Area: {CalculateArea()}");
        }

        public void PrintPerimeter()
        {
            Console.WriteLine($"Triangle Perimeter: {CalculatePerimeter()}");
        }

        public void PrintAllInfo()
        {
            PrintSides();
            PrintIsValid();
            PrintArea();
            PrintPerimeter();
        }
    }

    internal class Program
    {
        private static void Main1(string[] args)
        {
            double a = GetSideFromUser("SideA");
            double b = GetSideFromUser("SideB");
            double c = GetSideFromUser("SideC");

            Triangle triangle = new Triangle(a, b, c);
            triangle.PrintAllInfo();
        }

        private static double GetSideFromUser(string sideName)
        {
            double side;
            while (true)
            {
                Console.Write($"Enter {sideName}: ");
                if (double.TryParse(Console.ReadLine(), out side) && side > 0)
                {
                    return side;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a positive number.");
                }
            }
        }
    }
}

