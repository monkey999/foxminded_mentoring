using AutoMapper;
using DataAccess.Specifications.CategorySpecs;
using Domain.Enums;
using Domain.Models;
using Domain.RepoInterfaces;
using Logic.DTO_Contracts.Responses.Get;
using Logic.Services;
using Moq;
using Xunit;

namespace ExpenseTracker.Tests.CategoryService_Tests
{
    public class Test_DeleteCategoryAsync
    {
        private readonly Mock<IUnitOfWOrk> _unitOfWorkMock;
        private readonly Mock<ICategoryRepo> _categoryRepoMock;
        private readonly Mock<IMapper> _mapperMock;

        public Test_DeleteCategoryAsync()
        {
            _unitOfWorkMock = new Mock<IUnitOfWOrk>();
            _categoryRepoMock = new Mock<ICategoryRepo>();
            _mapperMock = new Mock<IMapper>();
        }

        [Fact]
        public async Task CategoryExists_ReturnsDeletedResponse()
        {
            // Arrange
            var categoryId = Guid.NewGuid();
            var cancellationToken = CancellationToken.None;

            var categories = new List<Category>
            {
                new Category()
            };

            _unitOfWorkMock.Setup(uow => uow.SaveChangesAsyncWithResult(cancellationToken)).ReturnsAsync(1);
            _categoryRepoMock.Setup(repo => repo.RemoveById(categoryId));

            _categoryRepoMock
             .Setup(x => x.FindByConditionAsync(cancellationToken, It.IsAny<CategoryGetByIdAsNoTrackingSpecification>()))
             .ReturnsAsync(categories);

            // Act
            var categoryService = new CategoryService(_unitOfWorkMock.Object, _mapperMock.Object, _categoryRepoMock.Object);
            var result = await categoryService.DeleteCategoryAsync(categoryId, cancellationToken);

            // Assert
            Assert.True(result.Deleted);
            Assert.Null(result.Error);

            _unitOfWorkMock.Verify(uow => uow.SaveChangesAsyncWithResult(cancellationToken), Times.Once);
            _categoryRepoMock.Verify(repo => repo.RemoveById(categoryId), Times.Once);
        }

        [Fact]
        public async Task CategoryNotFound_ReturnsErrorResponse()
        {
            // Arrange
            var categoryId = Guid.NewGuid();
            var cancellationToken = CancellationToken.None;

            _unitOfWorkMock.Setup(uow => uow.SaveChangesAsyncWithResult(cancellationToken)).ReturnsAsync(0);
            _categoryRepoMock
              .Setup(x => x.FindByConditionAsync(cancellationToken, It.IsAny<CategoryGetByIdAsNoTrackingSpecification>()))
              .ReturnsAsync((List<Category>)null);

            // Act
            var categoryService = new CategoryService(_unitOfWorkMock.Object, _mapperMock.Object, _categoryRepoMock.Object);
            var result = await categoryService.DeleteCategoryAsync(categoryId, cancellationToken);

            // Assert
            Assert.False(result.Deleted);
            Assert.NotNull(result.Error);
            Assert.Equal(400, result.Error.StatusCode);
            Assert.Equal("Such category doesn't exist!", result.Error.Message);

            _unitOfWorkMock.Verify(uow => uow.SaveChangesAsyncWithResult(cancellationToken), Times.Never);
            _categoryRepoMock.Verify(repo => repo.RemoveById(categoryId), Times.Never);
        }

        [Fact]
        public async Task ErrorDeletingCategory_ReturnsErrorResponse()
        {
            // Arrange
            var categoryId = Guid.NewGuid();
            var cancellationToken = CancellationToken.None;

            var category = new List<Category>
            {
                new Category { Id = Guid.NewGuid(), CategoryName = "Category1", CategoryType = CategoryType.Income }
            };

            _unitOfWorkMock.Setup(uow => uow.SaveChangesAsyncWithResult(cancellationToken)).ReturnsAsync(0);
            _categoryRepoMock.Setup(repo => repo.RemoveById(categoryId));

            _categoryRepoMock
             .Setup(x => x.FindByConditionAsync(cancellationToken, It.IsAny<CategoryGetByIdAsNoTrackingSpecification>()))
             .ReturnsAsync(category);

            // Act
            var categoryService = new CategoryService(_unitOfWorkMock.Object, _mapperMock.Object, _categoryRepoMock.Object);
            var result = await categoryService.DeleteCategoryAsync(categoryId, cancellationToken);

            // Assert
            Assert.False(result.Deleted);
            Assert.NotNull(result.Error);
            Assert.Equal(400, result.Error.StatusCode);
            Assert.Equal("Error occurred while deleting category!", result.Error.Message);

            _unitOfWorkMock.Verify(uow => uow.SaveChangesAsyncWithResult(cancellationToken), Times.Once);
            _categoryRepoMock.Verify(repo => repo.RemoveById(categoryId), Times.Once);
        }
    }
}
