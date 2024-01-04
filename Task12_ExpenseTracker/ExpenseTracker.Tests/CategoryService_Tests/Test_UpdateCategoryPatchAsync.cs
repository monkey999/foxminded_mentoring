using AutoMapper;
using DataAccess.Specifications.CategorySpecs;
using Domain.Enums;
using Domain.Models;
using Domain.RepoInterfaces;
using Logic.DTO_Contracts.Responses.Update;
using Logic.Services;
using Microsoft.AspNetCore.JsonPatch;
using Moq;
using Xunit;

namespace ExpenseTracker.Tests.CategoryService_Tests
{
    public class Test_UpdateCategoryPatchAsync
    {
        private readonly Mock<IUnitOfWOrk> _unitOfWorkMock;
        private readonly Mock<ICategoryRepo> _categoryRepoMock;
        private readonly Mock<IMapper> _mapperMock;

        public Test_UpdateCategoryPatchAsync()
        {
            _unitOfWorkMock = new Mock<IUnitOfWOrk>();
            _categoryRepoMock = new Mock<ICategoryRepo>();
            _mapperMock = new Mock<IMapper>();
        }

        [Fact]
        public async Task UpdateCategoryPatchAsync_CategoryExists_ReturnsUpdatedCategory()
        {
            // Arrange
            var categoryId = Guid.NewGuid();
            var cancellationToken = CancellationToken.None;

            var patchDocument = new JsonPatchDocument<Category>();

            var updateCategoryRespDto = new UpdateCategoryPatchRespDto 
            { 
                Id = categoryId, 
                CategoryName = "Updated Category Name", 
                CategoryType = "Income" 
            };

            patchDocument.Replace(c => c.CategoryName, "Updated Category Name");
            patchDocument.Replace(c => c.CategoryType, CategoryType.Income);

            var categoryToUpdate = new Category() { Id = categoryId, CategoryName = "Category1", CategoryType = CategoryType.Income };

            _categoryRepoMock.Setup(repo => repo.FindByConditionAsync(cancellationToken, It.IsAny<CategoryGetByIdAsNoTrackingSpecification>()))
                .ReturnsAsync(new List<Category> { categoryToUpdate });

            _categoryRepoMock.Setup(repo => repo.FindByConditionAsync(cancellationToken, It.IsAny<CategoryGetByIdSpecification>()))
                .ReturnsAsync(new List<Category> { categoryToUpdate });

            _unitOfWorkMock
                .Setup(x => x.SaveChangesAsyncWithResult(cancellationToken))
                    .ReturnsAsync(1);

            _mapperMock.Setup(x => x.Map<UpdateCategoryPatchRespDto>(categoryToUpdate)).Returns(updateCategoryRespDto);

            // Act
            var categoryService = new CategoryService(_unitOfWorkMock.Object, _mapperMock.Object, _categoryRepoMock.Object);
            var result = await categoryService.UpdateCategoryPatchAsync(categoryId, patchDocument, cancellationToken);

            // Assert
            _unitOfWorkMock.Verify(x => x.SaveChangesAsyncWithResult(cancellationToken), Times.Once);
            Assert.Null(result.ErrorMessage);
            Assert.NotNull(result);
            Assert.Equal("Updated Category Name", result.CategoryName);
            Assert.Equal(CategoryType.Income.ToString(), result.CategoryType);
            Assert.Equal(categoryId, result.Id);
        }

        [Fact]
        public async Task UpdateCategoryPatchAsync_CategoryNotFound_ReturnsNotFoundResponse()
        {
            // Arrange
            var categoryId = Guid.NewGuid();
            var patchDocument = new JsonPatchDocument<Category>();
            patchDocument.Replace(c => c.CategoryName, "Updated Category Name");
            patchDocument.Replace(c => c.CategoryType, CategoryType.Income);

            var cancellationToken = CancellationToken.None;

            _categoryRepoMock.Setup(repo => repo.FindByConditionAsync(cancellationToken, It.IsAny<CategoryGetByIdSpecification>()))
                .ReturnsAsync(new List<Category>() { });

            // Act
            var categoryService = new CategoryService(_unitOfWorkMock.Object, _mapperMock.Object, _categoryRepoMock.Object);
            var result = await categoryService.UpdateCategoryPatchAsync(categoryId, patchDocument, cancellationToken);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(404, result.ErrorMessage.StatusCode);
            Assert.Equal("Category not found.", result.ErrorMessage.Message);
        }

        [Fact]
        public async Task UpdateCategoryPatchAsync_UpdateFails_ReturnsBadRequestResponse()
        {
            // Arrange
            var categoryId = Guid.NewGuid();
            var patchDocument = new JsonPatchDocument<Category>();
            patchDocument.Replace(c => c.CategoryName, "Updated Category Name");
            patchDocument.Replace(c => c.CategoryType, CategoryType.Income);

            var categoryList = new List<Category>
            {
                new Category { Id = categoryId, CategoryName = "Category1", CategoryType = CategoryType.Income }
            };
            var cancellationToken = CancellationToken.None;

            _categoryRepoMock.Setup(repo => repo.FindByConditionAsync(cancellationToken, It.IsAny<CategoryGetByIdAsNoTrackingSpecification>()))
               .ReturnsAsync(categoryList);

            _categoryRepoMock.Setup(repo => repo.FindByConditionAsync(cancellationToken, It.IsAny<CategoryGetByIdSpecification>()))
               .ReturnsAsync(categoryList);

            _unitOfWorkMock
                .Setup(x => x.SaveChangesAsyncWithResult(cancellationToken))
                .ReturnsAsync(0);

            // Act
            var categoryService = new CategoryService(_unitOfWorkMock.Object, _mapperMock.Object, _categoryRepoMock.Object);
            var result = await categoryService.UpdateCategoryPatchAsync(categoryId, patchDocument, cancellationToken);

            // Assert
            _unitOfWorkMock.Verify(x => x.SaveChangesAsyncWithResult(cancellationToken), Times.Once);
            Assert.NotNull(result);
            Assert.Equal(400, result.ErrorMessage.StatusCode);
        }
    }
}
