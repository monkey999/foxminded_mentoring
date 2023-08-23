using System;
using System.Windows.Input;
using Task10.State.Navigators;
using Task10.ViewModels;
using Task10.ViewModels.Factories.AbstractFactories;

namespace Task10.Commands.Main
{
    public class UpdateCurrentViewModelCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        public readonly INavigator _navigator;
        private readonly IRootViewModelFactory _viewModelAbstractFactory;

        public UpdateCurrentViewModelCommand(INavigator navigator, IRootViewModelFactory viewModelAbstractFactory)
        {
            _navigator = navigator;
            _viewModelAbstractFactory = viewModelAbstractFactory;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (parameter is ViewType viewType)
            {
                _navigator.CurrentViewModel = _viewModelAbstractFactory.CreateViewModel(viewType);
            }
        }
    }
}
