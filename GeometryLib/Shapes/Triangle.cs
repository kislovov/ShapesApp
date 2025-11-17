namespace GeometryLib.Shapes;

public class Triangle : Shape
{
    public double Width  { get; set; }
    public double Height { get; set; }

    public Triangle(double x, double y, double width, double height)
    {
        X = x;
        Y = y;
        Width = width;
        Height = height;
    }

    public override double GetArea() => 0.5 * Width * Height;
}