using A_Domain.Repo_interfaces;
using System.Windows.Input;
using Task10.Commands;
using Task10.Commands.Groups;
using Task10.Models;
using Task10.State.Navigators;

namespace Task10.ViewModels
{
    public class UpdateGroupViewModel : ViewModelBase
    {
        public readonly INavigator _navigator;
        public readonly IUnitOfWork _unitOfWork;
        public GroupViewModel groupToUpdate;

        private string _name;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public UpdateGroupViewModel(IUnitOfWork unitOfWork, INavigator navigator, GroupViewModel group)
        {
            _navigator = navigator;
            _unitOfWork = unitOfWork;

            groupToUpdate = group;

            Name = group.Name;

            SubmitCommand = new UpdateGroupCommand(this, unitOfWork);
            CancelCommand = new RelayCommand(param =>
            {
                _navigator.CurrentViewModel = GroupsViewModel.LoadGroupsViewModel(_unitOfWork, _navigator);
            });
        }
    }
}
