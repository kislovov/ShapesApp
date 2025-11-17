using System.Windows.Media;

namespace ShapesApp.Services;

/// <summary>
/// Реализация сервиса ярких цветов:
/// генерирует случайные, насыщенные цвета для фигур.
/// </summary>
public class BrightColorService : IBrightColorService
{
    readonly Random _random = new();

    public Brush GetRandomBrightBrush()
    {
        double h = _random.NextDouble() * 360.0;
        double s = 0.9;
        double v = 1.0;

        (byte r, byte g, byte b) = HsvToRgb(h, s, v);

        return new SolidColorBrush(Color.FromRgb(r, g, b));
    }

    static (byte r, byte g, byte b) HsvToRgb(double h, double s, double v)
    {
        double c = v * s;
        double x = c * (1 - Math.Abs(h / 60.0 % 2 - 1));
        double m = v - c;

        double r1 = 0, g1 = 0, b1 = 0;

        if (h < 60)
        {
            r1 = c; g1 = x; b1 = 0;
        }
        else if (h < 120)
        {
            r1 = x; g1 = c; b1 = 0;
        }
        else if (h < 180)
        {
            r1 = 0; g1 = c; b1 = x;
        }
        else if (h < 240)
        {
            r1 = 0; g1 = x; b1 = c;
        }
        else if (h < 300)
        {
            r1 = x; g1 = 0; b1 = c;
        }
        else
        {
            r1 = c; g1 = 0; b1 = x;
        }

        byte r = (byte)Math.Round((r1 + m) * 255);
        byte g = (byte)Math.Round((g1 + m) * 255);
        byte b = (byte)Math.Round((b1 + m) * 255);

        return (r, g, b);
    }
}