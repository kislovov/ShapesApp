using GeometryLib.Shapes;
using ShapesApp.Models;

namespace ShapesApp.Services;

/// <summary>
/// Контракт фабрики фигур: умеет создавать набор фигур по заданному порядку.
/// </summary>
public interface IShapesFactory
{
	/// <summary>
	/// Создание списка фигур в указанном порядке.
	/// </summary>
	/// <param name="order">Порядок типов фигур, в котором нужно их создать.</param>
	/// <returns>Список созданных фигур.</returns>
	List<Shape> CreateShapes(IList<ShapeKind> order);
}