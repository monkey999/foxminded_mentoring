using AutoMapper;
using C_Logic.DTO_Contracts.Requests;
using C_Logic.DTO_Contracts.Requests.Update;
using C_Logic.DTO_Contracts.Responses;
using Domain;

namespace C_Logic.Mapping_Profiles
{
    public class StudentMappingProfile : Profile
    {
        public StudentMappingProfile()
        {
            CreateMap<Student, StudentGetDto>();
            CreateMap<StudentGetDto, Student>();

            CreateMap<StudentCreateDto, Student>();
            CreateMap<Student, StudentCreateDto>();

            CreateMap<StudentCreateDto, StudentGetDto>();
            CreateMap<StudentGetDto, StudentCreateDto>();

            CreateMap<Student, StudentUpdateDto>();
            CreateMap<StudentUpdateDto, Student>();

            CreateMap<StudentGetDto, StudentUpdateDto>();
            CreateMap<StudentUpdateDto, StudentGetDto>();

        }
    }
}
