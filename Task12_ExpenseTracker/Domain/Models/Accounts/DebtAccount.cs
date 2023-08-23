using Domain.Enums;
using Domain.Models.BaseEntities;

namespace Domain.Models.Accounts
{
    public class DebtAccount : AccountBase
    {
        public DebtAccount(string name, string description, double balance, CurrencyType currencyType, DebtAccountType debtAccountType) : base(name, description, balance, currencyType)
        {
            DebtAccountType = debtAccountType;
        }

        public DebtAccountType DebtAccountType { get; set; }

        // feature TODO : if liabilities are completed => close delete or similar action to account. Mark it as completed somehow.
    }
}
