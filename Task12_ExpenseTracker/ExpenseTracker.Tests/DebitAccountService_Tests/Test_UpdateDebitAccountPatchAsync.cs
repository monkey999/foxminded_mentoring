using AutoMapper;
using DataAccess.Specifications.CategorySpecs;
using DataAccess.Specifications.DebitAccountSpecs;
using Domain.Enums;
using Domain.Models;
using Domain.Models.Accounts;
using Domain.RepoInterfaces;
using Logic.DTO_Contracts.Responses.Update;
using Logic.Services;
using Microsoft.AspNetCore.JsonPatch;
using Moq;
using Xunit;

namespace ExpenseTracker.Tests.DebitAccountService_Tests
{
    public class Test_UpdateDebitAccountPatchAsync
    {
        private readonly Mock<IUnitOfWOrk> _unitOfWorkMock;
        private readonly Mock<IDebitAccountRepo> _debitAccRepo;
        private readonly Mock<IMapper> _mapperMock;

        public Test_UpdateDebitAccountPatchAsync()
        {
            _unitOfWorkMock = new Mock<IUnitOfWOrk>();
            _debitAccRepo = new Mock<IDebitAccountRepo>();
            _mapperMock = new Mock<IMapper>();
        }

        [Fact]
        public async Task UpdateDebitAccountPatchAsync_DebitAccountExists_ReturnsUpdatedDebitAccount()
        {
            // Arrange
            var debitAccountId = Guid.NewGuid();
            var cancellationToken = CancellationToken.None;

            var patchDocument = new JsonPatchDocument<DebitAccount>();
            var updatedebitAccountRespDto = new UpdateDebitAccountPatchRespDto 
            {
                Id = debitAccountId,
                Name = "Updated DebitAccount Name", 
                CurrencyType = "USD"
            };
            patchDocument.Replace(c => c.Name, "Updated DebitAccount Name");
            patchDocument.Replace(c => c.CurrencyType, CurrencyType.USD);

            var debitAccountToUpdate = new DebitAccount() 
            {
                Id = debitAccountId,
                Name = "DebitAccount1",
                CurrencyType = CurrencyType.USD 
            };

            _debitAccRepo.Setup(repo => repo.FindByConditionAsync(cancellationToken, It.IsAny<DebitAccountGetByIdAsNoTrackingSpecification>()))
                .ReturnsAsync(new List<DebitAccount> { debitAccountToUpdate });

            _debitAccRepo.Setup(repo => repo.FindByConditionAsync(cancellationToken, It.IsAny<DebitAccountGetByIdSpecification>()))
                .ReturnsAsync(new List<DebitAccount> { debitAccountToUpdate });

            _unitOfWorkMock
                .Setup(x => x.SaveChangesAsyncWithResult(cancellationToken))
                    .ReturnsAsync(1);

            _mapperMock.Setup(x => x.Map<UpdateDebitAccountPatchRespDto>(debitAccountToUpdate))
                .Returns(updatedebitAccountRespDto);

            // Act
            var debitAccService = new DebitAccountService(_unitOfWorkMock.Object, _mapperMock.Object, _debitAccRepo.Object);
            var result = await debitAccService.UpdateDebitAccountPatchAsync(debitAccountId, patchDocument, cancellationToken);

            // Assert
            _unitOfWorkMock.Verify(x => x.SaveChangesAsyncWithResult(cancellationToken), Times.Once);
            Assert.Null(result.ErrorMessage);
            Assert.NotNull(result);
            Assert.Equal("Updated DebitAccount Name", result.Name);
            Assert.Equal(CurrencyType.USD.ToString(), result.CurrencyType);
            Assert.Equal(debitAccountId, result.Id);
        }

        [Fact]
        public async Task UpdateDebitAccountPatchAsync_DebitAccountNotFound_ReturnsNotFoundResponse()
        {
            // Arrange
            var DebitAccountId = Guid.NewGuid();
            var patchDocument = new JsonPatchDocument<DebitAccount>();
            patchDocument.Replace(c => c.Name, "Updated DebitAccount Name");
            patchDocument.Replace(c => c.CurrencyType, CurrencyType.USD);

            var cancellationToken = CancellationToken.None;

            _debitAccRepo.Setup(repo => repo.FindByConditionAsync(cancellationToken, It.IsAny<DebitAccountGetByIdSpecification>()))
                .ReturnsAsync(new List<DebitAccount>() { });

            // Act
            var debitAccService = new DebitAccountService(_unitOfWorkMock.Object, _mapperMock.Object, _debitAccRepo.Object);
            var result = await debitAccService.UpdateDebitAccountPatchAsync(DebitAccountId, patchDocument, cancellationToken);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(404, result.ErrorMessage.StatusCode);
            Assert.Equal("Debit account not found.", result.ErrorMessage.Message);
        }

        [Fact]
        public async Task UpdateDebitAccountPatchAsync_UpdateFails_ReturnsBadRequestResponse()
        {
            // Arrange
            var DebitAccountId = Guid.NewGuid();
            var patchDocument = new JsonPatchDocument<DebitAccount>();
            patchDocument.Replace(c => c.Name, "Updated DebitAccount Name");
            patchDocument.Replace(c => c.CurrencyType, CurrencyType.USD);

            var debitAccountList = new List<DebitAccount>
            {
                new DebitAccount {Id = Guid.NewGuid(), Name = "TestDebitAccount", CurrencyType = CurrencyType.USD }
            };
            var cancellationToken = CancellationToken.None;

            _debitAccRepo.Setup(repo => repo.FindByConditionAsync(cancellationToken, It.IsAny<DebitAccountGetByIdAsNoTrackingSpecification>()))
               .ReturnsAsync(debitAccountList);

            _debitAccRepo.Setup(repo => repo.FindByConditionAsync(cancellationToken, It.IsAny<DebitAccountGetByIdSpecification>()))
               .ReturnsAsync(debitAccountList);

            _unitOfWorkMock
                .Setup(x => x.SaveChangesAsyncWithResult(cancellationToken))
                .ReturnsAsync(0);

            // Act
            var debitAccService = new DebitAccountService(_unitOfWorkMock.Object, _mapperMock.Object, _debitAccRepo.Object);
            var result = await debitAccService.UpdateDebitAccountPatchAsync(DebitAccountId, patchDocument, cancellationToken);

            // Assert
            _unitOfWorkMock.Verify(x => x.SaveChangesAsyncWithResult(cancellationToken), Times.Once);
            Assert.NotNull(result);
            Assert.Equal(400, result.ErrorMessage.StatusCode);
        }
    }
}
