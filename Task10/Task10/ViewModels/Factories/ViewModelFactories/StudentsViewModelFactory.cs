using A_Domain.Repo_interfaces;
using Task10.State.Navigators;

namespace Task10.ViewModels.Factories.ViewModelFactories
{
    public class StudentsViewModelFactory : IViewModelFactory<StudentsViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        public readonly INavigator _navigator;

        public StudentsViewModelFactory(IUnitOfWork unitOfWork, INavigator navigator)
        {
            _unitOfWork = unitOfWork;
            _navigator = navigator;
        }

        public StudentsViewModel CreateViewModel()
        {
            return StudentsViewModel.LoadStudentsViewModel(_unitOfWork, _navigator);
        }
    }
}
