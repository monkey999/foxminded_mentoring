using Domain.Enums;
using Domain.Models.BaseEntities;

namespace Domain.Models.Accounts
{
    public class DebitAccount : AccountBase
    {
        public DebitAccount()
        {
        }

        public DebitAccount(string name, string description, double balance, CurrencyType currencyType, double creditLimit, double startCreditLimit) : base(name, description, balance, currencyType)
        {
            CurrentCreditLimit = creditLimit;
            StartCreditLimit = startCreditLimit;
        }

        public double CurrentCreditLimit { get; set; } = 0;
        public double StartCreditLimit { get; set;} = 0;
    }
}
