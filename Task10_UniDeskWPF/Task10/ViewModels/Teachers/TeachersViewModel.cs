using A_Domain.Repo_interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Task10.Commands;
using Task10.State.Navigators;

namespace Task10.ViewModels
{
    public class TeachersViewModel : ViewModelBase
    {
        private readonly ObservableCollection<TeacherViewModel> _teachers;
        public IEnumerable<TeacherViewModel> Teachers => _teachers;

        public readonly IUnitOfWork _unitOfWork;
        public readonly INavigator _navigator;

        public ICommand UpdateTeacherCommand { get; }
        public ICommand DeleteTeacherCommand { get; }
        public ICommand CreateTeacherCommand { get; }
        public ICommand DeleteTeacherByIdCommand { get; }


        public TeachersViewModel(IUnitOfWork unitOfWork, INavigator navigator)
        {
            _teachers = new ObservableCollection<TeacherViewModel>();
            _navigator = navigator;
            _unitOfWork = unitOfWork;

            CreateTeacherCommand = new RelayCommand(param =>
            {
                _navigator.CurrentViewModel = new CreateTeacherViewModel(_unitOfWork, _navigator);
            });

            DeleteTeacherByIdCommand = new RelayCommand(param =>
            {
                _navigator.CurrentViewModel = new DeleteTeacherViewModel(_unitOfWork, _navigator);
            });

            DeleteTeacherCommand = new RelayCommand(param =>
            {
                if (param is TeacherViewModel teacherViewModel)
                {
                    var teacher = _unitOfWork.Teachers.GetAll().Include(t => t.TeacherCourses).Where(x => x.Id == teacherViewModel.Id).FirstOrDefault();
                    var tutor = _unitOfWork.Tutors.GetAll().Include(t => t.TutorGroups).Where(x => x.TeacherId == teacherViewModel.Id).FirstOrDefault();

                    if (teacher == null)
                    {
                        MessageBox.Show("Teacher not found");
                        return;
                    }

                    try
                    {
                        _unitOfWork.TeacherCourses.RemoveRange(teacher.TeacherCourses);

                        if (tutor != null)
                        {
                            _unitOfWork.TutorGroups.RemoveRange(tutor?.TutorGroups);
                            _unitOfWork.Tutors.RemoveById(tutor.Id);
                        }

                        _unitOfWork.Teachers.RemoveById(teacher.Id);
                        _unitOfWork.Save();

                        MessageBox.Show($"Teacher has been successfully deleted!");
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

                _navigator.CurrentViewModel = LoadTeachersViewModel(_unitOfWork, _navigator);
            });

            UpdateTeacherCommand = new RelayCommand(param =>
            {
                if (param is TeacherViewModel teacher)
                {
                    _navigator.CurrentViewModel = new UpdateTeacherViewModel(_unitOfWork, _navigator, teacher);
                }
            });
        }

        public static TeachersViewModel LoadTeachersViewModel(IUnitOfWork unitOfWork, INavigator navigator)
        {
            TeachersViewModel teachersViewModel = new(unitOfWork, navigator);
            teachersViewModel.LoadTeachersFromDb();

            return teachersViewModel;
        }

        private void LoadTeachersFromDb()
        {
            var teachersFromDb = _unitOfWork.Teachers.GetAll().ToList();

            foreach (var teacher in teachersFromDb)
            {
                var teacherViewModel = new TeacherViewModel(teacher);
                _teachers.Add(teacherViewModel);
            }
        }
    }
}
