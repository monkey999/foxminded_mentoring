using AutoMapper;
using DataAccess.Specifications.TransactionSpecs;
using Domain.Enums;
using Domain.Models;
using Domain.RepoInterfaces;
using Logic.DTO_Contracts.Responses.Get;
using Logic.ServiceInterfaces;
using Logic.Services;
using Moq;
using Xunit;

namespace ExpenseTracker.Tests.TransactionService_Tests
{
    public class Test_GetTransactionByIdAsync
    {
        private readonly Mock<IUnitOfWOrk> _unitOfWorkMock;
        private readonly Mock<ITransactionRepo> _transactionRepoMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<ITransactionProcessor> _transactionProcessorMock;

        public Test_GetTransactionByIdAsync()
        {
            _unitOfWorkMock = new Mock<IUnitOfWOrk>();
            _transactionRepoMock = new Mock<ITransactionRepo>();
            _mapperMock = new Mock<IMapper>();
            _transactionProcessorMock = new Mock<ITransactionProcessor>();
        }

        [Fact]
        public async Task GetTransactionByIdAsync_WhenTransactionExists_ReturnsTransaction()
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
            var transactionRespDto = new List<TransactionRespForGetDto>
            {
                new TransactionRespForGetDto
                {
                    Id = transactionId,
                    TransactionType = "Income",
                    Amount = 100.0,
                    SenderId = Guid.NewGuid(),
                    ReceiverId = Guid.NewGuid()
                }
            };

            _transactionRepoMock.Setup(repo => repo.FindByConditionAsync(cancellationToken, It.IsAny<TransactionGetByIdSpecification>()))
                .ReturnsAsync(transaction);

            _transactionRepoMock.Setup(repo => repo.FindByConditionAsync(cancellationToken, It.IsAny<TransactionGetByIdAsNoTrackingSpecification>()))
                .ReturnsAsync(transaction);

            _mapperMock.Setup(x => x.Map<IEnumerable<TransactionRespForGetDto>>(transaction))
                .Returns(transactionRespDto);

            // Act
            var transactionService = new TransactionService(_unitOfWorkMock.Object, _mapperMock.Object, _transactionProcessorMock.Object, _transactionRepoMock.Object);
            var result = await transactionService.GetTransactionByIdAsync(transactionId, cancellationToken);

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.ErrorMessage);
        }

        [Fact]
        public async Task GetTransactionByIdAsync_WhenTransactionNotFound_ReturnsErrorMessage()
        {
            // Arrange
            var cancellationToken = CancellationToken.None;
            var transactionId = Guid.NewGuid();
            _transactionRepoMock.Setup(repo => repo.FindByConditionAsync(cancellationToken, It.IsAny<TransactionGetByIdSpecification>()))
                .ReturnsAsync((IEnumerable<Transaction>)null);

            // Act
            var transactionService = new TransactionService(_unitOfWorkMock.Object, _mapperMock.Object, _transactionProcessorMock.Object, _transactionRepoMock.Object);
            var result = await transactionService.GetTransactionByIdAsync(transactionId, cancellationToken);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.ErrorMessage);
            Assert.Equal(404, result.ErrorMessage.StatusCode);
        }
    }
}
