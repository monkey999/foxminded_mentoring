using A_Domain.Repo_interfaces;
using AutoMapper;
using C_Logic.DTO_Contracts.Responses;
using C_Logic.Service_interfaces;
using C_Logic.Services;
using Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Task9.Tests.Test_Groups
{
    public class Test_GroupService_Delete_Data
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<IGroupRepository> _mockGroupRepository;
        private readonly GroupService _groupService;

        public Test_GroupService_Delete_Data()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockMapper = new Mock<IMapper>();
            _mockGroupRepository = new Mock<IGroupRepository>();
            _groupService = new GroupService(_mockUnitOfWork.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task DeleteGroupAsync_ThrowsException_WhenGroupNotFound()
        {
            int groupId = 1;
            var groupDtoResponse = new GroupGetDto
            {
                Id = 1,
                Name = "werwr",
                CourseId = 1
            };

            var group = new Group
            {
                Id = groupDtoResponse.Id,
                Name = "werwr",
                CourseId = groupDtoResponse.CourseId
            };

            IQueryable<Group> groupQuery = Enumerable.Empty<Group>().AsQueryable();

            var mockGroupService = new Mock<IGroupService>();
            _mockMapper.Setup(mapper => mapper.Map<GroupGetDto>(group)).Returns(groupDtoResponse);
            _mockGroupRepository.Setup(gr => gr.FindByCondition(x => x.Id.Equals(groupId))).ReturnsAsync(groupQuery);
            _mockUnitOfWork.Setup(uow => uow.Groups).Returns(_mockGroupRepository.Object);
            mockGroupService.Setup(service => service.GetByIdAsync(groupId)).ReturnsAsync((GroupGetDto)null);

            await Assert.ThrowsAsync<InvalidOperationException>(() => _groupService.DeleteAsync(groupId));
        }

        [Fact]
        public async Task DeleteGroupAsync_ReturnsFalse_WhenStudentsExistInGroup()
        {
            int groupId = 1;
            var groupDtoResponse = new GroupGetDto
            {
                Id = 1,
                Name = "werwr",
                CourseId = 1
            };

            var group = new Group
            {
                Id = groupDtoResponse.Id,
                Name = "werwr",
                CourseId = groupDtoResponse.CourseId
            };

            var students = new List<Student>
            {
                new Student { Id = 1, FirstName = "Student 1", LastName = "Description 1", GroupId = 2 }
            };

            var mockGroupService = new Mock<IGroupService>();
            _mockMapper.Setup(mapper => mapper.Map<GroupGetDto>(group)).Returns(groupDtoResponse);

            _mockGroupRepository.Setup(gr => gr.FindByCondition(x => x.Id.Equals(groupId))).ReturnsAsync(new List<Group> { group }.AsQueryable());
            _mockUnitOfWork.Setup(uow => uow.Groups).Returns(_mockGroupRepository.Object);
            mockGroupService.Setup(service => service.GetByIdAsync(groupId)).ReturnsAsync(groupDtoResponse);

            var mockStudentRepository = new Mock<IStudentRepository>();
            mockStudentRepository.Setup(st => st.FindByCondition(x => x.GroupId == groupId))
                .ReturnsAsync(students.AsQueryable());
            _mockUnitOfWork.Setup(uow => uow.Students).Returns(mockStudentRepository.Object);

            _mockUnitOfWork.Setup(uow => uow.Groups.RemoveById(groupId));
            _mockGroupRepository.Setup(g => g.SaveChangesAsyncWithResult()).ReturnsAsync(0);
            _mockUnitOfWork.Setup(uow => uow.Groups).Returns(_mockGroupRepository.Object);

            var result = await _groupService.DeleteAsync(groupId);

            Assert.False(result);
        }


        [Fact]
        public async Task DeleteGroupAsync_RemovesGroupAndReturnsTrueWhenNoStudentsExist()
        {
            int groupId = 1;
            var groupDtoResponse = new GroupGetDto
            {
                Id = 1,
                Name = "werwr",
                CourseId = 1
            };

            var group = new Group
            {
                Id = groupDtoResponse.Id,
                Name = "werwr",
                CourseId = groupDtoResponse.CourseId
            };

            var mockGroupService = new Mock<IGroupService>();
            _mockMapper.Setup(mapper => mapper.Map<GroupGetDto>(group)).Returns(groupDtoResponse);

            _mockGroupRepository.Setup(gr => gr.FindByCondition(x => x.Id.Equals(groupId))).ReturnsAsync(new List<Group> { group }.AsQueryable());
            _mockUnitOfWork.Setup(uow => uow.Groups).Returns(_mockGroupRepository.Object);
            mockGroupService.Setup(service => service.GetByIdAsync(groupId)).ReturnsAsync(groupDtoResponse);

            var mockStudentRepository = new Mock<IStudentRepository>();
            mockStudentRepository.Setup(st => st.FindByCondition(x => x.GroupId == groupId))
                .ReturnsAsync(new List<Student>().AsQueryable());
            _mockUnitOfWork.Setup(uow => uow.Students).Returns(mockStudentRepository.Object);

            _mockUnitOfWork.Setup(uow => uow.Groups.RemoveById(groupId));
            _mockGroupRepository.Setup(g => g.SaveChangesAsyncWithResult()).ReturnsAsync(1);
            _mockUnitOfWork.Setup(uow => uow.Groups).Returns(_mockGroupRepository.Object);

            var result = await _groupService.DeleteAsync(groupId);

            Assert.True(result);
            _mockGroupRepository.Verify(g => g.RemoveById(groupId), Times.Once);
            _mockUnitOfWork.Verify(uow => uow.Groups.SaveChangesAsyncWithResult(), Times.Once);
        }
    }
}
