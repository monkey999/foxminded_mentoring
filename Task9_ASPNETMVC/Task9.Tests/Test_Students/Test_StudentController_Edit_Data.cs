using AutoMapper;
using C_Logic.DTO_Contracts.Requests.Update;
using C_Logic.DTO_Contracts.Responses;
using C_Logic.Service_interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Task9.Controllers;
using Xunit;

namespace Task9.Tests.Test_Students
{
    public class Test_StudentController_Edit_Data
    {
        private readonly Mock<IStudentService> _studentServiceMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly StudentController _controller;

        public Test_StudentController_Edit_Data()
        {
            _studentServiceMock = new Mock<IStudentService>();
            _mapperMock = new Mock<IMapper>();
            _controller = new StudentController(_studentServiceMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task EditStudent_GET_ReturnsPartialViewWithModel()
        {
            int studentId = 1;
            var student = new StudentGetDto { Id = studentId, FirstName = "Artem", LastName = "Shkarupa", GroupId = 1 };
            var studentUpdateDTORequest = new StudentUpdateDto { Id = studentId, FirstName = "Artem", LastName = "Shkarupa", GroupId = 1 };

            _studentServiceMock.Setup(service => service.GetByIdAsync(studentId)).ReturnsAsync(student);

            _mapperMock.Setup(mapper => mapper.Map<StudentUpdateDto>(student)).Returns(studentUpdateDTORequest);

            var result = await _controller.EditStudent(studentId);
            
            var viewResult = Assert.IsType<PartialViewResult>(result);
            var model = Assert.IsType<StudentUpdateDto>(viewResult.Model);
            Assert.Equal(studentUpdateDTORequest, model);
        }

        [Fact]
        public async Task EditStudent_GET_ReturnsNotFound_WhenStudentIsNull()
        {
            int studentId = 1;
            StudentGetDto student = null;

            _studentServiceMock.Setup(service => service.GetByIdAsync(studentId)).ReturnsAsync(student);

            var result = await _controller.EditStudent(studentId);

            var notFoundResult = Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task EditStudent_POST_ReturnsBadRequest_WhenModelStateIsInvalid()
        {
            var invalidModel = new StudentUpdateDto { Id = 1, LastName = null, GroupId = 1 };

            _controller.ModelState.AddModelError("StudentName", "The GroupName field is required.");

            var result = await _controller.EditStudent(invalidModel);

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<SerializableError>(badRequestResult.Value);
        }

        [Fact]
        public async Task EditStudent_POST_ReturnsRedirectToAction_WithCorrectRouteValues()
        {
            var validModel = new StudentUpdateDto { Id = 1, FirstName = "Artem", LastName = "Shkarupa", GroupId = 1 };

            _studentServiceMock.Setup(service => service.UpdateAsync(validModel)).ReturnsAsync(true);

            var result = await _controller.EditStudent(validModel);

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("GetStudentsByGroupId", redirectToActionResult.ActionName);
            Assert.Equal("Student", redirectToActionResult.ControllerName);
            Assert.Equal(validModel.GroupId, redirectToActionResult.RouteValues["groupId"]);

            _studentServiceMock
                .Verify(service => service.UpdateAsync(validModel), Times.Once);
            _studentServiceMock
                .Verify(service => service
                        .UpdateAsync(It
                            .Is<StudentUpdateDto>(g => g.FirstName == validModel.FirstName && g.LastName == validModel.LastName)), Times.Once);
        }

        [Fact]
        public async Task EditGroup_POST_ReturnsBadRequest_WhenUpdateFails()
        {
            var validModel = new StudentUpdateDto { Id = 1, FirstName = "Artem", LastName = "Shkarupa", GroupId = 1 };

            _studentServiceMock.Setup(service => service.UpdateAsync(validModel)).ReturnsAsync(false);

            var result = await _controller.EditStudent(validModel);

            var notFoundResult = Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
