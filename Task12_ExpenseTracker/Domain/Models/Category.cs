using Domain.Enums;
using Domain.Models.BaseEntities;

namespace Domain.Models
{
    public class Category : TransactionParticipant
    {
        public string CategoryName { get; set; }
        public CategoryType CategoryType { get; set; }
    }
}
