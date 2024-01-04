using A_Domain.Repo_interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Linq;
using System.Windows;
using Task10.Models;
using Task10.ViewModels;

namespace Task10.Commands.Teachers
{
    public class UpdateTeacherCommand : CommandBase
    {
        private UpdateTeacherViewModel _updateTeacherViewModel;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTeacherCommand(UpdateTeacherViewModel updateTeacherViewModel, IUnitOfWork unitOfWork)
        {
            _updateTeacherViewModel = updateTeacherViewModel;
            _unitOfWork = unitOfWork;
        }

        public override async void Execute(object? parameter)
        {
            if (_updateTeacherViewModel.FirstName.IsNullOrEmpty() || _updateTeacherViewModel.LastName.IsNullOrEmpty())
            {
                MessageBox.Show("FirstName/LastName can't be empty!");
                return;
            }

            try
            {
                Teacher teacher = await _unitOfWork.Teachers.GetAll().Where(x => x.Id == _updateTeacherViewModel.teacherToUpdate.Id).FirstOrDefaultAsync();

                teacher.FirstName = _updateTeacherViewModel.FirstName;
                teacher.LastName = _updateTeacherViewModel.LastName;

                _unitOfWork.Teachers.Update(teacher);
                await _unitOfWork.SaveAsync();
                MessageBox.Show("Teacher has been successfully updated!");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            _updateTeacherViewModel._navigator.CurrentViewModel = TeachersViewModel.LoadTeachersViewModel(_unitOfWork, _updateTeacherViewModel._navigator);
        }
    }
}
