using AutoMapper;
using Domain.Enums;
using Domain.Models.Accounts;
using Domain.RepoInterfaces;
using Logic.DTO_Contracts.Requests.Create;
using Logic.DTO_Contracts.Responses.Create;
using Logic.Services;
using Moq;
using Xunit;

namespace ExpenseTracker.Tests.DebitAccountService_Tests
{
    public class Test_CreateDebitAccountAsync
    {
        private readonly Mock<IUnitOfWOrk> _unitOfWorkMock;
        private readonly Mock<IDebitAccountRepo> _debitAccRepo;
        private readonly Mock<IMapper> _mapperMock;

        public Test_CreateDebitAccountAsync()
        {
            _unitOfWorkMock = new Mock<IUnitOfWOrk>();
            _debitAccRepo = new Mock<IDebitAccountRepo>();
            _mapperMock = new Mock<IMapper>();
        }

        [Fact]
        public async Task SuccessfulCreation_ReturnsDebitAccount()
        {
            // Arrange
            var cancellationToken = CancellationToken.None;
            var debitAccountDto = new CreateDebitAccountReqDTO { Name = "TestDebitAccount", CurrencyType = "USD", Balance = 123 };
            var debitAccount = new DebitAccount { Id = Guid.NewGuid(), Name = "TestDebitAccount", CurrencyType = CurrencyType.USD };

            _unitOfWorkMock.Setup(uow => uow.SaveChangesAsyncWithResult(cancellationToken)).ReturnsAsync(1);
            _debitAccRepo.Setup(repo => repo.AddAsync(It.IsAny<DebitAccount>(), cancellationToken));

            _mapperMock.Setup(mapper => mapper.Map<DebitAccount>(debitAccountDto)).Returns(debitAccount);
            _mapperMock.Setup(mapper => mapper.Map<CreateDebitAccountRespDTO>(debitAccount)).Returns(new CreateDebitAccountRespDTO { Id = debitAccount.Id });

            // Act
            var debitAccService = new DebitAccountService(_unitOfWorkMock.Object, _mapperMock.Object, _debitAccRepo.Object);
            var result = await debitAccService.CreateDebitAccountAsync(debitAccountDto, cancellationToken);

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.ErrorMessage);
            Assert.Equal(debitAccount.Id, result.Id);
        }

        [Fact]
        public async Task ValidationErrors_ReturnsErrorResponse()
        {
            // Arrange
            var cancellationToken = CancellationToken.None;
            var debitAccountDto = new CreateDebitAccountReqDTO();

            // Act
            var debitAccService = new DebitAccountService(_unitOfWorkMock.Object, _mapperMock.Object, _debitAccRepo.Object);
            var result = await debitAccService.CreateDebitAccountAsync(debitAccountDto, cancellationToken);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.ErrorMessage);
            Assert.Equal(400, result.ErrorMessage.StatusCode);
            Assert.Contains("Debit account wasn't created!", result.ErrorMessage.Message);
        }
    }
}
