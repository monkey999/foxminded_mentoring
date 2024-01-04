using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task10.ViewModels;
using Task10.ViewModels.Factories.ViewModelFactories;

namespace Task10.State.Navigators
{
    public class ViewModelRenavigator<TViewModel> : IRenavigator where TViewModel : ViewModelBase
    {
        private readonly INavigator _navigator;
        private readonly IViewModelFactory<TViewModel> _viewModelFactory;

        public ViewModelRenavigator(INavigator navigator, IViewModelFactory<TViewModel> viewModelFactory)
        {
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
        }

        public void Renavigate()
        {
            _navigator.CurrentViewModel = _viewModelFactory.CreateViewModel();
        }
    }
}
