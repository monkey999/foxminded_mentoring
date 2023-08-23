using C_Logic.DTO_Contracts.Requests;
using C_Logic.DTO_Contracts.Requests.Update;
using C_Logic.DTO_Contracts.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace C_Logic.Service_interfaces
{
    public interface ICourseService
    {
        Task<bool> CreateAsync(CourseCreateDto courseDTOrequest);
        Task<CourseGetDto> GetByIdAsync(int courseId);
        Task<List<CourseGetDto>> GetAllAsync();
        Task<bool> UpdateAsync(CourseUpdateDTO courseUpdateDTORequest);
        Task<bool> DeleteAsync(int courseId);
    }
}
