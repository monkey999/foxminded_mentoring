using A_Domain.Repo_interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows;
using Task10.ViewModels;

namespace Task10.Commands.Students
{
    public class DeleteStudentByIdCommand : CommandBase
    {
        private readonly DeleteStudentViewModel _deleteStudentViewModel;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteStudentByIdCommand(DeleteStudentViewModel deleteStudentViewModel, IUnitOfWork unitOfWork)
        {
            _deleteStudentViewModel = deleteStudentViewModel;
            _unitOfWork = unitOfWork;
        }

        public override async void Execute(object? parameter)
        {
            if (_deleteStudentViewModel.StudentId == 0)
            {
                MessageBox.Show("You didn't provide student ID");
                return;
            }

            var student = await _unitOfWork.Students.GetAll().Where(x => x.Id == _deleteStudentViewModel.StudentId).FirstOrDefaultAsync();

            if (student == null)
            {
                MessageBox.Show("Student not found");
                return;
            }

            string deletingStudentName = student.FullName;

            try
            {
                _unitOfWork.Students.RemoveById(_deleteStudentViewModel.StudentId);
                await _unitOfWork.SaveAsync();
                MessageBox.Show($"Student {deletingStudentName} has been successfully deleted!");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            _deleteStudentViewModel._navigator.CurrentViewModel = StudentsViewModel.LoadStudentsViewModel(_unitOfWork, _deleteStudentViewModel._navigator);
        }
    }
}
