namespace GeometryLib.Shapes;

public class Rectangle : Shape
{
    public double Width  { get; set; }
    public double Height { get; set; }

    public Rectangle(double x, double y, double width, double height)
    {
        X = x;
        Y = y;
        Width = width;
        Height = height;
    }

    public override double GetArea() => Width * Height;
}