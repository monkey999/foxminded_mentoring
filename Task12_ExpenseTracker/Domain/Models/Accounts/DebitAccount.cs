using Domain.Enums;
using Domain.Models.BaseEntities;

namespace Domain.Models.Accounts
{
    public class DebitAccount : AccountBase
    {
        public DebitAccount(string name, string description, double balance, CurrencyType currencyType) : base(name, description, balance, currencyType)
        {
        }
    }
}
