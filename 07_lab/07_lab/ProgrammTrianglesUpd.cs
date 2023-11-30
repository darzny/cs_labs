using System;

namespace TrianglesConstructors
{
	public class Point
	{
        public double X { get; }
        public double Y { get; }

        public Point(double x, double y)
		{
			X = x;
			Y = y;
		}
	}

	public class TriangleAreaComparator : IComparer<Triangle>
	{
		public int Compare(Triangle x, Triangle y)
		{
			if (x == null || y == null)
			{
				throw new ArgumentException("Cannot compare null Triangles");
			}

			return x.Area().CompareTo(y.Area());
		}
	}


	public class Triangle
	{
		private Point p1, p2, p3;

		public Triangle(Point p1, Point p2, Point p3)
		{
			this.p1 = p1;
			this.p2 = p2;
			this.p3 = p3;
		}

		public Triangle(double a, double b, double c)
		{
            if (!IsValidTriangle(a, b, c))
			{
                throw new ArgumentException("Invalid side lengths for a triangle.");
            }

            p1 = new Point(0, 0);
			p2 = new Point(a, 0);
			double x3 = (Math.Pow(b, 2) - Math.Pow(c, 2) + Math.Pow(a, 2)) / (2 * a);
			double y3 = Math.Sqrt(Math.Pow(b, 2) - Math.Pow(x3, 2));
			p3 = new Point(x3, y3);
		}

		public Triangle(double side)
		{
            if (side <= 0)
			{
                throw new ArgumentException("Side length must be positive.");
            }

            p1 = new Point(0, 0);
			p2 = new Point(side, 0);
			p3 = new Point(side / 2, Math.Sqrt(3) / 2 * side);
		}

		private double Distance(Point a, Point b)
		{
			return Math.Sqrt(Math.Pow(b.X - a.X, 2) + Math.Pow(b.Y - a.Y, 2));
		}

        public bool IsValidTriangle(double a, double b, double c)
        {
            return a > 0 && b > 0 && c > 0 && a + b > c && a + c > b && b + c > a;
        }

        public bool IsValidTriangle()
        {
            double a = Distance(p1, p2);
            double b = Distance(p2, p3);
            double c = Distance(p3, p1);

            return IsValidTriangle(a, b, c);
        }

        public double Area()
        {
			if (!IsValidTriangle())
			{
				return 0;
			}

            double a = Distance(p1, p2);
            double b = Distance(p2, p3);
            double c = Distance(p3, p1);
            double s = (a + b + c) / 2;

            return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        }

        public override string ToString()
        {
            return IsValidTriangle() ? $"Triangle: Area = {Area():F2}" : "Not a valid triangle";
        }
	}

	class Program
	{
		static void Main(string[] args)
		{
			Triangle[] triangles = new Triangle[]
			{
				new Triangle(new Point(0, 0), new Point(1, 0), new Point(0, 1)),
				new Triangle(new Point(0, 0), new Point(2, 0), new Point(0, 2)),
				new Triangle(10, 15, 10),
				new Triangle(1),
			};

			Array.Sort(triangles, new TriangleAreaComparator());

			foreach (Triangle triangle in triangles)
			{
				Console.WriteLine(triangle);
			}
		}
	}
}
