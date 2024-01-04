using AutoMapper;
using DataAccess.Specifications.DebitAccountSpecs;
using Domain.Enums;
using Domain.Models;
using Domain.Models.Accounts;
using Domain.RepoInterfaces;
using Logic.DTO_Contracts.Requests.Update;
using Logic.DTO_Contracts.Responses.Get;
using Logic.DTO_Contracts.Responses.Update;
using Logic.Services;
using Moq;
using Xunit;

namespace ExpenseTracker.Tests.DebitAccountService_Tests
{
    public class Test_UpdateDebitAccountAsync
    {
        private readonly Mock<IUnitOfWOrk> _unitOfWorkMock;
        private readonly Mock<IDebitAccountRepo> _debitAccRepo;
        private readonly Mock<IMapper> _mapperMock;

        public Test_UpdateDebitAccountAsync()
        {
            _unitOfWorkMock = new Mock<IUnitOfWOrk>();
            _debitAccRepo = new Mock<IDebitAccountRepo>();
            _mapperMock = new Mock<IMapper>();
        }

        [Fact]
        public async Task UpdateDebitAccountAsync_DebitAccountExists_ReturnsUpdatedDebitAccount()
        {
            // Arrange
            var debitAccountId = Guid.NewGuid();
            var cancellationToken = CancellationToken.None;

            var updateReqDebitAccDto = new UpdateDebitAccountReqDTO
            {
                Id = debitAccountId,
                Name = "UpdateTestDebitAcc1",
                Balance = 555
            };
            var updateDebitAccRespDto = new UpdateDebitAccountRespDTO 
            { 
                Id = debitAccountId,
                Name = "UpdateTestDebitAcc1",
                Balance = 555
            };
            var debitAcc = new DebitAccount {
                Id = debitAccountId,
                Name = "TestDebitAcc1",
                Balance = 123
            };

            var mappedDebitAccToUpdateDto = new DebitAccount
            {
                Id = debitAccountId,
                Name = updateReqDebitAccDto.Name,
                Balance = updateReqDebitAccDto.Balance
            };

            _debitAccRepo
                .Setup(x => x.FindByConditionAsync(cancellationToken, It.IsAny<DebitAccountGetByIdAsNoTrackingSpecification>()))
                .ReturnsAsync(new List<DebitAccount> { debitAcc });

            _debitAccRepo
               .Setup(x => x.FindByConditionAsync(cancellationToken, It.IsAny<DebitAccountGetByIdSpecification>()))
               .ReturnsAsync(new List<DebitAccount> { debitAcc });

            _mapperMock
                .Setup(x => x.Map(updateReqDebitAccDto, debitAcc))
                .Returns(mappedDebitAccToUpdateDto);

            _debitAccRepo
                .Setup(x => x.Update(It.IsAny<DebitAccount>()));

            _unitOfWorkMock
                .Setup(x => x.SaveChangesAsyncWithResult(cancellationToken))
                .ReturnsAsync(1);

            _mapperMock.Setup(x => x.Map<UpdateDebitAccountRespDTO>(debitAcc))
                .Returns(updateDebitAccRespDto);

            // Act
            var debitAccService = new DebitAccountService(_unitOfWorkMock.Object, _mapperMock.Object, _debitAccRepo.Object);
            var result = await debitAccService.UpdateDebitAccountAsync(updateReqDebitAccDto, cancellationToken);

            // Assert
            _unitOfWorkMock.Verify(x => x.SaveChangesAsyncWithResult(cancellationToken), Times.Once);

            Assert.NotNull(result);
            Assert.Null(result.ErrorMessage);

            Assert.Equal(debitAcc.Id, result.Id);
            Assert.Equal(mappedDebitAccToUpdateDto.Name, result.Name);
            Assert.Equal(mappedDebitAccToUpdateDto.Balance, result.Balance);
        }

        [Fact]
        public async Task UpdateDebitAccountAsync_DebitAccountNotFound_ReturnsNotFoundResponse()
        {
            // Arrange
            var debitAccountId = Guid.NewGuid();
            var debitAccountDto = new UpdateDebitAccountReqDTO { Id = debitAccountId };
            var cancellationToken = CancellationToken.None;

            _debitAccRepo
            .Setup(x => x.FindByConditionAsync(cancellationToken, It.IsAny<DebitAccountGetByIdSpecification>()))
            .ReturnsAsync((List<DebitAccount>)null);

            _debitAccRepo
              .Setup(x => x.FindByConditionAsync(cancellationToken, It.IsAny<DebitAccountGetByIdAsNoTrackingSpecification>()))
              .ReturnsAsync((List<DebitAccount>)null);

            _debitAccRepo
                .Setup(x => x.Update(It.IsAny<DebitAccount>()));

            // Act
            var debitAccService = new DebitAccountService(_unitOfWorkMock.Object, _mapperMock.Object, _debitAccRepo.Object);
            var result = await debitAccService.UpdateDebitAccountAsync(debitAccountDto, cancellationToken);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(404, result.ErrorMessage.StatusCode);
            Assert.Equal("Debit account not found.", result.ErrorMessage.Message);
        }

        [Fact]
        public async Task UpdateDebitAccountAsync_UpdateFails_ReturnsBadRequestResponse()
        {
            // Arrange
            var debitAccountId = Guid.NewGuid();
            var debitAccountDto = new UpdateDebitAccountReqDTO { Id = debitAccountId };
            var debitAcc = new DebitAccount { Id = debitAccountId, Name = "UpdateTestCategory" };
            var cancellationToken = CancellationToken.None;

            _debitAccRepo
                .Setup(x => x.FindByConditionAsync(cancellationToken, It.IsAny<DebitAccountGetByIdSpecification>()))
                .ReturnsAsync(new List<DebitAccount>());

            _debitAccRepo
              .Setup(x => x.FindByConditionAsync(cancellationToken, It.IsAny<DebitAccountGetByIdAsNoTrackingSpecification>()))
              .ReturnsAsync(new List<DebitAccount>() { debitAcc });

            _unitOfWorkMock
                .Setup(x => x.SaveChangesAsyncWithResult(cancellationToken))
                .ReturnsAsync(0);

            _debitAccRepo
                .Setup(x => x.Update(It.IsAny<DebitAccount>()));

            // Act
            var debitAccService = new DebitAccountService(_unitOfWorkMock.Object, _mapperMock.Object, _debitAccRepo.Object);
            var result = await debitAccService.UpdateDebitAccountAsync(debitAccountDto, cancellationToken);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.ErrorMessage.StatusCode);
            Assert.Equal("Error occurred while updating debit account!", result.ErrorMessage.Message);
        }
    }
}
