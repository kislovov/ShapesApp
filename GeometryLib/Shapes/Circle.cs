using System;

namespace GeometryLib.Shapes;

public class Circle : Shape
{
    public double Radius { get; set; }

    public Circle(double x, double y, double radius)
    {
        X = x;
        Y = y;
        Radius = radius;
    }

    public override double GetArea() => Math.PI * Radius * Radius;
}