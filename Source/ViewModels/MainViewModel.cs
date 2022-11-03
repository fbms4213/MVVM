using Source.Models;
using Source.Repositories.Abstracts;
using Source.ViewModels.Command;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;


namespace Source.ViewModels;

public class MainViewModel : BaseViewModel
{
    private readonly ICarRepository _repository;
    public ObservableCollection<Car> Cars { get; set; }



    private Car _selectedCar;
    public Car SelectedCar
    {
        get => _selectedCar;

        set
        {
            _selectedCar = value;
            NotifyPropertyChanged();
        }
    }



    public ICommand ShowCommand { get; set; }
    public ICommand AddCommand { get; set; }
    public ICommand EditCommand { get; set; }
    public ICommand DeleteCommand { get; set; }


  

    public MainViewModel(ICarRepository repository)
    {
        _repository = repository;


        Cars = new(_repository.GetList() ?? new List<Car>());


        ShowCommand = new RelayCommand(ExecuteShowCommand, CanExecuteShowCommand);
        AddCommand = new RelayCommand(ExecuteAddCommand, CanExecuteAddCommand);
        EditCommand = new RelayCommand(ExecuteEditCommand, CanExecuteEditCommand);
        // DeleteCommand = new RelayCommand(ExecuteDeleteCommand, CanExecuteDeleteCommand);
    }


    public MainViewModel(ICarRepository repository, int a)
    {
        MessageBox.Show(a.ToString());
    }



    private void ExecuteShowCommand(object? parameter)
        => MessageBox.Show(SelectedCar.Model);


    private bool CanExecuteShowCommand(object? parameter)
        => SelectedCar is not null;



    private void ExecuteAddCommand(object? parameter)
    {
        // some code

        // _repository.Add(car);
    }

    private bool CanExecuteAddCommand(object? parameter)
      => true;




    private void ExecuteEditCommand(object? parameter)
    {
        // some code

        // _repository.Update(car);
    }

    private bool CanExecuteEditCommand(object? parameter)
      => true;
}