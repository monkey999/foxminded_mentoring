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
    public class Test_GroupController_Edit_Data
    {
        private readonly Mock<IGroupService> _groupServiceMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly GroupController _controller;

        public Test_GroupController_Edit_Data()
        {
            _groupServiceMock = new Mock<IGroupService>();
            _mapperMock = new Mock<IMapper>();
            _controller = new GroupController(_groupServiceMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task EditGroup_GET_ReturnsPartialViewWithModel()
        {
            int groupId = 1;
            var group = new GroupGetDto { Id = groupId, Name = "Group 1", CourseId = 1 };
            var groupUpdateDTORequest = new GroupUpdateDto { Id = groupId, Name = "Group 1", CourseId = 1 };

            _groupServiceMock.Setup(service => service.GetByIdAsync(groupId)).ReturnsAsync(group);

            _mapperMock.Setup(mapper => mapper.Map<GroupUpdateDto>(group)).Returns(groupUpdateDTORequest);

            var result = await _controller.EditGroup(groupId);

            var viewResult = Assert.IsType<PartialViewResult>(result);
            var model = Assert.IsType<GroupUpdateDto>(viewResult.Model);
            Assert.Equal(groupUpdateDTORequest, model);
        }

        [Fact]
        public async Task EditGroup_GET_ReturnsNotFound_WhenGroupIsNull()
        {
            int groupId = 1;
            GroupGetDto group = null;

            _groupServiceMock.Setup(service => service.GetByIdAsync(groupId)).ReturnsAsync(group);

            var result = await _controller.EditGroup(groupId);

            var notFoundResult = Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task EditGroup_POST_ReturnsBadRequest_WhenModelStateIsInvalid()
        {
            var invalidModel = new GroupUpdateDto { Id = 1, Name = null, CourseId = 1 };

            _controller.ModelState.AddModelError("GroupName", "The GroupName field is required.");

            var result = await _controller.EditGroup(invalidModel);

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<SerializableError>(badRequestResult.Value);
        }

        [Fact]
        public async Task EditGroup_POST_ReturnsRedirectToAction_WithCorrectRouteValues()
        {
            var validModel = new GroupUpdateDto { Id = 1, Name = "Updated Group", CourseId = 1 };

            _groupServiceMock.Setup(service => service.UpdateAsync(validModel)).ReturnsAsync(true);

            var result = await _controller.EditGroup(validModel);

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("GetGroupsByCourseId", redirectToActionResult.ActionName);
            Assert.Equal("Group", redirectToActionResult.ControllerName);
            Assert.Equal(validModel.CourseId, redirectToActionResult.RouteValues["courseId"]);

            _groupServiceMock.Verify(service => service.UpdateAsync(validModel), Times.Once);
            _groupServiceMock.Verify(service => service.UpdateAsync(It.Is<GroupUpdateDto>(g => g.Name == validModel.Name)), Times.Once);
        }

        [Fact]
        public async Task EditGroup_POST_ReturnsBadRequest_WhenUpdateFails()
        {
            var validModel = new GroupUpdateDto { Id = 1, Name = "Updated Group", CourseId = 1 };

            _groupServiceMock.Setup(service => service.UpdateAsync(validModel)).ReturnsAsync(false);

            var result = await _controller.EditGroup(validModel);

            var notFoundResult = Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
