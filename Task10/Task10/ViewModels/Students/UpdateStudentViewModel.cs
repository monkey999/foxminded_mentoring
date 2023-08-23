using A_Domain.Repo_interfaces;
using System.Windows.Input;
using Task10.Commands;
using Task10.State.Navigators;
using Task10.Commands.Students;

namespace Task10.ViewModels
{
    public class UpdateStudentViewModel : ViewModelBase
    {
        public readonly INavigator _navigator;
        public readonly IUnitOfWork _unitOfWork;
        public StudentViewModel studentToUpdate;

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

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public UpdateStudentViewModel(IUnitOfWork unitOfWork, INavigator navigator, StudentViewModel student)
        {
            _navigator = navigator;
            _unitOfWork = unitOfWork;

            studentToUpdate = student;

            FirstName = student.FirstName;
            LastName = student.LastName;

            SubmitCommand = new UpdateStudentCommand(this, unitOfWork);
            CancelCommand = new RelayCommand(param =>
            {
                _navigator.CurrentViewModel = StudentsViewModel.LoadStudentsViewModel(_unitOfWork, _navigator);
            });
        }
    }
}
