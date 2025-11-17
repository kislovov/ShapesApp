using System.Windows.Media;

namespace ShapesApp.Services;

/// <summary>
/// Сервис для получения ярких случайных цветов.
/// </summary>
public interface IBrightColorService
{
    /// <summary>
    /// Возвращает случайную яркую кисть для заливки фигуры.
    /// </summary>
    Brush GetRandomBrightBrush();
}