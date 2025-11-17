using System.Windows;
using ShapesApp.ViewModels;
using ShapesApp.Rendering;

namespace ShapesApp.Views;

public partial class MainWindow : Window
{
    readonly MainWindowViewModel _viewModel;
    readonly IShapesRenderer _renderer;

    public MainWindow(MainWindowViewModel viewModel, IShapesRenderer renderer)
    {
        InitializeComponent();

        _viewModel = viewModel;
        _renderer  = renderer;

        DataContext = _viewModel;

        _viewModel.ShapesChanged += (_, _) => Redraw();

        Redraw();
    }

    void Redraw()
    {
        _renderer.Render(DrawingCanvas, _viewModel.Shapes);
    }
}