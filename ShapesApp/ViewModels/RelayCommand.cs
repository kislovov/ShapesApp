using System.Windows.Input;

namespace ShapesApp.ViewModels;

/// <summary>
/// Команда для кнопок в MVVM: храним, что делать при нажатии
/// и нужно ли сейчас разрешать выполнение команды.
/// </summary>
public class RelayCommand : ICommand
{
    readonly Action _execute;
    readonly Func<bool>? _canExecute;

    public RelayCommand(Action execute, Func<bool>? canExecute = null)
    {
        _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        _canExecute = canExecute;
    }

    public bool CanExecute(object? parameter) => _canExecute?.Invoke() ?? true;

    public void Execute(object? parameter) => _execute();

    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }
}