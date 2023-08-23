using C_Logic.DTO_Contracts.Responses;
using C_Logic.Service_interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task9.Controllers;
using Xunit;

namespace Task9.Tests.Test_Courses
{
    public class Test_CourseController_Get_AllCourses
    {
        private readonly Mock<ICourseService> _mockCourseService;
        private readonly CourseController _courseController;

        public Test_CourseController_Get_AllCourses()
        {
            _mockCourseService = new Mock<ICourseService>();
            _courseController = new CourseController(_mockCourseService.Object);
        }

        [Fact]
        public async Task Index_ReturnsViewWithCourses_WhenCoursesExist()
        {
            var courses = new List<CourseGetDto>
            {
                new CourseGetDto { Id = 1, Name = "Course 1", Description ="java kaka" },
                new CourseGetDto { Id = 2, Name = "Course 2", Description = "tdd beka" }
            };

            _mockCourseService.Setup(service => service.GetAllAsync()).ReturnsAsync(courses);

            var result = await _courseController.IndexAsync();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<CourseGetDto>>(viewResult.Model);

            Assert.Equal(courses, model);
        }

        [Fact]
        public async Task Index_ReturnsNotFound_WhenCoursesDoNotExist()
        {
            _mockCourseService.Setup(service => service.GetAllAsync()).ReturnsAsync(new List<CourseGetDto>());

            var result = await _courseController.IndexAsync();

            Assert.IsType<NotFoundResult>(result);
        }
    }
}
