using A_Domain.Repo_interfaces;
using AutoMapper;
using C_Logic.DTO_Contracts.Requests.Update;
using C_Logic.Services;
using Domain;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Task9.Tests.Test_Groups
{
    public class Test_GroupService_Edit_Data
    {
        private readonly Mock<IGroupRepository> _mockGroupRepository;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IMapper> _mockMapper;
        private readonly GroupService _groupService;

        public Test_GroupService_Edit_Data()
        {
            _mockGroupRepository = new Mock<IGroupRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockMapper = new Mock<IMapper>();

            _groupService = new GroupService(_mockUnitOfWork.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task UpdateGroupAsync_ValidData_ReturnsTrue()
        {
            var groupUpdateDTORequest = new GroupUpdateDto
            {
                Id = 1,
                Name = "Updated Group",
                CourseId = 1
            };

            var group = new Group
            {
                Id = groupUpdateDTORequest.Id,
                Name = "Original Group",
                CourseId = groupUpdateDTORequest.CourseId
            };

            _mockGroupRepository.Setup(repo => repo.SaveChangesAsyncWithResult()).ReturnsAsync(1);
            _mockUnitOfWork.Setup(uow => uow.Groups).Returns(_mockGroupRepository.Object);
            _mockMapper.Setup(mapper => mapper.Map<Group>(groupUpdateDTORequest)).Returns(group);

            var result = await _groupService.UpdateAsync(groupUpdateDTORequest);

            Assert.True(result);
            _mockUnitOfWork.Verify(uow => uow.Groups.SaveChangesAsyncWithResult(), Times.Once);
        }
    }
}
