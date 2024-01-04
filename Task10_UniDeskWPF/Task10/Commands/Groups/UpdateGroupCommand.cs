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
    public class UpdateGroupCommand : CommandBase
    {
        private UpdateGroupViewModel _updateGroupViewModel;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateGroupCommand(UpdateGroupViewModel updateGroupViewModel, IUnitOfWork unitOfWork)
        {
            _updateGroupViewModel = updateGroupViewModel;
            _unitOfWork = unitOfWork;
        }

        public override async void Execute(object? parameter)
        {
            if (_updateGroupViewModel.Name.IsNullOrEmpty())
            {
                MessageBox.Show("Group's name can't be empty!");
                return;
            }

            try
            {
                Group group = await _unitOfWork.Groups.GetAll().Where(x => x.Id == _updateGroupViewModel.groupToUpdate.Id).FirstOrDefaultAsync();

                group.Name = _updateGroupViewModel.Name;

                _unitOfWork.Groups.Update(group);
                await _unitOfWork.SaveAsync();
                MessageBox.Show("Group has been successfully updated!");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            _updateGroupViewModel._navigator.CurrentViewModel = GroupsViewModel.LoadGroupsViewModel(_unitOfWork, _updateGroupViewModel._navigator);
        }
    }
}
