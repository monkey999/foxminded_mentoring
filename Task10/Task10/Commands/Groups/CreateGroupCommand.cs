using A_Domain.Repo_interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Linq;
using System.Windows;
using Task10.Models;
using Task10.ViewModels;

namespace Task10.Commands.Groups
{
    public class CreateGroupCommand : CommandBase
    {
        private readonly CreateGroupViewModel _createGroupViewModel;
        private readonly IUnitOfWork _unitOfWork;

        public CreateGroupCommand(CreateGroupViewModel createGroupViewModel, IUnitOfWork unitOfWork)
        {
            _createGroupViewModel = createGroupViewModel;
            _unitOfWork = unitOfWork;
        }

        public override async void Execute(object? parameter)
        {
            if (_createGroupViewModel.Name.IsNullOrEmpty())
            {
                MessageBox.Show("Group's name can't be empty!");
                return;
            }

            bool IsSuchCourseExist = await _unitOfWork.Courses.GetAll().Where(x => x.Id == _createGroupViewModel.CourseId).AnyAsync();

            if (!IsSuchCourseExist)
            {
                MessageBox.Show("Course with such ID doesnt exist!");
                return;
            }

            try
            {

                Group group = new()
                {
                    Name = _createGroupViewModel.Name,
                    CourseId = _createGroupViewModel.CourseId
                };

                await _unitOfWork.Groups.AddAsync(group);
                await _unitOfWork.SaveAsync();
                MessageBox.Show("Group has been successfully created!");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            _createGroupViewModel._navigator.CurrentViewModel = GroupsViewModel.LoadGroupsViewModel(_unitOfWork, _createGroupViewModel._navigator);
        }
    }
}
