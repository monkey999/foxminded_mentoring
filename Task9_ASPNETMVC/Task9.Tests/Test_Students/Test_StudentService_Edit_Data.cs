using A_Domain.Repo_interfaces;
using AutoMapper;
using C_Logic.DTO_Contracts.Requests.Update;
using C_Logic.Services;
using Domain;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Task9.Tests.Test_Students
{
    public class Test_StudentService_Edit_Data
    {
        private readonly Mock<IStudentRepository> _mockStudentRepository;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IMapper> _mockMapper;
        private readonly StudentService _studentService;

        public Test_StudentService_Edit_Data()
        {
            _mockStudentRepository = new Mock<IStudentRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockMapper = new Mock<IMapper>();

            _studentService = new StudentService(_mockUnitOfWork.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task UpdateGroupAsync_ValidData_ReturnsTrue()
        {
            var studentUpdateDTORequest = new StudentUpdateDto
            {
                Id = 1,
                FirstName = "Lil",
                LastName = "Peep",
                GroupId = 1
            };

            var student = new Student
            {
                Id = studentUpdateDTORequest.Id,
                FirstName = "Artem",
                LastName = "Shkarupa",
                GroupId = studentUpdateDTORequest.GroupId
            };

            _mockStudentRepository.Setup(repo => repo.SaveChangesAsyncWithResult()).ReturnsAsync(1);
            _mockUnitOfWork.Setup(uow => uow.Students).Returns(_mockStudentRepository.Object);
            _mockMapper.Setup(mapper => mapper.Map<Student>(studentUpdateDTORequest)).Returns(student);

            var result = await _studentService.UpdateAsync(studentUpdateDTORequest);

            Assert.True(result);
            _mockUnitOfWork.Verify(uow => uow.Students.SaveChangesAsyncWithResult(), Times.Once);
        }
    }
}
