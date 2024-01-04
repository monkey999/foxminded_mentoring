using AutoMapper;
using DataAccess.Specifications.TransactionSpecs;
using Domain.Enums;
using Domain.Models;
using Domain.RepoInterfaces;
using Logic.DTO_Contracts.Responses.Update;
using Logic.ServiceInterfaces;
using Logic.Services;
using Microsoft.AspNetCore.JsonPatch;
using Moq;
using Xunit;

namespace ExpenseTracker.Tests.TransactionService_Tests
{
    public class Test_UpdateTransactionPatchAsync
    {
        private readonly Mock<IUnitOfWOrk> _unitOfWorkMock;
        private readonly Mock<ITransactionRepo> _transactionRepoMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<ITransactionProcessor> _transactionProcessorMock;

        public Test_UpdateTransactionPatchAsync()
        {
            _unitOfWorkMock = new Mock<IUnitOfWOrk>();
            _transactionRepoMock = new Mock<ITransactionRepo>();
            _mapperMock = new Mock<IMapper>();
            _transactionProcessorMock = new Mock<ITransactionProcessor>();
        }

        [Fact]
        public async Task UpdateTransactionPatchAsync_TransactionExists_ReturnsUpdatedTransaction()
        {
            var transactionId = Guid.NewGuid();
            var cancellationToken = CancellationToken.None;
            var senderId = Guid.NewGuid();
            var receiverId = Guid.NewGuid();

            var patchDocument = new JsonPatchDocument<Transaction>();

            var updateTransactionRespDto = new UpdateTransactionPatchRespDto
            {
                Id = transactionId,
                TransactionType = "Income",
                Amount = 123,
                SenderId = senderId,
                ReceiverId = receiverId
            };

            patchDocument.Replace(c => c.Amount, 123);

            var transactionToUpdate = new Transaction
            {
                Id = transactionId,
                TransactionType = TransactionType.Income,
                Amount = 100.0,
                SenderId = senderId,
                ReceiverId = receiverId
            };

            _transactionRepoMock.Setup(repo => repo.FindByConditionAsync(cancellationToken, It.IsAny<TransactionGetByIdAsNoTrackingSpecification>()))
                .ReturnsAsync(new List<Transaction> { transactionToUpdate });

            _transactionRepoMock.Setup(repo => repo.FindByConditionAsync(cancellationToken, It.IsAny<TransactionGetByIdSpecification>()))
                .ReturnsAsync(new List<Transaction> { transactionToUpdate });

            _unitOfWorkMock
                .Setup(x => x.SaveChangesAsyncWithResult(cancellationToken))
                    .ReturnsAsync(1);

            _mapperMock.Setup(x => x.Map<UpdateTransactionPatchRespDto>(transactionToUpdate)).Returns(updateTransactionRespDto);

            // Act
            var transactionService = new TransactionService(_unitOfWorkMock.Object, _mapperMock.Object, _transactionProcessorMock.Object, _transactionRepoMock.Object);
            var result = await transactionService.UpdateTransactionPatchAsync(transactionId, patchDocument, cancellationToken);

            // Assert
            _unitOfWorkMock.Verify(x => x.SaveChangesAsyncWithResult(cancellationToken), Times.Once);
            Assert.Null(result.ErrorMessage);
            Assert.NotNull(result);
            Assert.Equal(123, result.Amount);
            Assert.Equal(transactionId, result.Id);
        }

        [Fact]
        public async Task UpdateTransactionPatchAsync_TransactionNotFound_ReturnsNotFoundResponse()
        {
            // Arrange
            var transactionId = Guid.NewGuid();
            var patchDocument = new JsonPatchDocument<Transaction>();
            patchDocument.Replace(c => c.Amount, 123);

            var cancellationToken = CancellationToken.None;

            _transactionRepoMock.Setup(repo => repo.FindByConditionAsync(cancellationToken, It.IsAny<TransactionGetByIdSpecification>()))
                .ReturnsAsync(new List<Transaction>() { });

            // Act
            var transactionService = new TransactionService(_unitOfWorkMock.Object, _mapperMock.Object, _transactionProcessorMock.Object, _transactionRepoMock.Object);
            var result = await transactionService.UpdateTransactionPatchAsync(transactionId, patchDocument, cancellationToken);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(404, result.ErrorMessage.StatusCode);
            Assert.Equal("transaction not found.", result.ErrorMessage.Message);
        }

        [Fact]
        public async Task UpdateTransactionPatchAsync_UpdateFails_ReturnsBadRequestResponse()
        {
            // Arrange
            var transactionId = Guid.NewGuid();
            var senderId = Guid.NewGuid();
            var receiverId = Guid.NewGuid();
            var cancellationToken = CancellationToken.None;
            var patchDocument = new JsonPatchDocument<Transaction>();
            patchDocument.Replace(c => c.Amount, 123);

            var transactionList = new List<Transaction>
            {
                new Transaction
                {
                    Id = transactionId,
                    TransactionType = TransactionType.Income,
                    Amount = 100.0,
                    SenderId = senderId,
                    ReceiverId = receiverId
                }
            };

            _transactionRepoMock.Setup(repo => repo.FindByConditionAsync(cancellationToken, It.IsAny<TransactionGetByIdAsNoTrackingSpecification>()))
               .ReturnsAsync(transactionList);

            _transactionRepoMock.Setup(repo => repo.FindByConditionAsync(cancellationToken, It.IsAny<TransactionGetByIdSpecification>()))
               .ReturnsAsync(transactionList);

            _unitOfWorkMock
                .Setup(x => x.SaveChangesAsyncWithResult(cancellationToken))
                .ReturnsAsync(0);

            // Act
            var transactionService = new TransactionService(_unitOfWorkMock.Object, _mapperMock.Object, _transactionProcessorMock.Object, _transactionRepoMock.Object);
            var result = await transactionService.UpdateTransactionPatchAsync(transactionId, patchDocument, cancellationToken);

            // Assert
            _unitOfWorkMock.Verify(x => x.SaveChangesAsyncWithResult(cancellationToken), Times.Once);
            Assert.NotNull(result);
            Assert.Equal(400, result.ErrorMessage.StatusCode);
        }
    }
}
