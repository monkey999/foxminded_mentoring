namespace Task10.ViewModels.Factories.ViewModelFactories
{
    public interface IViewModelFactory<T> where T : ViewModelBase
    {
        T CreateViewModel();
    }
}
