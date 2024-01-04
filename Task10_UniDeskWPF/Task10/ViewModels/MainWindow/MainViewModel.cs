using System.Windows.Input;
using Task10.Commands.Main;
using Task10.State.Navigators;
using Task10.ViewModels.Factories.AbstractFactories;

namespace Task10.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public INavigator Navigator { get; set; }
        private readonly IRootViewModelFactory _rootViewModelFactory;
        public ICommand UpdateCurrentViewModelCommand { get; }
        public MainViewModel(INavigator navigator, IRootViewModelFactory rootViewModelFactory)
        {
            Navigator = navigator;
            _rootViewModelFactory = rootViewModelFactory;
            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator, _rootViewModelFactory);

            UpdateCurrentViewModelCommand.Execute(ViewType.Home);
        }
    }
}
