using A_Domain.Repo_interfaces;
using Task10.State.Navigators;

namespace Task10.ViewModels.Factories.ViewModelFactories
{
    public class CoursesViewModelFactory : IViewModelFactory<CoursesViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INavigator _navigator;

        public CoursesViewModelFactory(IUnitOfWork unitOfWork, INavigator navigator)
        {
            _unitOfWork = unitOfWork;
            _navigator = navigator;
        }

        public CoursesViewModel CreateViewModel()
        {
            return CoursesViewModel.LoadCoursesViewModel(_unitOfWork, _navigator);
        }
    }
}
