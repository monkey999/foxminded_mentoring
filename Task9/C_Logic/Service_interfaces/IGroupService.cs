using C_Logic.DTO_Contracts.Requests;
using C_Logic.DTO_Contracts.Requests.Update;
using C_Logic.DTO_Contracts.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace C_Logic.Service_interfaces
{
    public interface IGroupService
    {
        Task<bool> CreateAsync(GroupCreateDto group);
        Task<GroupGetDto> GetByIdAsync(int groupId);
        Task<List<GroupGetDto>> GetAllAsync();
        Task<bool> UpdateAsync(GroupUpdateDto groupUpdateDTORequest);
        Task<IEnumerable<GroupGetDto>> GetAllByCourseId(int courseId);
        Task<bool> DeleteAsync(int groupId);
    }
}
