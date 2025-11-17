using System.Windows.Media;
using GeometryLib.Shapes;

namespace ShapesApp.Models;

/// <summary>
/// Связка геометрической фигуры и её цвета для рисования
/// </summary>
public sealed class DrawableShape
{
    public Shape Geometry { get; }
    public Brush Fill { get; set; }

    public DrawableShape(Shape geometry, Brush fill)
    {
        Geometry = geometry ?? throw new ArgumentNullException(nameof(geometry));
        Fill = fill ?? throw new ArgumentNullException(nameof(fill));
    }
}