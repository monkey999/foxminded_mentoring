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
    public class Test_GetDebitAccountByIdAsync
    {
        private readonly Mock<IUnitOfWOrk> _unitOfWorkMock;
        private readonly Mock<IDebitAccountRepo> _debitAccRepo;
        private readonly Mock<IMapper> _mapperMock;

        public Test_GetDebitAccountByIdAsync()
        {
            _unitOfWorkMock = new Mock<IUnitOfWOrk>();
            _debitAccRepo = new Mock<IDebitAccountRepo>();
            _mapperMock = new Mock<IMapper>();
        }

        [Fact]
        public async Task GetDebitAccountByIdAsync_WhenDebitAccountExists_ReturnsDebitAccount()
        {
            // Arrange
            var cancellationToken = CancellationToken.None;
            var debitAccountId = Guid.NewGuid();
            var debitAccount = new List<DebitAccount>
            {
                new DebitAccount { Id = Guid.NewGuid(), Name = "DebitAccount1", CurrencyType = CurrencyType.USD, Balance = 123 }
            };
            var debitAccountRespDtoRespDto = new List<DebitAccountRespDto>
            {
               new DebitAccountRespDto { Id = Guid.NewGuid(), Name = "DebitAccount1", CurrencyType = "USD", Balance = 123 }
            };

            _debitAccRepo.Setup(repo => repo.FindByConditionAsync(cancellationToken, It.IsAny<DebitAccountGetByIdSpecification>()))
                .ReturnsAsync(debitAccount);

            _debitAccRepo.Setup(repo => repo.FindByConditionAsync(cancellationToken, It.IsAny<DebitAccountGetByIdAsNoTrackingSpecification>()))
                .ReturnsAsync(debitAccount);

            _mapperMock.Setup(x => x.Map<IEnumerable<DebitAccountRespDto>>(debitAccount))
                .Returns(debitAccountRespDtoRespDto);
            // Act
            var debitAccService = new DebitAccountService(_unitOfWorkMock.Object, _mapperMock.Object, _debitAccRepo.Object);
            var result = await debitAccService.GetDebitAccountByIdAsync(debitAccountId, cancellationToken);

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.ErrorMessage);
        }

        [Fact]
        public async Task GetDebitAccountByIdAsync_WhenDebitAccountNotFound_ReturnsErrorMessage()
        {
            // Arrange
            var cancellationToken = CancellationToken.None;
            var debitAccountId = Guid.NewGuid();
            _debitAccRepo.Setup(repo => repo.FindByConditionAsync(cancellationToken, It.IsAny<DebitAccountGetByIdSpecification>()))
                .ReturnsAsync((IEnumerable<DebitAccount>)null);

            // Act
            var debitAccService = new DebitAccountService(_unitOfWorkMock.Object, _mapperMock.Object, _debitAccRepo.Object);
            var result = await debitAccService.GetDebitAccountByIdAsync(debitAccountId, cancellationToken);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.ErrorMessage);
            Assert.Equal(404, result.ErrorMessage.StatusCode);
        }
    }
}
