using AutoMapper;
using Domain.Enums;
using Domain.Models;
using Domain.RepoInterfaces;
using Logic.DTO_Contracts.Requests.Create;
using Logic.DTO_Contracts.Responses.Create;
using Logic.ServiceInterfaces;
using Logic.Services;
using Moq;
using Xunit;

namespace ExpenseTracker.Tests.TransactionService_Tests
{
    public class Test_CreateTransactionAsync
    {
        private readonly Mock<IUnitOfWOrk> _unitOfWorkMock;
        private readonly Mock<ITransactionRepo> _transactionRepoMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<ITransactionProcessor> _transactionProcessorMock;

        public Test_CreateTransactionAsync()
        {
            _unitOfWorkMock = new Mock<IUnitOfWOrk>();
            _transactionRepoMock = new Mock<ITransactionRepo>();
            _mapperMock = new Mock<IMapper>();
            _transactionProcessorMock = new Mock<ITransactionProcessor>();
        }

        [Fact]
        public async Task SuccessfulCreation_ReturnsTransaction()
        {
            // Arrange
            var cancellationToken = CancellationToken.None;
            var transactionId = Guid.NewGuid();
            var senderId = Guid.NewGuid();
            var receiverId = Guid.NewGuid();

            var createTransactionDto = new CreateTransactionReqDTO
            {
                TransactionType = "Income",
                Amount = 100.0,
                SenderId = senderId,
                ReceiverId = receiverId
            };

            var expectedTransactionResp = new CreateTransactionRespDTO
            {
                TransactionDto = new TransactionRespForCreateDto
                {
                    Id = transactionId,
                    TransactionType = "Income", 
                    Amount = 100.0,
                    SenderId = senderId,
                    ReceiverId = receiverId
                }
            };

            _transactionProcessorMock.Setup(x => x.ProcessTransaction(createTransactionDto, cancellationToken))
                .ReturnsAsync(expectedTransactionResp);

            _mapperMock.Setup(mapper => mapper.Map<TransactionRespForCreateDto>(expectedTransactionResp.TransactionDto))
                .Returns(expectedTransactionResp.TransactionDto);

            // Act
            var transactionService = new TransactionService(_unitOfWorkMock.Object, _mapperMock.Object, _transactionProcessorMock.Object, _transactionRepoMock.Object);
            var result = await transactionService.CreateTransactionAsync(createTransactionDto, cancellationToken);

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.ErrorMessage);
            Assert.Equal(transactionId, result.TransactionDto.Id);
            Assert.Equal(expectedTransactionResp.TransactionDto.Id, result.TransactionDto.Id);
            Assert.Equal(expectedTransactionResp.TransactionDto.TransactionType, result.TransactionDto.TransactionType);
            Assert.Equal(expectedTransactionResp.TransactionDto.Amount, result.TransactionDto.Amount);
            Assert.Equal(expectedTransactionResp.TransactionDto.SenderId, result.TransactionDto.SenderId);
            Assert.Equal(expectedTransactionResp.TransactionDto.ReceiverId, result.TransactionDto.ReceiverId);
        }

        [Fact]
        public async Task ValidationErrors_ReturnsErrorResponse()
        {
            // Arrange
            var cancellationToken = CancellationToken.None;
            var createTransactionDto = new CreateTransactionReqDTO
            {
                TransactionType = "wqdqwdq",
                Amount = 100.0,
                SenderId = Guid.NewGuid(),
                ReceiverId = Guid.NewGuid()
            };

            // Act
            var transactionService = new TransactionService(_unitOfWorkMock.Object, _mapperMock.Object, _transactionProcessorMock.Object, _transactionRepoMock.Object);
            var result = await transactionService.CreateTransactionAsync(createTransactionDto, cancellationToken);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.ErrorMessage);
            Assert.Equal(400, result.ErrorMessage.StatusCode);
            Assert.Contains("Such TransactionType doesn't exist!", result.ErrorMessage.Message);
        }
    }
}
