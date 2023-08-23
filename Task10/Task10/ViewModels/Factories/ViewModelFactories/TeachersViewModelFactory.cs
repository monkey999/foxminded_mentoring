using A_Domain.Repo_interfaces;
using Task10.State.Navigators;

namespace Task10.ViewModels.Factories.ViewModelFactories
{
    public class TeachersViewModelFactory : IViewModelFactory<TeachersViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        public readonly INavigator _navigator;

        public TeachersViewModelFactory(IUnitOfWork unitOfWork, INavigator navigator)
        {
            _unitOfWork = unitOfWork;
            _navigator = navigator;
        }

        public TeachersViewModel CreateViewModel()
        {
            return TeachersViewModel.LoadTeachersViewModel(_unitOfWork, _navigator);
        }
    }
}
