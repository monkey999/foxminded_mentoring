using C_Logic.DTO_Contracts.Requests;
using C_Logic.DTO_Contracts.Requests.Update;
using C_Logic.DTO_Contracts.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace C_Logic.Service_interfaces
{
    public interface IStudentService
    {
        Task<bool> CreateAsync(StudentCreateDto student);
        Task<StudentGetDto> GetByIdAsync(int studentId);
        Task<List<StudentGetDto>> GetAllAsync();
        Task<bool> UpdateAsync(StudentUpdateDto studentUpdateDTORequest);
        Task<IEnumerable<StudentGetDto>> GetAllByGroupId(int groupId);
        Task<bool> DeleteAsync(int studentId);
    }
}
