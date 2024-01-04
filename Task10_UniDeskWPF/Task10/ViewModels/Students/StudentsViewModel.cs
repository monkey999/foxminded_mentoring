using A_Domain.Repo_interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Task10.Commands;
using Task10.Models;
using Task10.Specifications;
using Task10.State.Navigators;

namespace Task10.ViewModels
{
    public class StudentsViewModel : ViewModelBase
    {
        private readonly ObservableCollection<StudentViewModel> _students;
        public IEnumerable<StudentViewModel> Students => _students;

        public readonly IUnitOfWork _unitOfWork;
        public readonly INavigator _navigator;

        public ICommand UpdateStudentCommand { get; }
        public ICommand DeleteStudentCommand { get; }
        public ICommand CreateStudentCommand { get; }
        public ICommand DeleteStudentByIdCommand { get; }


        public StudentsViewModel(IUnitOfWork unitOfWork, INavigator navigator)
        {
            _students = new ObservableCollection<StudentViewModel>();
            _navigator = navigator;
            _unitOfWork = unitOfWork;

            CreateStudentCommand = new RelayCommand(param =>
            {
                _navigator.CurrentViewModel = new CreateStudentViewModel(_unitOfWork, _navigator);
            });

            DeleteStudentByIdCommand = new RelayCommand(param =>
            {
                _navigator.CurrentViewModel = new DeleteStudentViewModel(_unitOfWork, _navigator);
            });

            DeleteStudentCommand = new RelayCommand(param =>
            {
                if (param is StudentViewModel studentViewModel)
                {
                    var student = _unitOfWork.Students.GetAll().Where(x => x.Id == studentViewModel.Id).FirstOrDefault();

                    if (student == null)
                    {
                        MessageBox.Show("Student not found");
                        return;
                    }

                    string deletingStudentName = student.FullName;

                    try
                    {
                        _unitOfWork.Students.RemoveById(studentViewModel.Id);
                        _unitOfWork.Save();
                        MessageBox.Show($"Student {deletingStudentName} has been successfully deleted!");
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
                else
                {
                    MessageBox.Show("An unexpected error has occurred!");
                }

                _navigator.CurrentViewModel = LoadStudentsViewModel(_unitOfWork, _navigator);
            });

            UpdateStudentCommand = new RelayCommand(param =>
            {
                if (param is StudentViewModel student)
                {
                    _navigator.CurrentViewModel = new UpdateStudentViewModel(_unitOfWork, _navigator, student);
                }
            });
        }

        public static StudentsViewModel LoadStudentsViewModel(IUnitOfWork unitOfWork, INavigator navigator, ISpecification<Student> specification = null)
        {
            StudentsViewModel studentsViewModel = new(unitOfWork, navigator);
            studentsViewModel.LoadStudentsFromDb(specification);

            return studentsViewModel;
        }

        private void LoadStudentsFromDb(ISpecification<Student> specification = null)
        {
            IEnumerable<Student> studentsFromDb = _unitOfWork.Students.GetAll();

            if (specification != null)
            {
                studentsFromDb = studentsFromDb.Where(specification.IsSatisfiedBy);
            }

            var studentsList = studentsFromDb.ToList();

            foreach (var student in studentsList)
            {
                var studentViewModel = new StudentViewModel(student);
                _students.Add(studentViewModel);
            }
        }
    }
}
