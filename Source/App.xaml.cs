using Autofac;
using Microsoft.Extensions.Configuration;
using Source.Repositories.Abstracts;
using Source.Repositories.Concretes;
using Source.ViewModels;
using Source.Views;
using System.Windows;

namespace Source;

public partial class App : Application
{

    protected override void OnStartup(StartupEventArgs e)
    {
        // base.OnStartup(e);

        /*
        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();



        var omdbKey = configuration.GetSection("omdbKey").Value;
        var str = configuration.GetConnectionString("myDb2");

        MessageBox.Show(omdbKey);
        MessageBox.Show(str);

        */


        var containerBuilder = new ContainerBuilder();

        // Register
        containerBuilder.RegisterType<MainViewModel>().AsSelf();
        containerBuilder.RegisterType<FakeCarRepository>().As<ICarRepository>();

        var container = containerBuilder.Build();







        
        MainView view = new();
        view.DataContext = container.Resolve<MainViewModel>();
        view.Show();

    }

}
