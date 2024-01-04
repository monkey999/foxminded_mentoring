using Task10.State.Navigators;

namespace Task10.ViewModels.Factories.AbstractFactories
{
    public interface IRootViewModelFactory
    {
        ViewModelBase CreateViewModel(ViewType viewType);
    }
}
