using Domain.Enums;
using Domain.Models.BaseEntities;

namespace Domain.Models.Accounts
{
    public class InvestAccount : AccountBase
    {
        public InvestAccount(string name, string description, double balance, CurrencyType currencyType) : base(name, description, balance, currencyType)
        {
        }
    }
}
