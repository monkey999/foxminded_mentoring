using Domain.Enums;
using Domain.ValueObjects;

namespace Logic.DTO_Contracts.Responses.Get
{
    public class GetDebitAccountRespDto
    {
        public IEnumerable<DebitAccountRespDto> DebitAccountsRespDto { get; set; }
        public ErrorMessage ErrorMessage { get; set; } = null;

        public class DebitAccountRespDto
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public double Balance { get; set; }
            public string CurrencyType { get; set; }
        }
    }
}
