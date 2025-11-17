using ShapesApp.Models;
using ShapesApp.Services;
using System.Windows.Input;

namespace ShapesApp.ViewModels;

/// <summary>
/// Модель представления главного окна:
/// хранит список фигур, меняет их цвета и порядок,
/// а также сообщает окну, когда нужно перерисовать фигуры.
/// </summary>
public class MainWindowViewModel
{
    readonly List<DrawableShape> _shapes = new();
    readonly IShapesFactory _shapesFactory;
    readonly IBrightColorService _colorService;

    public IReadOnlyList<DrawableShape> Shapes => _shapes;

    public ICommand ChangeColorsCommand { get; }
    public ICommand ShuffleShapesCommand { get; }

    public event EventHandler? ShapesChanged;

    public MainWindowViewModel(IShapesFactory shapesFactory,
                               IBrightColorService colorService)
    {
        _shapesFactory = shapesFactory;
        _colorService  = colorService;

        ChangeColorsCommand  = new RelayCommand(ChangeColors);
        ShuffleShapesCommand = new RelayCommand(ShuffleShapes);

        ResetShapesToDefaultOrder();
    }

    void ResetShapesToDefaultOrder()
    {
        var defaultOrder    = Enum.GetValues<ShapeKind>();
        var geometryShapes  = _shapesFactory.CreateShapes(defaultOrder);

        _shapes.Clear();
        foreach (var geo in geometryShapes)
        {
            var fill = _colorService.GetRandomBrightBrush();
            _shapes.Add(new DrawableShape(geo, fill));
        }

        OnShapesChanged();
    }

    void ChangeColors()
    {
        foreach (var drawable in _shapes)
        {
            drawable.Fill = _colorService.GetRandomBrightBrush();
        }

        OnShapesChanged();
    }

    void ShuffleShapes()
    {
        var order = Enum.GetValues<ShapeKind>().ToList();

        for (int i = order.Count - 1; i > 0; i--)
        {
            int j = Random.Shared.Next(i + 1);
            (order[i], order[j]) = (order[j], order[i]);
        }

        var geometryShapes = _shapesFactory.CreateShapes(order);

        _shapes.Clear();
        foreach (var geo in geometryShapes)
        {
            var fill = _colorService.GetRandomBrightBrush();
            _shapes.Add(new DrawableShape(geo, fill));
        }

        OnShapesChanged();
    }

    void OnShapesChanged() =>
        ShapesChanged?.Invoke(this, EventArgs.Empty);
}