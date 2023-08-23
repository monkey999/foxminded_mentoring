using A_Domain.Repo_interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Task10.Commands.Students;
using Task10.Commands;
using Task10.State.Navigators;
using Task10.Commands.Teachers;

namespace Task10.ViewModels
{
    public class DeleteTeacherViewModel : ViewModelBase
    {
        public readonly INavigator _navigator;
        public readonly IUnitOfWork _unitOfWork;

        private int _teacherId;

        public int TeacherId
        {
            get
            {
                return _teacherId;
            }
            set
            {
                _teacherId = value;
                OnPropertyChanged(nameof(TeacherId));
            }
        }

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public DeleteTeacherViewModel(IUnitOfWork unitOfWork, INavigator navigator)
        {
            _navigator = navigator;
            _unitOfWork = unitOfWork;

            SubmitCommand = new DeleteTeacherByIdCommand(this, unitOfWork);

            CancelCommand = new RelayCommand(param =>
            {
                _navigator.CurrentViewModel = TeachersViewModel.LoadTeachersViewModel(_unitOfWork, _navigator);
            });
        }
    }
}
