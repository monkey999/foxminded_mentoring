using A_Domain.Repo_interfaces;
using System.Windows.Input;
using Task10.Commands.Groups;
using Task10.Commands;
using Task10.State.Navigators;
using Task10.Commands.Students;

namespace Task10.ViewModels
{
    public class DeleteStudentViewModel : ViewModelBase
    {
        public readonly INavigator _navigator;
        public readonly IUnitOfWork _unitOfWork;

        private int _studentId;

        public int StudentId
        {
            get
            {
                return _studentId;
            }
            set
            {
                _studentId = value;
                OnPropertyChanged(nameof(StudentId));
            }
        }

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public DeleteStudentViewModel(IUnitOfWork unitOfWork, INavigator navigator)
        {
            _navigator = navigator;
            _unitOfWork = unitOfWork;

            SubmitCommand = new DeleteStudentByIdCommand(this, unitOfWork);

            CancelCommand = new RelayCommand(param =>
            {
                _navigator.CurrentViewModel = StudentsViewModel.LoadStudentsViewModel(_unitOfWork, _navigator);
            });
        }
    }
}
