using System;

namespace Triangles
{
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
    }

    public class Triangle : IComparable
    {
        private Point p1, p2, p3;

        public Triangle(Point p1, Point p2, Point p3)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
        }

        private double Distance(Point a, Point b)
        {
            return Math.Sqrt(Math.Pow(b.X - a.X, 2) + Math.Pow(b.Y - a.Y, 2));
        }

        public bool Exists()
        {
            double a = Distance(p1, p2);
            double b = Distance(p2, p3);
            double c = Distance(p3, p1);

            return a + b > c && a + c > b && b + c > a;
        }

        private double Area()
        {
            if (!Exists()) return 0;

            double a = Distance(p1, p2);
            double b = Distance(p2, p3);
            double c = Distance(p3, p1);
            double s = (a + b + c) / 2;

            return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        }

        int IComparable.CompareTo(object obj)
        {
            Triangle other = obj as Triangle;
            if (other != null)
            {
                return this.Area().CompareTo(other.Area());
            }

            throw new ArgumentException("Object is not a Triangle");
        }

        public override string ToString()
        {
            return Exists() ? $"Triangle: Area = {Area():F2}" : "Not a valid triangle";
        }
    }

    class Program
    {
        static void Main2(string[] args)
        {
            Triangle[] triangles = new Triangle[]
            {
                new Triangle(new Point(0, 0), new Point(1, 0), new Point(0, 1)),
                new Triangle(new Point(0, 0), new Point(2, 0), new Point(0, 2)),
            };

            Array.Sort(triangles);

            foreach (Triangle triangle in triangles)
            {
                Console.WriteLine(triangle);
            }
        }
    }
}
