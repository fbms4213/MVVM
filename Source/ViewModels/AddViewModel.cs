using Autofac;
using Source.Stores;
using Source.ViewModels.Command;
using System.Windows.Input;

namespace Source.ViewModels
{
    public class AddViewModel : BaseViewModel
    {
        private readonly NavigationStore _navigation;

        public ICommand? AddCommand { get; set; }
        public ICommand? CancelCommand { get; set; }

        public AddViewModel(NavigationStore navigation)
        {
            _navigation = navigation;
            CancelCommand = new RelayCommand(ExecuteCancelCommand);
        }


        private void ExecuteCancelCommand(object? parameter)
        {
            _navigation.CurrentViewModel = App.Container?.Resolve<HomeViewModel>();
        }


    }
}
