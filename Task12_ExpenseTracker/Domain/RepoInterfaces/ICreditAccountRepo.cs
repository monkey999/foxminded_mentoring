using Domain.Models.Accounts;

namespace Domain.RepoInterfaces
{
    public interface ICreditAccountRepo : IGenericRepo<CreditAccount, Guid>
    {
    }
}
