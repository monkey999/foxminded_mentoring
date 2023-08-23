using Logic.DTO_Contracts.Requests.Create;
using Logic.DTO_Contracts.Requests.Update;
using Logic.DTO_Contracts.Responses.Create;
using Logic.DTO_Contracts.Responses.Get;
using Logic.DTO_Contracts.Responses.Update;

namespace Logic.ServiceInterfaces
{
    public interface ICategoryService
    {
        Task<bool> CreateCategoryAsync(CreateCategoryReqDTO categoryDto);
        Task<GetCategoryRespDto> GetCategoryByIdAsync(Guid categoryId);
        Task<GetCategoryRespDto> GetAllCategoriesAsync();
        Task<UpdateCategoryRespDTO> UpdateCategoryAsync(UpdateCategoryReqDTO category);
        Task<bool> DeleteCategoryAsync(Guid categoryId);
        Task<CreateCategoryRespDTO> CreateCategoryWithResultAsync(CreateCategoryReqDTO categoryDto);
    }
}
