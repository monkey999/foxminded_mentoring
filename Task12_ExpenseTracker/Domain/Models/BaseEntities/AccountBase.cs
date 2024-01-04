using Domain.Enums;

namespace Domain.Models.BaseEntities
{
    public class AccountBase : TransactionParticipant
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Balance { get; set; } = 0;
        public CurrencyType CurrencyType { get; set; }

        public AccountBase(string name, string description, double balance, CurrencyType currencyType)
        {
            Name = name;
            Description = description;
            Balance = balance;
            CurrencyType = currencyType;
        }

        public AccountBase()
        {
        }
    }
}
