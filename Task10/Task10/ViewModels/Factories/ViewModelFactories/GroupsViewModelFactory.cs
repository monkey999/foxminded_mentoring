using A_Domain.Repo_interfaces;
using Task10.State.Navigators;
using Task10.ViewModels.Factories.AbstractFactories;

namespace Task10.ViewModels.Factories.ViewModelFactories
{
    public class GroupsViewModelFactory : IViewModelFactory<GroupsViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        public readonly INavigator _navigator;

        public GroupsViewModelFactory(IUnitOfWork unitOfWork, INavigator navigator)
        {
            _unitOfWork = unitOfWork;
            _navigator = navigator;
        }

        public GroupsViewModel CreateViewModel()
        {
            return GroupsViewModel.LoadGroupsViewModel(_unitOfWork, _navigator);
        }
    }
}
