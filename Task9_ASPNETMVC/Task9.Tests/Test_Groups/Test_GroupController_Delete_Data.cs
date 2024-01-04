using AutoMapper;
using C_Logic.DTO_Contracts.Requests.Update;
using C_Logic.DTO_Contracts.Responses;
using C_Logic.Service_interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Task9.Controllers;
using Xunit;

namespace Task9.Tests.Test_Groups
{
    public class Test_GroupController_Delete_Data
    {
        private readonly Mock<IGroupService> _mockGroupService;
        private readonly Mock<IMapper> _mockMapper;
        private readonly GroupController _groupController;

        public Test_GroupController_Delete_Data()
        {
            _mockGroupService = new Mock<IGroupService>();
            _mockMapper = new Mock<IMapper>();
            _groupController = new GroupController(_mockGroupService.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task DeleteGroup_ReturnsNotFound_WhenGroupDoesNotExist()
        {
            int groupId = 1;
            _mockGroupService.Setup(service => service.GetByIdAsync(groupId)).ReturnsAsync((GroupGetDto)null);

            var result = await _groupController.DeleteGroup(groupId);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task DeleteGroup_ReturnsPartialViewWithModel_WhenGroupExists()
        {
            int groupId = 1;
            var groupUpdateDTORequest = new GroupUpdateDto { Id = groupId, Name = "Group 1", CourseId = 1 };
            var groupDTOResponse = new GroupGetDto { Id = groupId, Name = "Group 1", CourseId = 1 };
            _mockGroupService.Setup(service => service.GetByIdAsync(groupId)).ReturnsAsync(groupDTOResponse);
            _mockMapper.Setup(mapper => mapper.Map<GroupUpdateDto>(groupDTOResponse)).Returns(groupUpdateDTORequest);

            var result = await _groupController.DeleteGroup(groupId);

            var partialViewResult = Assert.IsType<PartialViewResult>(result);
            Assert.Equal("_DeleteGroup", partialViewResult.ViewName);
            Assert.Equal(groupUpdateDTORequest, partialViewResult.Model);
        }

        [Fact]
        public async Task DeleteGroup_ReturnsPartialViewError_WhenGroupDeletionFails()
        {
            var model = new GroupUpdateDto { Id = 1, Name = "Group 1", CourseId = 1 };
            _mockGroupService.Setup(service => service.DeleteAsync(model.Id)).ReturnsAsync(false);

            var result = await _groupController.DeleteGroup(model);

            var partialViewResult = Assert.IsType<PartialViewResult>(result);
            Assert.Equal("_ErrorDelete", partialViewResult.ViewName);
        }

        [Fact]
        public async Task DeleteGroup_RedirectsToGetGroupsByCourseId_WhenGroupDeletionSucceeds()
        {
            var model = new GroupUpdateDto { Id = 1, Name = "Group 1", CourseId = 1 };
            _mockGroupService.Setup(service => service.DeleteAsync(model.Id)).ReturnsAsync(true);

            var result = await _groupController.DeleteGroup(model);

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("GetGroupsByCourseId", redirectToActionResult.ActionName);
            Assert.Equal("Group", redirectToActionResult.ControllerName);
            Assert.Equal(model.CourseId, redirectToActionResult.RouteValues["courseId"]);
        }
    }
}
