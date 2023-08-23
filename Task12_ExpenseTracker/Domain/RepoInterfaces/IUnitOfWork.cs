namespace Domain.RepoInterfaces
{
    public interface IUnitOfWork 
    {
        ICategoryRepo Categories { get; }
        ICreditAccountRepo CreditAccounts { get; }
        IDebitAccountRepo DebitAccounts { get; }
        IDebtAccountRepo DebtAccounts { get; }
        IInvestAccountRepo InvestAccounts { get; }
        ITransactionRepo Transactions { get; }

        Task SaveAsync();
        void Save();
        Task<int> SaveChangesAsyncWithResult();
    }
}
