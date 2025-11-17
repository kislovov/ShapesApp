using GeometryLib.Shapes;
using ShapesApp.Configuration;
using ShapesApp.Models;

namespace ShapesApp.Services;

/// <summary>
/// Фабрика фигур: по заданному порядку создаёт набор геометрических фигур
/// и расставляет их по Canvas с нужными размерами и отступами.
/// </summary>
public class ShapesFactory : IShapesFactory
{
    readonly ShapesLayoutOptions _options;

    public ShapesFactory(ShapesLayoutOptions options)
    {
        _options = options;
    }

    public List<Shape> CreateShapes(IList<ShapeKind> order)
    {
        var shapes = new List<Shape>();
        if (order == null || order.Count == 0)
            return shapes;

        double gap          = _options.Gap;
        double figureHeight = _options.FigureHeight;

        double circleDiameter = figureHeight;
        double rectWidth      = _options.RectWidth;
        double squareSize     = figureHeight;
        double triangleWidth  = figureHeight;

        double GetWidth(ShapeKind kind) => kind switch
        {
            ShapeKind.Circle    => circleDiameter,
            ShapeKind.Rectangle => rectWidth,
            ShapeKind.Square    => squareSize,
            ShapeKind.Triangle  => triangleWidth,
            _ => throw new ArgumentOutOfRangeException(nameof(kind), kind, "Неизвестный тип фигуры ShapeKind.")
        };

        double totalWidth =
            order.Sum(GetWidth) +
            gap * (order.Count - 1);

        double startX = (_options.CanvasWidth  - totalWidth)   / 2.0;
        double topY   = (_options.CanvasHeight - figureHeight) / 2.0;

        double currentX = startX;

        foreach (var kind in order)
        {
            double width = GetWidth(kind);

            var shape = CreateShape(kind, currentX, topY, width, figureHeight);
            shapes.Add(shape);

            currentX += width + gap;
        }

        return shapes;
    }

    static Shape CreateShape(ShapeKind kind, double x, double topY, double width, double height) =>
        kind switch
        {
            ShapeKind.Circle => new Circle(
                x,
                topY,
                width / 2),

            ShapeKind.Rectangle => new Rectangle(
                x,
                topY,
                width,
                height),

            ShapeKind.Square => new Rectangle(
                x,
                topY,
                width,
                width),

            ShapeKind.Triangle => new Triangle(
                x,
                topY,
                width,
                height),

            _ => throw new ArgumentOutOfRangeException(
                nameof(kind),
                kind,
                "Неизвестный тип фигуры ShapeKind.")
        };
}