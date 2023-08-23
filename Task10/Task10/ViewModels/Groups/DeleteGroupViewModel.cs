using A_Domain.Repo_interfaces;
using System.Windows.Input;
using Task10.Commands;
using Task10.Commands.Groups;
using Task10.State.Navigators;

namespace Task10.ViewModels
{
    public class DeleteGroupViewModel : ViewModelBase
    {
        public readonly INavigator _navigator;
        public readonly IUnitOfWork _unitOfWork;

        private int _groupId;

        public int GroupId
        {
            get
            {
                return _groupId;
            }
            set
            {
                _groupId = value;
                OnPropertyChanged(nameof(GroupId));
            }
        }

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public DeleteGroupViewModel(IUnitOfWork unitOfWork, INavigator navigator)
        {
            _navigator = navigator;
            _unitOfWork = unitOfWork;

            SubmitCommand = new DeleteGroupByIdCommand(this, unitOfWork);

            CancelCommand = new RelayCommand(param =>
            {
                _navigator.CurrentViewModel = GroupsViewModel.LoadGroupsViewModel(_unitOfWork, _navigator);
            });
        }
    }
}
