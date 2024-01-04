using Domain.ValueObjects;

namespace Logic.DTO_Contracts.Responses.Delete
{
    public class DeleteTransactionRespDTO
    {
        public bool Deleted { get; set; }
        public ErrorMessage Error { get; set; }
    }
}
