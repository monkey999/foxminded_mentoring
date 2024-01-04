using AutoMapper;
using DataAccess.Specifications.TransactionSpecs;
using Domain.Enums;
using Domain.Models;
using Domain.RepoInterfaces;
using Logic.ServiceInterfaces;
using Logic.Services;
using Moq;
using Xunit;

namespace ExpenseTracker.Tests.TransactionService_Tests
{
    public class Test_DeleteTransactionAsync
    {
        private readonly Mock<IUnitOfWOrk> _unitOfWorkMock;
        private readonly Mock<ITransactionRepo> _transactionRepoMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<ITransactionProcessor> _transactionProcessorMock;

        public Test_DeleteTransactionAsync()
        {
            _unitOfWorkMock = new Mock<IUnitOfWOrk>();
            _transactionRepoMock = new Mock<ITransactionRepo>();
            _mapperMock = new Mock<IMapper>();
            _transactionProcessorMock = new Mock<ITransactionProcessor>();
        }

        [Fact]
        public async Task TransactionExists_ReturnsDeletedResponse()
        {
            // Arrange
            var transactionId = Guid.NewGuid();
            var cancellationToken = CancellationToken.None;
            var transactions = new List<Transaction>
            {
                new Transaction()
            };

            _unitOfWorkMock.Setup(uow => uow.SaveChangesAsyncWithResult(cancellationToken)).ReturnsAsync(1);
            _transactionRepoMock.Setup(repo => repo.RemoveById(transactionId));

            _transactionRepoMock
             .Setup(x => x.FindByConditionAsync(cancellationToken, It.IsAny<TransactionGetByIdAsNoTrackingSpecification>()))
             .ReturnsAsync(transactions);

            // Act
            var transactionService = new TransactionService(_unitOfWorkMock.Object, _mapperMock.Object, _transactionProcessorMock.Object, _transactionRepoMock.Object);
            var result = await transactionService.DeleteTransactionAsync(transactionId, cancellationToken);

            // Assert
            Assert.True(result.Deleted);
            Assert.Null(result.Error);

            _unitOfWorkMock.Verify(uow => uow.SaveChangesAsyncWithResult(cancellationToken), Times.Once);
            _transactionRepoMock.Verify(repo => repo.RemoveById(transactionId), Times.Once);
        }

        [Fact]
        public async Task TransactionNotFound_ReturnsErrorResponse()
        {
            // Arrange
            var categoryId = Guid.NewGuid();
            var cancellationToken = CancellationToken.None;

            _unitOfWorkMock.Setup(uow => uow.SaveChangesAsyncWithResult(cancellationToken)).ReturnsAsync(0);
            _transactionRepoMock
              .Setup(x => x.FindByConditionAsync(cancellationToken, It.IsAny<TransactionGetByIdAsNoTrackingSpecification>()))
              .ReturnsAsync((List<Transaction>)null);

            // Act
            var transactionService = new TransactionService(_unitOfWorkMock.Object, _mapperMock.Object, _transactionProcessorMock.Object, _transactionRepoMock.Object);
            var result = await transactionService.DeleteTransactionAsync(categoryId, cancellationToken);

            // Assert
            Assert.False(result.Deleted);
            Assert.NotNull(result.Error);
            Assert.Equal(400, result.Error.StatusCode);
            Assert.Equal("Such transaction doesn't exist!", result.Error.Message);

            _unitOfWorkMock.Verify(uow => uow.SaveChangesAsyncWithResult(cancellationToken), Times.Never);
            _transactionRepoMock.Verify(repo => repo.RemoveById(categoryId), Times.Never);
        }

        [Fact]
        public async Task ErrorDeletingTransaction_ReturnsErrorResponse()
        {
            // Arrange
            var cancellationToken = CancellationToken.None;
            var transactionId = Guid.NewGuid();

            var transaction = new List<Transaction>
            {
                new Transaction
                {
                    Id = transactionId,
                    TransactionType = TransactionType.Income,
                    Amount = 100.0,
                    SenderId = Guid.NewGuid(),
                    ReceiverId = Guid.NewGuid()
                }
            };

            _unitOfWorkMock.Setup(uow => uow.SaveChangesAsyncWithResult(cancellationToken)).ReturnsAsync(0);
            _transactionRepoMock.Setup(repo => repo.RemoveById(transactionId));

            _transactionRepoMock
             .Setup(x => x.FindByConditionAsync(cancellationToken, It.IsAny<TransactionGetByIdAsNoTrackingSpecification>()))
             .ReturnsAsync(transaction);

            // Act
            var transactionService = new TransactionService(_unitOfWorkMock.Object, _mapperMock.Object, _transactionProcessorMock.Object, _transactionRepoMock.Object);
            var result = await transactionService.DeleteTransactionAsync(transactionId, cancellationToken);

            // Assert
            Assert.False(result.Deleted);
            Assert.NotNull(result.Error);
            Assert.Equal(400, result.Error.StatusCode);
            Assert.Equal("Error occurred while deleting transaction!", result.Error.Message);

            _unitOfWorkMock.Verify(uow => uow.SaveChangesAsyncWithResult(cancellationToken), Times.Once);
            _transactionRepoMock.Verify(repo => repo.RemoveById(transactionId), Times.Once);
        }
    }
}
