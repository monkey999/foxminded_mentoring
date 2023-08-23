using Domain.Enums;

namespace Logic.DTO_Contracts.Requests.Update
{
    public class UpdateDebitAccountReqDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Balance { get; set; }
        public string CurrencyType { get; set; }
    }
}
