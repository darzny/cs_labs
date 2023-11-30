using System.Drawing;

public abstract class Shape
{
    public abstract double Perimeter();
    public abstract double Area();

    public abstract void DisplayDimensions();
}

public interface IRotatable
{
    void Rotate();
}

public class Triangle : Shape, IRotatable
{
    private readonly double sideA, sideB, sideC;

    public Triangle(double side1, double side2, double side3)
    {
        sideA = side1;
        sideB = side2;
        sideC = side3;
    }

    public override double Perimeter()
    {
        return sideA + sideB + sideC;
    }

    public override double Area()
    {
        double p = Perimeter() / 2;
        double area = Math.Sqrt(p * (p - sideA) * (p - sideB) * (p - sideC));
        return area;
    }

    public override void DisplayDimensions()
    {
        Console.WriteLine($"Размеры треугольника: {sideA}, {sideB}, {sideC}");
    }

    public void Rotate()
    {
        Console.WriteLine("Треугольник вращается вокруг своего центра");
    }
}

public class Circle : Shape
{
    public double radius { get; private set; }

    public Circle(double r)
    {
        radius = r;
    }

    public override double Perimeter()
    {
        return 2 * Math.PI * radius;
    }

    public override double Area()
    {
        return Math.PI * Math.Pow(radius, 2); ;
    }

    public override void DisplayDimensions()
    {
        Console.WriteLine($"Радиус окружности: {radius}");
    }
}

public class Square : Shape, IRotatable
{
    public double side { get; private set; }

    public Square(double s)
    {
        side = s;
    }

    public override double Perimeter()
    {
        return 4 * side;
    }

    public override double Area()
    {
        return Math.Pow(side, 2);
    }

    public override void DisplayDimensions()
    {
        Console.WriteLine($"Сторона квадрата: {side}");
    }

    public void Rotate()
    {
        Console.WriteLine("Квадрат вращается вокруг своего центра");
    }
}
