using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;
using GeometryLib.Shapes;
using ShapesApp.Models;

namespace ShapesApp.Rendering;

/// <summary>
/// Прорисовка фигур на Canvas
/// </summary>
public class ShapesRenderer : IShapesRenderer
{
    public void Render(Canvas canvas, IEnumerable<DrawableShape> shapes)
    {
        canvas.Children.Clear();

        foreach (var drawable in shapes)
        {
            var shape = drawable.Geometry;
            var fill  = drawable.Fill;

			System.Windows.Shapes.Shape uiShape;

            switch (shape)
            {
                case Circle c:
                    uiShape = new Ellipse
					{
                        Width  = c.Radius * 2,
                        Height = c.Radius * 2,
                        Fill   = fill,
                        Stroke = Brushes.Black,
                        StrokeThickness = 2
                    };
					Canvas.SetLeft(uiShape, c.X);
					Canvas.SetTop(uiShape,  c.Y);
                    break;

                case GeometryLib.Shapes.Rectangle r:
                    uiShape = new System.Windows.Shapes.Rectangle
                    {
                        Width  = r.Width,
                        Height = r.Height,
                        Fill   = fill,
                        Stroke = Brushes.Black,
                        StrokeThickness = 2
                    };
					Canvas.SetLeft(uiShape, r.X);
					Canvas.SetTop(uiShape,  r.Y);
                    break;

                case Triangle t:
                    var polygon = new Polygon
					{
                        Fill   = fill,
                        Stroke = Brushes.Black,
                        StrokeThickness = 2,
                        Points = new PointCollection
						{
                            new Point(t.X + t.Width / 2, t.Y),
                            new Point(t.X, t.Y + t.Height),
                            new Point(t.X + t.Width, t.Y + t.Height)
                        }
                    };
                    uiShape = polygon;
                    break;

                default:
                    throw new NotSupportedException(
                        $"Тип фигуры '{shape.GetType().FullName}' не поддерживается рендерером.");
            }

            canvas.Children.Add(uiShape);
        }
    }
}