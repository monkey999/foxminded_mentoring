using A_Domain.Repo_interfaces;
using System.Windows.Input;
using Task10.Commands;
using Task10.Commands.Teachers;
using Task10.State.Navigators;

namespace Task10.ViewModels
{
    public class UpdateTeacherViewModel : ViewModelBase
    {
        public readonly INavigator _navigator;
        public readonly IUnitOfWork _unitOfWork;
        public TeacherViewModel teacherToUpdate;

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

        public UpdateTeacherViewModel(IUnitOfWork unitOfWork, INavigator navigator, TeacherViewModel teacher)
        {
            _navigator = navigator;
            _unitOfWork = unitOfWork;

            teacherToUpdate = teacher;

            FirstName = teacher.FirstName;
            LastName = teacher.LastName;

            SubmitCommand = new UpdateTeacherCommand(this, unitOfWork);
            CancelCommand = new RelayCommand(param =>
            {
                _navigator.CurrentViewModel = TeachersViewModel.LoadTeachersViewModel(_unitOfWork, _navigator);
            });
        }
    }
}
