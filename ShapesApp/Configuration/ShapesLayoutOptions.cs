namespace ShapesApp.Configuration;

/// <summary>
/// Настройки размещения фигур: размеры Canvas, отступы и размеры фигур
/// </summary>
public class ShapesLayoutOptions
{
    /// <summary>Ширина области рисования.</summary>
    public double CanvasWidth  { get; set; }

    /// <summary>Высота области рисования.</summary>
    public double CanvasHeight { get; set; }

    /// <summary>Расстояние между фигурами.</summary>
    public double Gap          { get; set; }

    /// <summary>Базовая высота фигур.</summary>
    public double FigureHeight { get; set; }

    /// <summary>Ширина прямоугольника.</summary>
    public double RectWidth    { get; set; }
}
