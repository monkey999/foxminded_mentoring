using Domain.RepoInterfaces;
using Microsoft.EntityFrameworkCore;


namespace DataAccess.Repos
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        private ICategoryRepo _categoryRepo;
        private ICreditAccountRepo _creditAccountRepo;
        private IDebitAccountRepo _debitAccountRepo;
        private IDebtAccountRepo _debtAccountRepo;
        private IInvestAccountRepo _investAccountRepo;
        private ITransactionRepo _transactionRepo;

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ICategoryRepo Categories => _categoryRepo ??= new CategoryRepo(_dbContext);
        public ICreditAccountRepo CreditAccounts => _creditAccountRepo ??= new CreditAccountRepo(_dbContext);
        public IDebitAccountRepo DebitAccounts => _debitAccountRepo ??= new DebitAccountRepo(_dbContext);
        public IDebtAccountRepo DebtAccounts => _debtAccountRepo ??= new DebtAccountRepo(_dbContext);
        public IInvestAccountRepo InvestAccounts => _investAccountRepo ??= new InvestAccountRepo(_dbContext);
        public ITransactionRepo Transactions => _transactionRepo ??= new TransactionRepo(_dbContext);

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<int> SaveChangesAsyncWithResult()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
