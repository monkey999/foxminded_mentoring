using AutoMapper;
using Domain.Enums;
using Domain.Models;
using Domain.RepoInterfaces;
using Logic.DTO_Contracts.Requests.Create;
using Logic.DTO_Contracts.Responses.Create;
using Logic.Services;
using Moq;
using Xunit;

namespace ExpenseTracker.Tests.CategoryService_Tests
{
    public class Test_CreateCategoryAsync
    {
        private readonly Mock<IUnitOfWOrk> _unitOfWorkMock;
        private readonly Mock<ICategoryRepo> _categoryRepoMock;
        private readonly Mock<IMapper> _mapperMock;

        public Test_CreateCategoryAsync()
        {
            _unitOfWorkMock = new Mock<IUnitOfWOrk>();
            _categoryRepoMock = new Mock<ICategoryRepo>();
            _mapperMock = new Mock<IMapper>();
        }

        [Fact]
        public async Task SuccessfulCreation_ReturnsCategory()
        {
            // Arrange
            var cancellationToken = CancellationToken.None;

            var categoryDto = new CreateCategoryReqDTO 
            {
                CategoryName = "TestCategory", 
                CategoryType = "TestType" 
            };

            var category = new Category 
            { 
                Id = Guid.NewGuid(), 
                CategoryName = "TestCategory",
                CategoryType = CategoryType.Income 
            };

            _unitOfWorkMock.Setup(uow => uow.SaveChangesAsyncWithResult(cancellationToken)).ReturnsAsync(1);
            _categoryRepoMock.Setup(repo => repo.AddAsync(It.IsAny<Category>(), cancellationToken));

            _mapperMock.Setup(mapper => mapper.Map<Category>(categoryDto)).Returns(category);
            _mapperMock.Setup(mapper => mapper.Map<CreateCategoryRespDTO>(category)).Returns(new CreateCategoryRespDTO { Id = category.Id });

            // Act
            var categoryService = new CategoryService(_unitOfWorkMock.Object, _mapperMock.Object, _categoryRepoMock.Object);
            var result = await categoryService.CreateCategoryAsync(categoryDto, cancellationToken);

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.ErrorMessage);
            Assert.Equal(category.Id, result.Id);
        }

        [Fact]
        public async Task ValidationErrors_ReturnsErrorResponse()
        {
            // Arrange
            var cancellationToken = CancellationToken.None;
            var categoryDto = new CreateCategoryReqDTO();

            // Act
            var categoryService = new CategoryService(_unitOfWorkMock.Object, _mapperMock.Object, _categoryRepoMock.Object);
            var result = await categoryService.CreateCategoryAsync(categoryDto, cancellationToken);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.ErrorMessage);
            Assert.Equal(400, result.ErrorMessage.StatusCode);
            Assert.Contains("Category wasn't created!", result.ErrorMessage.Message);
        }
    }
}