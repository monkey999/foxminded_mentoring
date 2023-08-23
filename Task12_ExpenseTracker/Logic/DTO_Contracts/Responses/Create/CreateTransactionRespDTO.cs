using Domain.Enums;
using Domain.ValueObjects;

namespace Logic.DTO_Contracts.Responses.Create
{
    public class CreateTransactionRespDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TransactionType { get; set; }
        public ErrorMessage ErrorMessage { get; set; } = null;
    }
}
