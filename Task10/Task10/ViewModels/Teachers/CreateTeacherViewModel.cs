using A_Domain.Repo_interfaces;
using System.Windows.Input;
using Task10.Commands;
using Task10.State.Navigators;
using Task10.Commands.Teachers;

namespace Task10.ViewModels
{
    public class CreateTeacherViewModel : ViewModelBase
    {
        public readonly INavigator _navigator;
        public readonly IUnitOfWork _unitOfWork;

        private string _fullName;

        public string FullName
        {
            get
            {
                return _fullName;
            }
            set
            {
                _fullName = value;
                OnPropertyChanged(nameof(FullName));
            }
        }

        private string _firstName;

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        private string _lastName;

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public CreateTeacherViewModel(IUnitOfWork unitOfWork, INavigator navigator)
        {
            _navigator = navigator;
            _unitOfWork = unitOfWork;

            SubmitCommand = new CreateTeacherCommand(this, unitOfWork);
            CancelCommand = new RelayCommand(param =>
            {
                _navigator.CurrentViewModel = TeachersViewModel.LoadTeachersViewModel(_unitOfWork, _navigator);
            });
        }
    }
}
