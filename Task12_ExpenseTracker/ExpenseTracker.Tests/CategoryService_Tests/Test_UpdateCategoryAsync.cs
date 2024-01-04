using AutoMapper;
using DataAccess.Specifications.CategorySpecs;
using Domain.Enums;
using Domain.Models;
using Domain.RepoInterfaces;
using Logic.DTO_Contracts.Requests.Update;
using Logic.DTO_Contracts.Responses.Update;
using Logic.Services;
using Moq;
using Xunit;

namespace ExpenseTracker.Tests.CategoryService_Tests
{
    public class Test_UpdateCategoryAsync
    {
        private readonly Mock<IUnitOfWOrk> _unitOfWorkMock;
        private readonly Mock<ICategoryRepo> _categoryRepoMock;
        private readonly Mock<IMapper> _mapperMock;

        public Test_UpdateCategoryAsync()
        {
            _unitOfWorkMock = new Mock<IUnitOfWOrk>();
            _categoryRepoMock = new Mock<ICategoryRepo>();
            _mapperMock = new Mock<IMapper>();
        }

        [Fact]
        public async Task UpdateCategoryAsync_CategoryExists_ReturnsUpdatedCategory()
        {
            // Arrange
            var categoryId = Guid.NewGuid();
            var cancellationToken = CancellationToken.None;

            var updateReqCategoryDto = new UpdateCategoryReqDTO 
            {
                Id = categoryId,
                CategoryName = "UpdateTestCategory1"
            };
            var updateCategoryRespDto = new UpdateCategoryRespDTO 
            {
                Id = categoryId,
                CategoryName = "UpdateTestCategory1",
                CategoryType = "Income" 
            };
            var category = new Category
            { 
                Id = categoryId,
                CategoryName = "TestCategory1",
                CategoryType = CategoryType.Income 
            };

            var mappedCategoryToUpdateDto = new Category
            {
                Id = categoryId,
                CategoryName = updateReqCategoryDto.CategoryName,
                CategoryType = CategoryType.Income
            };

            _categoryRepoMock
              .Setup(x => x.FindByConditionAsync(cancellationToken, It.IsAny<CategoryGetByIdAsNoTrackingSpecification>()))
              .ReturnsAsync(new List<Category> { category });

            _categoryRepoMock
               .Setup(x => x.FindByConditionAsync(cancellationToken, It.IsAny<CategoryGetByIdSpecification>()))
               .ReturnsAsync(new List<Category> { category });

            _mapperMock
                .Setup(x => x.Map(updateReqCategoryDto, category))
                .Returns(mappedCategoryToUpdateDto);

            _categoryRepoMock
                .Setup(x => x.Update(It.IsAny<Category>()));

            _unitOfWorkMock
                .Setup(x => x.SaveChangesAsyncWithResult(cancellationToken))
                .ReturnsAsync(1);

            _mapperMock.Setup(x => x.Map<UpdateCategoryRespDTO>(category)).Returns(updateCategoryRespDto);

            // Act
            var categoryService = new CategoryService(_unitOfWorkMock.Object, _mapperMock.Object, _categoryRepoMock.Object);
            var result = await categoryService.UpdateCategoryAsync(updateReqCategoryDto, cancellationToken);

            // Assert
            _unitOfWorkMock.Verify(x => x.SaveChangesAsyncWithResult(cancellationToken), Times.Once);

            Assert.NotNull(result);
            Assert.Null(result.ErrorMessage);

            Assert.Equal(category.Id, result.Id);
            Assert.Equal(mappedCategoryToUpdateDto.CategoryName, result.CategoryName);
        }

        [Fact]
        public async Task UpdateCategoryAsync_CategoryNotFound_ReturnsNotFoundResponse()
        {
            // Arrange
            var categoryId = Guid.NewGuid();
            var categoryDto = new UpdateCategoryReqDTO { Id = categoryId };
            var cancellationToken = CancellationToken.None;

            _categoryRepoMock
                .Setup(x => x.FindByConditionAsync(cancellationToken, It.IsAny<CategoryGetByIdSpecification>()))
                    .ReturnsAsync((List<Category>)null);

            _categoryRepoMock
              .Setup(x => x.FindByConditionAsync(cancellationToken, It.IsAny<CategoryGetByIdAsNoTrackingSpecification>()))
              .ReturnsAsync((List<Category>)null);

            _categoryRepoMock
                .Setup(x => x.Update(It.IsAny<Category>()));

            // Act
            var categoryService = new CategoryService(_unitOfWorkMock.Object, _mapperMock.Object, _categoryRepoMock.Object);
            var result = await categoryService.UpdateCategoryAsync(categoryDto, cancellationToken);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(404, result.ErrorMessage.StatusCode);
            Assert.Equal("Category not found.", result.ErrorMessage.Message);
        }

        [Fact]
        public async Task UpdateCategoryAsync_UpdateFails_ReturnsBadRequestResponse()
        {
            // Arrange
            var categoryId = Guid.NewGuid();
            var categoryDto = new UpdateCategoryReqDTO { Id = categoryId };
            var category = new Category { Id = categoryId, CategoryName = "UpdateTestCategory" };
            var cancellationToken = CancellationToken.None;

            _categoryRepoMock
                .Setup(x => x.FindByConditionAsync(cancellationToken, It.IsAny<CategoryGetByIdSpecification>()))
                .ReturnsAsync(new List<Category>());

            _categoryRepoMock
              .Setup(x => x.FindByConditionAsync(cancellationToken, It.IsAny<CategoryGetByIdAsNoTrackingSpecification>()))
              .ReturnsAsync(new List<Category>() { category });

            _unitOfWorkMock
                .Setup(x => x.SaveChangesAsyncWithResult(cancellationToken))
                .ReturnsAsync(0);

            _categoryRepoMock
                .Setup(x => x.Update(It.IsAny<Category>()));

            // Act
            var categoryService = new CategoryService(_unitOfWorkMock.Object, _mapperMock.Object, _categoryRepoMock.Object);
            var result = await categoryService.UpdateCategoryAsync(categoryDto, cancellationToken);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.ErrorMessage.StatusCode);
            Assert.Equal("Error occurred while updating category!", result.ErrorMessage.Message);
        }
    }
}
