using Domain.Models.Accounts;

namespace Domain.RepoInterfaces
{
    public interface IDebitAccountRepo : IGenericRepo<DebitAccount, Guid>
    {
    }
}
