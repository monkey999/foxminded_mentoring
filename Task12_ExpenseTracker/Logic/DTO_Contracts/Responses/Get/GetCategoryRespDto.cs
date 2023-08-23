using Domain.Enums;
using Domain.ValueObjects;

namespace Logic.DTO_Contracts.Responses.Get
{
    public class GetCategoryRespDto
    {
        public IEnumerable<CategoryRespDto> Categories { get; set; }
        public ErrorMessage ErrorMessage { get; set; } = null;

        public class CategoryRespDto
        {
            public string CategoryName { get; set; }
            public string CategoryType { get; set; }
        }
    }
}
