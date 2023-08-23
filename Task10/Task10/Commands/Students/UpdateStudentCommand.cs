using A_Domain.Repo_interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Linq;
using System.Windows;
using Task10.Models;
using Task10.ViewModels;

namespace Task10.Commands.Students
{
    public class UpdateStudentCommand : CommandBase
    {
        private UpdateStudentViewModel _updateStudentViewModel;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateStudentCommand(UpdateStudentViewModel updateStudentViewModel, IUnitOfWork unitOfWork)
        {
            _updateStudentViewModel = updateStudentViewModel;
            _unitOfWork = unitOfWork;
        }

        public override async void Execute(object? parameter)
        {
            if (_updateStudentViewModel.FirstName.IsNullOrEmpty() || _updateStudentViewModel.LastName.IsNullOrEmpty())
            {
                MessageBox.Show("FirstName/LastName can't be empty!");
                return;
            }

            try
            {
                Student student = await _unitOfWork.Students.GetAll().Where(x => x.Id == _updateStudentViewModel.studentToUpdate.Id).FirstOrDefaultAsync();

                student.FirstName = _updateStudentViewModel.FirstName;
                student.LastName = _updateStudentViewModel.LastName;

                _unitOfWork.Students.Update(student);
                await _unitOfWork.SaveAsync();
                MessageBox.Show("Student has been successfully updated!");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            _updateStudentViewModel._navigator.CurrentViewModel = StudentsViewModel.LoadStudentsViewModel(_unitOfWork, _updateStudentViewModel._navigator);
        }
    }
}
