using Source.Repositories.Abstracts;
using Source.Repositories.Concretes;
using Source.ViewModels;
using Source.Views;
using System.Windows;

namespace Source;

public partial class App : Application
{
    void ApplicationStart(object sender, StartupEventArgs e)
    {
        ICarRepository repository = new CarRepository();

        MainView view = new MainView();
        view.DataContext = new MainViewModel(repository);
        view.Show();
    }
}
