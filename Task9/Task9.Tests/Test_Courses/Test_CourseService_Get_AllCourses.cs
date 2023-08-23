using A_Domain.Repo_interfaces;
using AutoMapper;
using C_Logic.DTO_Contracts.Responses;
using C_Logic.Services;
using Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Task9.Tests.Test_Courses
{
    public class Test_CourseService_Get_AllCourses
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<ICourseRepository> _mockCourseRepository;
        private readonly CourseService _courseService;

        public Test_CourseService_Get_AllCourses()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockMapper = new Mock<IMapper>();
            _mockCourseRepository = new Mock<ICourseRepository>();
            _courseService = new CourseService(_mockUnitOfWork.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetAllCoursesAsync_ReturnsListOfCourses_WhenCoursesExist()
        {
            var courses = new List<Course>
            {
                new Course { Id = 1, Name = "Course 1", Description = "Description 1" },
                new Course { Id = 2, Name = "Course 2", Description = "Description 2" }
            };

            var courseDTOs = new List<CourseGetDto>
            {
                new CourseGetDto { Id = 1, Name = "Course 1", Description = "Description 1" },
                new CourseGetDto { Id = 2, Name = "Course 2", Description = "Description 2" }
            };

            _mockMapper.Setup(mapper => mapper.Map<List<CourseGetDto>>(courses)).Returns(courseDTOs);

            _mockCourseRepository.Setup(repo => repo.GetAll()).ReturnsAsync(courses.AsQueryable());
            _mockUnitOfWork.Setup(uow => uow.Courses).Returns(_mockCourseRepository.Object);

            var result = await _courseService.GetAllAsync();

            Assert.Equal(courseDTOs, result);
        }


        [Fact]
        public async Task GetAllCoursesAsync_ThrowsException_WhenCoursesDoNotExist()
        {
            var notExistingCourses = new List<Course>();

            _mockCourseRepository.Setup(repo => repo.GetAll()).ReturnsAsync(notExistingCourses.AsQueryable());
            _mockUnitOfWork.Setup(uow => uow.Courses).Returns(_mockCourseRepository.Object);

            await Assert.ThrowsAsync<InvalidOperationException>(() => _courseService.GetAllAsync());
        }
    }
}
