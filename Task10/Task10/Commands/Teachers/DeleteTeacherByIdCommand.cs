using A_Domain.Repo_interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows;
using Task10.ViewModels;

namespace Task10.Commands.Teachers
{
    public class DeleteTeacherByIdCommand : CommandBase
    {
        private readonly DeleteTeacherViewModel _deleteTeacherViewModel;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTeacherByIdCommand(DeleteTeacherViewModel deleteTeacherViewModel, IUnitOfWork unitOfWork)
        {
            _deleteTeacherViewModel = deleteTeacherViewModel;
            _unitOfWork = unitOfWork;
        }

        public override async void Execute(object? parameter)
        {
            if (_deleteTeacherViewModel.TeacherId == 0)
            {
                MessageBox.Show("You didn't provide teacher ID");
                return;
            }

            var teacher = await _unitOfWork.Teachers.GetAll().Include(t => t.TeacherCourses).Where(x => x.Id == _deleteTeacherViewModel.TeacherId).FirstOrDefaultAsync();
            var tutor = await _unitOfWork.Tutors.GetAll().Include(t => t.TutorGroups).Where(x => x.TeacherId == _deleteTeacherViewModel.TeacherId).FirstOrDefaultAsync();

            if (teacher == null)
            {
                MessageBox.Show("Teacher not found");
                return;
            }

            string deletingTeacherName = teacher.FullName;

            try
            {
                _unitOfWork.TeacherCourses.RemoveRange(teacher.TeacherCourses);
                if (tutor != null)
                {
                    _unitOfWork.TutorGroups.RemoveRange(tutor?.TutorGroups);
                    _unitOfWork.Tutors.RemoveById(tutor.Id);
                }
     
                _unitOfWork.Teachers.RemoveById(_deleteTeacherViewModel.TeacherId);
                await _unitOfWork.SaveAsync();

                MessageBox.Show($"Teacher {deletingTeacherName} has been successfully deleted!");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }


            _deleteTeacherViewModel._navigator.CurrentViewModel = TeachersViewModel.LoadTeachersViewModel(_unitOfWork, _deleteTeacherViewModel._navigator);
        }
    }
} 
