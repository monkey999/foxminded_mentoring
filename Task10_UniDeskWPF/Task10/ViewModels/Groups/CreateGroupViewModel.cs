using A_Domain.Repo_interfaces;
using System.Windows.Input;
using Task10.Commands;
using Task10.Commands.Groups;
using Task10.State.Navigators;

namespace Task10.ViewModels
{
    public class CreateGroupViewModel : ViewModelBase
    {
        public readonly INavigator _navigator;
        public readonly IUnitOfWork _unitOfWork;

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

        private int _courseId;

        public int CourseId
        {
            get
            {
                return _courseId;
            }
            set
            {
                _courseId = value;
                OnPropertyChanged(nameof(CourseId));
            }
        }

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public CreateGroupViewModel(IUnitOfWork unitOfWork, INavigator navigator)
        {
            _navigator = navigator;
            _unitOfWork = unitOfWork;

            SubmitCommand = new CreateGroupCommand(this, unitOfWork);
            CancelCommand = new RelayCommand(param =>
            {
                _navigator.CurrentViewModel = GroupsViewModel.LoadGroupsViewModel(_unitOfWork, _navigator);
            });
        }
    }
}
