using ShapesApp.Models;
using System.Windows.Controls;

namespace ShapesApp.Rendering;

/// <summary>
/// Рендерер фигур
/// </summary>
public interface IShapesRenderer
{       
    /// <summary>
    /// Очищает Canvas и рисует на нём переданные фигуры
    /// </summary>
    /// <param name="canvas">Поверхность для рисования.</param>
    /// <param name="shapes">Набор фигур с геометрией и цветами.</param>
    void Render(Canvas canvas, IEnumerable<DrawableShape> shapes);
}