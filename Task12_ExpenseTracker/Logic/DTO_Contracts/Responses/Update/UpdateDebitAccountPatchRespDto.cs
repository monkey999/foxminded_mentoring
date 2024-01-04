using Domain.ValueObjects;

namespace Logic.DTO_Contracts.Responses.Update
{
    public class UpdateDebitAccountPatchRespDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Balance { get; set; }
        public string CurrencyType { get; set; }
        public ErrorMessage ErrorMessage { get; set; } = null;
    }
}
