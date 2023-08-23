using Domain.Enums;
using Domain.ValueObjects;

namespace Logic.DTO_Contracts.Responses.Get
{
    public class GetInvestAccountRespDto
    {
        public IEnumerable<InvestAccountRespDto> InvestAccountsRespDto { get; set; }
        public ErrorMessage ErrorMessage { get; set; } = null;

        public class InvestAccountRespDto
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public double Balance { get; set; }
            public string CurrencyType { get; set; }
        }
    }
}
