using AutoMapper;
using DataAccess.Specifications.DebitAccountSpecs;
using Domain.Enums;
using Domain.Models;
using Domain.Models.Accounts;
using Domain.RepoInterfaces;
using Logic.DTO_Contracts.Responses.Get;
using Logic.Services;
using Moq;
using Xunit;

namespace ExpenseTracker.Tests.DebitAccountService_Tests
{
    public class Test_DeleteDebitAccountAsync
    {
        private readonly Mock<IUnitOfWOrk> _unitOfWorkMock;
        private readonly Mock<IDebitAccountRepo> _debitAccRepo;
        private readonly Mock<IMapper> _mapperMock;

        public Test_DeleteDebitAccountAsync()
        {
            _unitOfWorkMock = new Mock<IUnitOfWOrk>();
            _debitAccRepo = new Mock<IDebitAccountRepo>();
            _mapperMock = new Mock<IMapper>();
        }

        [Fact]
        public async Task DebitAccountExists_ReturnsDeletedResponse()
        {
            // Arrange
            var debitAccountId = Guid.NewGuid();
            var cancellationToken = CancellationToken.None;

            var debitAccs = new List<DebitAccount>
            {
                new DebitAccount()
            };

            _unitOfWorkMock.Setup(uow => uow.SaveChangesAsyncWithResult(cancellationToken)).ReturnsAsync(1);
            _debitAccRepo.Setup(repo => repo.RemoveById(debitAccountId));

            _debitAccRepo
             .Setup(x => x.FindByConditionAsync(cancellationToken, It.IsAny<DebitAccountGetByIdAsNoTrackingSpecification>()))
             .ReturnsAsync(debitAccs);

            // Act
            var debitAccService = new DebitAccountService(_unitOfWorkMock.Object, _mapperMock.Object, _debitAccRepo.Object);
            var result = await debitAccService.DeleteDebitAccountAsync(debitAccountId, cancellationToken);

            // Assert
            Assert.True(result.Deleted);
            Assert.Null(result.Error);

            _unitOfWorkMock.Verify(uow => uow.SaveChangesAsyncWithResult(cancellationToken), Times.Once);
            _debitAccRepo.Verify(repo => repo.RemoveById(debitAccountId), Times.Once);
        }

        [Fact]
        public async Task DebitAccountNotFound_ReturnsErrorResponse()
        {
            // Arrange
            var debitAccountId = Guid.NewGuid();
            var cancellationToken = CancellationToken.None;

            _unitOfWorkMock.Setup(uow => uow.SaveChangesAsyncWithResult(cancellationToken)).ReturnsAsync(0);
            _debitAccRepo
             .Setup(x => x.FindByConditionAsync(cancellationToken, It.IsAny<DebitAccountGetByIdAsNoTrackingSpecification>()))
             .ReturnsAsync((List<DebitAccount>)null);

            // Act
            var debitAccService = new DebitAccountService(_unitOfWorkMock.Object, _mapperMock.Object, _debitAccRepo.Object);
            var result = await debitAccService.DeleteDebitAccountAsync(debitAccountId, cancellationToken);

            // Assert
            Assert.False(result.Deleted);
            Assert.NotNull(result.Error);
            Assert.Equal(400, result.Error.StatusCode);
            Assert.Equal("Such debit account doesn't exist!", result.Error.Message);

            _unitOfWorkMock.Verify(uow => uow.SaveChangesAsyncWithResult(cancellationToken), Times.Never);
            _debitAccRepo.Verify(repo => repo.RemoveById(debitAccountId), Times.Never);
        }

        [Fact]
        public async Task ErrorDeletingDebitAccount_ReturnsErrorResponse()
        {
            // Arrange
            var debitAccountId = Guid.NewGuid();
            var cancellationToken = CancellationToken.None;

            var debitAccount = new List<DebitAccount>
            {
                new DebitAccount { Id = Guid.NewGuid(), Name = "DebitAccount1", CurrencyType = CurrencyType.USD, Balance = 123 }
            };

            _unitOfWorkMock.Setup(uow => uow.SaveChangesAsyncWithResult(cancellationToken)).ReturnsAsync(0);
            _debitAccRepo.Setup(repo => repo.RemoveById(debitAccountId));

            _debitAccRepo
            .Setup(x => x.FindByConditionAsync(cancellationToken, It.IsAny<DebitAccountGetByIdAsNoTrackingSpecification>()))
            .ReturnsAsync(debitAccount);

            // Act
            var debitAccService = new DebitAccountService(_unitOfWorkMock.Object, _mapperMock.Object, _debitAccRepo.Object);
            var result = await debitAccService.DeleteDebitAccountAsync(debitAccountId, cancellationToken);

            // Assert
            Assert.False(result.Deleted);
            Assert.NotNull(result.Error);
            Assert.Equal(400, result.Error.StatusCode);
            Assert.Equal("Error occurred while deleting debit account!", result.Error.Message);

            _unitOfWorkMock.Verify(uow => uow.SaveChangesAsyncWithResult(cancellationToken), Times.Once);
            _debitAccRepo.Verify(repo => repo.RemoveById(debitAccountId), Times.Once);
        }
    }
}
