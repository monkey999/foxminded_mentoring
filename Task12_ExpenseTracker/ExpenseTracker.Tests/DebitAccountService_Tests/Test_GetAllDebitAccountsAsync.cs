using AutoMapper;
using DataAccess.Specifications.DebitAccountSpecs;
using Domain.Enums;
using Domain.Models.Accounts;
using Domain.RepoInterfaces;
using Logic.DTO_Contracts.Responses.Get;
using Logic.Services;
using Moq;
using Xunit;

namespace ExpenseTracker.Tests.DebitAccountService_Tests
{
    public class Test_GetAllDebitAccountsAsync
    {
        private readonly Mock<IUnitOfWOrk> _unitOfWorkMock;
        private readonly Mock<IDebitAccountRepo> _debitAccRepo;
        private readonly Mock<IMapper> _mapperMock;

        public Test_GetAllDebitAccountsAsync()
        {
            _unitOfWorkMock = new Mock<IUnitOfWOrk>();
            _debitAccRepo = new Mock<IDebitAccountRepo>();
            _mapperMock = new Mock<IMapper>();
        }

        [Fact]
        public async Task GetAllDebitAccountsAsync_WhenDebitAccountsExist_ReturnsDebitAccounts()
        {
            // Arrange
            var cancellationToken = CancellationToken.None;
            var debitAccounts = new List<DebitAccount>
            {
                new DebitAccount { Id = Guid.NewGuid(), Name = "DebitAccount1", CurrencyType = CurrencyType.USD, Balance = 123 },
                new DebitAccount { Id = Guid.NewGuid(), Name = "DebitAccount2", CurrencyType = CurrencyType.USD, Balance = 1233 }
            };
            var debitAccountRespDtos = new List<DebitAccountRespDto>
            {
                new DebitAccountRespDto { Id = Guid.NewGuid(), Name = "DebitAccount1", CurrencyType = "USD", Balance = 123 },
                new DebitAccountRespDto { Id = Guid.NewGuid(), Name = "DebitAccount2", CurrencyType = "USD", Balance = 1233 }
            };

            _debitAccRepo.Setup(repo => repo.FindByConditionAsync(cancellationToken, It.IsAny<DebitAccountGetAllSpecification>()))
                .ReturnsAsync(debitAccounts);

            _mapperMock.Setup(x => x.Map<IEnumerable<DebitAccountRespDto>>(debitAccounts)).Returns(debitAccountRespDtos);

            // Act
            var debitAccService = new DebitAccountService(_unitOfWorkMock.Object, _mapperMock.Object, _debitAccRepo.Object);
            var result = await debitAccService.GetAllDebitAccountsAsync(cancellationToken);

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.ErrorMessage);
        }

        [Fact]
        public async Task GetAllDebitAccountsAsync_WhenNoDebitAccountsExist_ReturnsErrorMessage()
        {
            // Arrange
            var cancellationToken = CancellationToken.None;

            _debitAccRepo.Setup(repo => repo.FindByConditionAsync(cancellationToken, It.IsAny<DebitAccountGetAllSpecification>()))
                .ReturnsAsync(new List<DebitAccount>());

            // Act
            var debitAccService = new DebitAccountService(_unitOfWorkMock.Object, _mapperMock.Object, _debitAccRepo.Object);
            var result = await debitAccService.GetAllDebitAccountsAsync(cancellationToken);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.ErrorMessage);
            Assert.Equal(404, result.ErrorMessage.StatusCode);
        }
    }
}
