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
    public class CreateStudentCommand : CommandBase
    {
        private readonly CreateStudentViewModel _createStudentViewModel;
        private readonly IUnitOfWork _unitOfWork;

        public CreateStudentCommand(CreateStudentViewModel createStudentViewModel, IUnitOfWork unitOfWork)
        {
            _createStudentViewModel = createStudentViewModel;
            _unitOfWork = unitOfWork;
        }

        public override async void Execute(object? parameter)
        {
            if (_createStudentViewModel.FirstName.IsNullOrEmpty() || _createStudentViewModel.LastName.IsNullOrEmpty())
            {
                MessageBox.Show("FirstName/LastName can't be empty!");
                return;
            }

            bool IsSuchGroupExist = await _unitOfWork.Groups.GetAll().Where(x => x.Id == _createStudentViewModel.GroupId).AnyAsync();

            if (!IsSuchGroupExist)
            {
                MessageBox.Show("Group with such ID doesnt exist!");
                return;
            }

            try
            {
                Student student = new()
                {
                    FirstName = _createStudentViewModel.FirstName,
                    LastName = _createStudentViewModel.LastName,
                    GroupId = _createStudentViewModel.GroupId,
                    Group = await _unitOfWork.Groups.GetAll().Where(x => x.Id == _createStudentViewModel.GroupId).FirstOrDefaultAsync()
                };

                await _unitOfWork.Students.AddAsync(student);
                await _unitOfWork.SaveAsync();
                MessageBox.Show("Student has been successfully created!");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            _createStudentViewModel._navigator.CurrentViewModel = StudentsViewModel.LoadStudentsViewModel(_unitOfWork, _createStudentViewModel._navigator);
        }
    }
}
