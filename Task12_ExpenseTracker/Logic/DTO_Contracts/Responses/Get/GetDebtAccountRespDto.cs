using Domain.Enums;
using Domain.ValueObjects;

namespace Logic.DTO_Contracts.Responses.Get
{
    public class GetDebtAccountRespDto
    {
        public IEnumerable<DebtAccountRespDto> DebtAccountsRespDto { get; set; }
        public ErrorMessage ErrorMessage { get; set; } = null;

        public class DebtAccountRespDto
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public double Balance { get; set; }
            public string CurrencyType { get; set; }
        }
    }
}
