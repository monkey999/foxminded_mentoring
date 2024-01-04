using A_Domain.Repo_interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Windows;
using Task10.Models;
using Task10.ViewModels;

namespace Task10.Commands.Teachers
{
    public class CreateTeacherCommand : CommandBase
    {
        private readonly CreateTeacherViewModel _createTeacherViewModel;
        private readonly IUnitOfWork _unitOfWork;

        public CreateTeacherCommand(CreateTeacherViewModel createTeacherViewModel, IUnitOfWork unitOfWork)
        {
            _createTeacherViewModel = createTeacherViewModel;
            _unitOfWork = unitOfWork;
        }

        public override async void Execute(object? parameter)
        {
            if (_createTeacherViewModel.FirstName.IsNullOrEmpty() || _createTeacherViewModel.LastName.IsNullOrEmpty())
            {
                MessageBox.Show("FirstName/LastName can't be empty!");
                return;
            }

            try
            {
                Teacher teacher = new()
                {
                    FirstName = _createTeacherViewModel.FirstName,
                    LastName = _createTeacherViewModel.LastName,
                };

                await _unitOfWork.Teachers.AddAsync(teacher);
                await _unitOfWork.SaveAsync();
                MessageBox.Show("Teacher has been successfully created!");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            _createTeacherViewModel._navigator.CurrentViewModel = TeachersViewModel.LoadTeachersViewModel(_unitOfWork, _createTeacherViewModel._navigator);
        }
    }
}
