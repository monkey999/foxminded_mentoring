using Domain.ValueObjects;

namespace Logic.DTO_Contracts.Responses.Get
{
    public class GetDebitAccountRespDto
    {
        public IEnumerable<DebitAccountRespDto> DebitAccountsRespDto { get; set; }
        public ErrorMessage ErrorMessage { get; set; } = null;
    }
}
