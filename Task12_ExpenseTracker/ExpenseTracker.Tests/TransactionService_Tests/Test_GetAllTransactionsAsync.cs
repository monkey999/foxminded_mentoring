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
    public class Test_GetAllTransactionsAsync
    {
        private readonly Mock<IUnitOfWOrk> _unitOfWorkMock;
        private readonly Mock<ITransactionRepo> _transactionRepoMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<ITransactionProcessor> _transactionProcessorMock;

        public Test_GetAllTransactionsAsync()
        {
            _unitOfWorkMock = new Mock<IUnitOfWOrk>();
            _transactionRepoMock = new Mock<ITransactionRepo>();
            _mapperMock = new Mock<IMapper>();
            _transactionProcessorMock = new Mock<ITransactionProcessor>();
        }

        [Fact]
        public async Task GetAllTransactionsAsync_WhenTransactionsExist_ReturnsTransactions()
        {
            // Arrange
            var cancellationToken = CancellationToken.None;
            var transactions = new List<Transaction>
            {
                new Transaction
                {
                    Id = Guid.NewGuid(),
                    TransactionType = TransactionType.Income,
                    Amount = 100.0,
                    SenderId = Guid.NewGuid(),
                    ReceiverId = Guid.NewGuid()
                },
                new Transaction
                {
                    Id = Guid.NewGuid(),
                    TransactionType = TransactionType.Income,
                    Amount = 150.0,
                    SenderId = Guid.NewGuid(),
                    ReceiverId = Guid.NewGuid()
                }
            };
            var transactionRespDtos = new List<TransactionRespForGetDto>
            {
                new TransactionRespForGetDto 
                { 
                    Id = Guid.NewGuid(),
                    TransactionType = "Income",
                    Amount = 100.0,
                    SenderId = Guid.NewGuid(),
                    ReceiverId = Guid.NewGuid() 
                },
                new TransactionRespForGetDto
                {
                    Id = Guid.NewGuid(),
                    TransactionType = "Income",
                    Amount = 100.0,
                    SenderId = Guid.NewGuid(),
                    ReceiverId = Guid.NewGuid()
                }
            };

            _transactionRepoMock.Setup(repo => repo.FindByConditionAsync(cancellationToken, It.IsAny<TransactionGetAllSpecification>()))
                .ReturnsAsync(transactions);

            _mapperMock.Setup(x => x.Map<IEnumerable<TransactionRespForGetDto>>(transactions)).Returns(transactionRespDtos);

            // Act
            var transactionService = new TransactionService(_unitOfWorkMock.Object, _mapperMock.Object, _transactionProcessorMock.Object, _transactionRepoMock.Object);
            var result = await transactionService.GetAllTransactionsAsync(cancellationToken);

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.ErrorMessage);
        }

        [Fact]
        public async Task GetAllTransactionsAsync_WhenNoTransactionsExist_ReturnsErrorMessage()
        {
            // Arrange
            var cancellationToken = CancellationToken.None;

            _transactionRepoMock.Setup(repo => repo.FindByConditionAsync(cancellationToken, It.IsAny<TransactionGetAllSpecification>()))
                .ReturnsAsync(new List<Transaction>());

            // Act
            var transactionService = new TransactionService(_unitOfWorkMock.Object, _mapperMock.Object, _transactionProcessorMock.Object, _transactionRepoMock.Object);
            var result = await transactionService.GetAllTransactionsAsync(cancellationToken);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.ErrorMessage);
            Assert.Equal(404, result.ErrorMessage.StatusCode);
        }
    }
}
