using AutoMapper;
using DataAccess.Specifications.CategorySpecs;
using Domain.Enums;
using Domain.Models;
using Domain.RepoInterfaces;
using Logic.DTO_Contracts.Responses.Get;
using Logic.Services;
using Moq;
using Xunit;
using static Task12_ExpenseTracker.ApiRoutes;

namespace ExpenseTracker.Tests.CategoryService_Tests
{
    public class Test_GetCategoryByIdAsync
    {
        private readonly Mock<IUnitOfWOrk> _unitOfWorkMock;
        private readonly Mock<ICategoryRepo> _categoryRepoMock;
        private readonly Mock<IMapper> _mapperMock;

        public Test_GetCategoryByIdAsync()
        {
            _unitOfWorkMock = new Mock<IUnitOfWOrk>();
            _categoryRepoMock = new Mock<ICategoryRepo>();
            _mapperMock = new Mock<IMapper>();
        }

        [Fact]
        public async Task GetCategoryByIdAsync_WhenCategoryExists_ReturnsCategory()
        {
            // Arrange
            var cancellationToken = CancellationToken.None;
            var categoryId = Guid.NewGuid();
            var category = new List<Category>
            {
                new Category { Id = categoryId, CategoryName = "Category1", CategoryType = CategoryType.Income }
            };
            
            var сategoryRespDto = new List<CategoryRespDto>
            {
                new CategoryRespDto { Id = categoryId, CategoryName = "Category1", CategoryType = "Income" }
            };

            _categoryRepoMock.Setup(repo => repo.FindByConditionAsync(cancellationToken, It.IsAny<CategoryGetByIdSpecification>()))
            .ReturnsAsync(category);

            _categoryRepoMock.Setup(repo => repo.FindByConditionAsync(cancellationToken, It.IsAny<CategoryGetByIdAsNoTrackingSpecification>()))
            .ReturnsAsync(category);

            _mapperMock.Setup(x => x.Map<IEnumerable<CategoryRespDto>>(category))
                .Returns(сategoryRespDto);
            // Act
            var categoryService = new CategoryService(_unitOfWorkMock.Object, _mapperMock.Object, _categoryRepoMock.Object);
            var result = await categoryService.GetCategoryByIdAsync(categoryId, cancellationToken);

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.ErrorMessage);
        }

        [Fact]
        public async Task GetCategoryByIdAsync_WhenCategoryNotFound_ReturnsErrorMessage()
        {
            // Arrange
            var cancellationToken = CancellationToken.None;
            var categoryId = Guid.NewGuid();
            _categoryRepoMock.Setup(repo => repo.FindByConditionAsync(cancellationToken, It.IsAny<CategoryGetByIdSpecification>()))
                .ReturnsAsync((IEnumerable<Category>)null);

            // Act
            var categoryService = new CategoryService(_unitOfWorkMock.Object, _mapperMock.Object, _categoryRepoMock.Object);
            var result = await categoryService.GetCategoryByIdAsync(categoryId, cancellationToken);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.ErrorMessage);
            Assert.Equal(404, result.ErrorMessage.StatusCode);
        }
    }
}
