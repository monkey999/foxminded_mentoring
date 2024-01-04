using AutoMapper;
using DataAccess.Specifications.TransactionSpecs;
using Domain.Enums;
using Domain.Models;
using Domain.RepoInterfaces;
using Logic.DTO_Contracts.Requests.Update;
using Logic.DTO_Contracts.Responses.Get;
using Logic.DTO_Contracts.Responses.Update;
using Logic.ServiceInterfaces;
using Logic.Services;
using Moq;
using Xunit;

namespace ExpenseTracker.Tests.TransactionService_Tests
{
    public class Test_UpdateTransactionAsync
    {
        private readonly Mock<IUnitOfWOrk> _unitOfWorkMock;
        private readonly Mock<ITransactionRepo> _transactionRepoMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<ITransactionProcessor> _transactionProcessorMock;

        public Test_UpdateTransactionAsync()
        {
            _unitOfWorkMock = new Mock<IUnitOfWOrk>();
            _transactionRepoMock = new Mock<ITransactionRepo>();
            _mapperMock = new Mock<IMapper>();
            _transactionProcessorMock = new Mock<ITransactionProcessor>();
        }

        [Fact]
        public async Task UpdateTransactionAsync_TransactionExists_ReturnsUpdatedTransaction()
        {
            // Arrange
            var transactionId = Guid.NewGuid();
            var senderId = Guid.NewGuid();
            var receiverId = Guid.NewGuid();
            var cancellationToken = CancellationToken.None;

            var updateReqTransactionDto = new UpdateTransactionReqDTO
            {
                Id = transactionId,
                Amount = 111
            };
            var updateCategoryRespDto = new UpdateTransactionRespDTO
            {
                Id = transactionId,
                Amount = 111
            };
            var transaction = new Transaction
            {
                Id = transactionId,
                TransactionType = TransactionType.Income,
                Amount = 100.0,
                SenderId = senderId,
                ReceiverId = receiverId
            };

            var mappedCategoryToUpdateDto = new Transaction
            {
                Id = transactionId,
                TransactionType = TransactionType.Income,
                Amount = 111,
                SenderId = senderId,
                ReceiverId = receiverId
            };

            _transactionRepoMock
              .Setup(x => x.FindByConditionAsync(cancellationToken, It.IsAny<TransactionGetByIdAsNoTrackingSpecification>()))
              .ReturnsAsync(new List<Transaction> { transaction });

            _transactionRepoMock
               .Setup(x => x.FindByConditionAsync(cancellationToken, It.IsAny<TransactionGetByIdSpecification>()))
               .ReturnsAsync(new List<Transaction> { transaction });

            _mapperMock
                .Setup(x => x.Map(updateReqTransactionDto, transaction))
                .Returns(mappedCategoryToUpdateDto);

            _transactionRepoMock
                .Setup(x => x.Update(It.IsAny<Transaction>()));

            _unitOfWorkMock
                .Setup(x => x.SaveChangesAsyncWithResult(cancellationToken))
                .ReturnsAsync(1);

            _mapperMock.Setup(x => x.Map<UpdateTransactionRespDTO>(transaction)).Returns(updateCategoryRespDto);

            // Act
            var transactionService = new TransactionService(_unitOfWorkMock.Object, _mapperMock.Object, _transactionProcessorMock.Object, _transactionRepoMock.Object);
            var result = await transactionService.UpdateTransactionAsync(updateReqTransactionDto, cancellationToken);

            // Assert
            _unitOfWorkMock.Verify(x => x.SaveChangesAsyncWithResult(cancellationToken), Times.Once);

            Assert.NotNull(result);
            Assert.Null(result.ErrorMessage);

            Assert.Equal(transaction.Id, result.Id);
            Assert.Equal(mappedCategoryToUpdateDto.Amount, result.Amount);
        }

        [Fact]
        public async Task UpdateTransactionAsync_TransactionNotFound_ReturnsNotFoundResponse()
        {
            // Arrange
            var transactionId = Guid.NewGuid();
            var transactionDto = new UpdateTransactionReqDTO { Id = transactionId };
            var cancellationToken = CancellationToken.None;

            _transactionRepoMock
                .Setup(x => x.FindByConditionAsync(cancellationToken, It.IsAny<TransactionGetByIdSpecification>()))
                    .ReturnsAsync((List<Transaction>)null);

            _transactionRepoMock
              .Setup(x => x.FindByConditionAsync(cancellationToken, It.IsAny<TransactionGetByIdAsNoTrackingSpecification>()))
              .ReturnsAsync((List<Transaction>)null);

            _transactionRepoMock
                .Setup(x => x.Update(It.IsAny<Transaction>()));

            // Act
            var transactionService = new TransactionService(_unitOfWorkMock.Object, _mapperMock.Object, _transactionProcessorMock.Object, _transactionRepoMock.Object);
            var result = await transactionService.UpdateTransactionAsync(transactionDto, cancellationToken);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(404, result.ErrorMessage.StatusCode);
            Assert.Equal("Transaction not found.", result.ErrorMessage.Message);
        }

        [Fact]
        public async Task UpdateTransactionAsync_UpdateFails_ReturnsBadRequestResponse()
        {
            // Arrange
            var transactionId = Guid.NewGuid();
            var transactionDto = new UpdateTransactionReqDTO { Id = transactionId };
            var transaction = new Transaction { Id = transactionId, Amount = 100 };
            var cancellationToken = CancellationToken.None;

            _transactionRepoMock
                .Setup(x => x.FindByConditionAsync(cancellationToken, It.IsAny<TransactionGetByIdSpecification>()))
                .ReturnsAsync(new List<Transaction>());

            _transactionRepoMock
              .Setup(x => x.FindByConditionAsync(cancellationToken, It.IsAny<TransactionGetByIdAsNoTrackingSpecification>()))
              .ReturnsAsync(new List<Transaction>() { transaction });

            _unitOfWorkMock
                .Setup(x => x.SaveChangesAsyncWithResult(cancellationToken))
                .ReturnsAsync(0);

            _transactionRepoMock
                .Setup(x => x.Update(It.IsAny<Transaction>()));

            // Act
            var transactionService = new TransactionService(_unitOfWorkMock.Object, _mapperMock.Object, _transactionProcessorMock.Object, _transactionRepoMock.Object);
            var result = await transactionService.UpdateTransactionAsync(transactionDto, cancellationToken);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.ErrorMessage.StatusCode);
            Assert.Equal("Error occurred while updating transaction!", result.ErrorMessage.Message);
        }
    }
}
