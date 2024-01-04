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
    public class Test_GetAllCategoriesAsync
    {
        private readonly Mock<IUnitOfWOrk> _unitOfWorkMock;
        private readonly Mock<ICategoryRepo> _categoryRepoMock;
        private readonly Mock<IMapper> _mapperMock;

        public Test_GetAllCategoriesAsync()
        {
            _unitOfWorkMock = new Mock<IUnitOfWOrk>();
            _categoryRepoMock = new Mock<ICategoryRepo>();
            _mapperMock = new Mock<IMapper>();
        }

        [Fact]
        public async Task GetAllCategoriesAsync_WhenCategoriesExist_ReturnsCategories()
        {
            // Arrange
            var cancellationToken = CancellationToken.None;
            var categories = new List<Category>
            {
                new Category { Id = Guid.NewGuid(), CategoryName = "Category1", CategoryType = CategoryType.Income },
                new Category { Id = Guid.NewGuid(), CategoryName = "Category2", CategoryType = CategoryType.Expense }
            };
            var categoryRespDtos = new List<CategoryRespDto>
            {
                new CategoryRespDto { Id = Guid.NewGuid(), CategoryName = "Category1", CategoryType = "Income" },
                new CategoryRespDto { Id = Guid.NewGuid(), CategoryName = "Category2", CategoryType = "Expense" }
            };

            _categoryRepoMock.Setup(repo => repo.FindByConditionAsync(cancellationToken, It.IsAny<CategoryGetAllSpecification>()))
                .ReturnsAsync(categories);

            _mapperMock.Setup(x => x.Map<IEnumerable<CategoryRespDto>>(categories)).Returns(categoryRespDtos);

            // Act
            var categoryService = new CategoryService(_unitOfWorkMock.Object, _mapperMock.Object, _categoryRepoMock.Object);
            var result = await categoryService.GetAllCategoriesAsync(cancellationToken);

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.ErrorMessage);
        }

        [Fact]
        public async Task GetAllCategoriesAsync_WhenNoCategoriesExist_ReturnsErrorMessage()
        {
            // Arrange
            var cancellationToken = CancellationToken.None;

            _categoryRepoMock.Setup(repo => repo.FindByConditionAsync(cancellationToken, It.IsAny<CategoryGetAllSpecification>()))
                .ReturnsAsync(new List<Category>());

            // Act
            var categoryService = new CategoryService(_unitOfWorkMock.Object, _mapperMock.Object, _categoryRepoMock.Object);
            var result = await categoryService.GetAllCategoriesAsync(cancellationToken);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.ErrorMessage);
            Assert.Equal(404, result.ErrorMessage.StatusCode);
        }
    }
}

