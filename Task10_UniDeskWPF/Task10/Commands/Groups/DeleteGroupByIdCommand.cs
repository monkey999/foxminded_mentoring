using A_Domain.Repo_interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows;
using Task10.ViewModels;

namespace Task10.Commands.Groups
{
    public class DeleteGroupByIdCommand : CommandBase
    {
        private readonly DeleteGroupViewModel _deleteGroupViewModel;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteGroupByIdCommand(DeleteGroupViewModel deleteGroupViewModel, IUnitOfWork unitOfWork)
        {
            _deleteGroupViewModel = deleteGroupViewModel;
            _unitOfWork = unitOfWork;
        }

        public override async void Execute(object? parameter)
        {
            if (_deleteGroupViewModel.GroupId == 0)
            {
                MessageBox.Show("You didn't provide group ID");
                return;
            }

            bool ifAnyStudInCurrGroup = await _unitOfWork.Students.GetAll().Where(x => x.GroupId == _deleteGroupViewModel.GroupId).AnyAsync();

            if (ifAnyStudInCurrGroup)
            {
                MessageBox.Show("You can't delete group with at least one student!");
                return;
            }

            var group = await _unitOfWork.Groups.GetAll().Include(t => t.TutorGroups).Where(x => x.Id == _deleteGroupViewModel.GroupId).FirstOrDefaultAsync();

            if (group == null)
            {
                MessageBox.Show("Group not found");
                return;
            }

            string deletingGroupName = group.Name;

            try
            {
                _unitOfWork.TutorGroups.RemoveRange(group?.TutorGroups);

                _unitOfWork.Groups.RemoveById(_deleteGroupViewModel.GroupId);

                await _unitOfWork.SaveAsync();

                MessageBox.Show($"Group {deletingGroupName} has been successfully deleted!");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            _deleteGroupViewModel._navigator.CurrentViewModel = GroupsViewModel.LoadGroupsViewModel(_unitOfWork, _deleteGroupViewModel._navigator);
        }
    }
}
