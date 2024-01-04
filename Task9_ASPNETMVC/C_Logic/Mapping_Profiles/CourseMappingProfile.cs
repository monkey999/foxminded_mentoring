using AutoMapper;
using C_Logic.DTO_Contracts.Requests.Update;
using C_Logic.DTO_Contracts.Responses;
using Domain;

namespace C_Logic.Mapping_Profiles
{
    public class CourseMappingProfile : Profile
    {
        public CourseMappingProfile()
        {
            CreateMap<Course, CourseGetDto>();
            CreateMap<CourseGetDto, Course>();

            CreateMap<Course, CourseUpdateDTO>();
            CreateMap<CourseUpdateDTO, Course>();
        }
    }
}
