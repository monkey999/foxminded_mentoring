using Domain.Enums;
using Domain.ValueObjects;

namespace Logic.DTO_Contracts.Responses.Get
{
    public class GetCreditAccountRespDto
    {
        public IEnumerable<CreditAccountRespDto> CreditAccountsRespDto { get; set; }
        public ErrorMessage ErrorMessage { get; set; } = null;

        public class CreditAccountRespDto
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public double Balance { get; set; }
            public string CurrencyType { get; set; }
        }
    }
}
