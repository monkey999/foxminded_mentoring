using System.Windows.Input;
using Task10.Commands;
using Task10.Commands.Main;
using Task10.Models;
using Task10.ViewModels;
using Task10.ViewModels.Factories.AbstractFactories;

namespace Task10.State.Navigators
{
    public class Navigator : ObservableObject, INavigator
    {
        private ViewModelBase _currentViewModel;

        public ViewModelBase CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }

            set
            {
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }
    }
}
