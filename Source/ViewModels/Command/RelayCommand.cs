using System;
using System.Windows.Input;

namespace Source.ViewModels.Command;

public class RelayCommand : ICommand
{
    public event EventHandler? CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }


    private Action<object?> _execute;
    private Predicate<object?>? _canExecute;


    public RelayCommand(Action<object?> execute, Predicate<object?>? canExecute = null)
    {
        ArgumentNullException.ThrowIfNull(execute, nameof(execute));

        _execute = execute;
        _canExecute = canExecute;
    }


    public bool CanExecute(object? parameter)
        => _canExecute is null || _canExecute.Invoke(parameter);


    public void Execute(object? parameter)
        => _execute.Invoke(parameter);

}
