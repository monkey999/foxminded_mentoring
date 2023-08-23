using Domain.Enums;

namespace Logic.DTO_Contracts.Requests.Create
{
    public class CreateCreditAccountReqDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Balance { get; set; }
        public string CurrencyType { get; set; }
    }
}
