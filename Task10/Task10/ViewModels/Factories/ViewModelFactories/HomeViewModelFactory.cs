namespace Task10.ViewModels.Factories.ViewModelFactories
{
    public class HomeViewModelFactory : IViewModelFactory<HomeViewModel>
    {
        private readonly IViewModelFactory<CoursesViewModel> _coursesViewModelFactory;

        public HomeViewModelFactory(IViewModelFactory<CoursesViewModel> coursesViewModelFactory)
        {
            _coursesViewModelFactory = coursesViewModelFactory;
        }

        public HomeViewModel CreateViewModel()
        {
            return new HomeViewModel(_coursesViewModelFactory.CreateViewModel());
        }
    }
}
