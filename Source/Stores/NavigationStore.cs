using Source.ViewModels;
using System;

namespace Source.Stores;

public class NavigationStore
{
    public event Action? CurrentViewModelChanged;

    private BaseViewModel? _currentViewModel;

    public BaseViewModel? CurrentViewModel
    {
        get { return _currentViewModel; }
        set { 
            _currentViewModel = value;
            CurrentViewModelChanged?.Invoke();
        }
    }
}