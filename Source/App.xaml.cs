using Autofac;
using Microsoft.Extensions.Configuration;
using Source.Repositories.Abstracts;
using Source.Repositories.Concretes;
using Source.Stores;
using Source.ViewModels;
using Source.Views;
using System.Windows;

namespace Source;

public partial class App : Application
{

    public static IContainer? Container { get; set; }

    protected override void OnStartup(StartupEventArgs e)
    {

        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();


        // var omdbKey = configuration.GetSection("omdbKey").Value;
        // var str = configuration.GetConnectionString("myDb2");







        // Register

        var containerBuilder = new ContainerBuilder();


        NavigationStore navigationStore = new();


        containerBuilder.RegisterType<FakeCarRepository>()
            .As<ICarRepository>()
            .InstancePerLifetimeScope();


        containerBuilder.RegisterType<MainViewModel>();
        containerBuilder.RegisterType<HomeViewModel>();
        containerBuilder.RegisterType<AddViewModel>();

        containerBuilder.RegisterInstance(navigationStore)
            .SingleInstance();

        Container = containerBuilder.Build();




        navigationStore.CurrentViewModel = Container.Resolve<HomeViewModel>();



        MainView view = new();
        view.DataContext = Container.Resolve<MainViewModel>();
        view.Show();

    }

}
