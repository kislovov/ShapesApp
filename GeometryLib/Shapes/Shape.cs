namespace GeometryLib.Shapes;

public abstract class Shape
{
    public double X { get; set; }
    public double Y { get; set; }

    public virtual double GetArea() => 0;
}