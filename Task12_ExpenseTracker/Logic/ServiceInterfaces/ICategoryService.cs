using Domain.Models;
using Logic.DTO_Contracts.Requests.Create;
using Logic.DTO_Contracts.Requests.Update;
using Logic.DTO_Contracts.Responses.Create;
using Logic.DTO_Contracts.Responses.Delete;
using Logic.DTO_Contracts.Responses.Get;
using Logic.DTO_Contracts.Responses.Update;
using Microsoft.AspNetCore.JsonPatch;

namespace Logic.ServiceInterfaces
{
    public interface ICategoryService
    {
        Task<CreateCategoryRespDTO> CreateCategoryAsync(CreateCategoryReqDTO categoryDto, CancellationToken cancellationToken);
        Task<DeleteCategoryRespDTO> DeleteCategoryAsync(Guid categoryId, CancellationToken cancellationToken);
        Task<GetCategoryRespDto> GetAllCategoriesAsync(CancellationToken cancellationToken);
        Task<GetCategoryRespDto> GetCategoryByIdAsync(Guid categoryId, CancellationToken cancellationToken);
        Task<UpdateCategoryRespDTO> UpdateCategoryAsync(UpdateCategoryReqDTO categoryDto, CancellationToken cancellationToken);
        Task<UpdateCategoryPatchRespDto> UpdateCategoryPatchAsync(Guid id, JsonPatchDocument<Category> patchDocument, CancellationToken cancellationToken);
    }
}
