using AutoMapper;
using Domain.Enums;
using Domain.Models;
using Logic.DTO_Contracts.Requests.Create;
using Logic.DTO_Contracts.Requests.Update;
using Logic.DTO_Contracts.Responses.Create;
using Logic.DTO_Contracts.Responses.Get;
using Logic.DTO_Contracts.Responses.Update;

namespace Logic.Mapping_Profiles
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<CreateCategoryReqDTO, Category>()
                .ForMember(dest => dest.CategoryType, opt => opt.MapFrom(src => Enum.Parse(typeof(CategoryType), src.CategoryType)));

            CreateMap<CategoryRespDto, Category>()
             .ForMember(dest => dest.CategoryType, opt => opt.MapFrom(src => Enum.Parse(typeof(CategoryType), src.CategoryType)));

            CreateMap<Category, CategoryRespDto>()
                .ForMember(dest => dest.CategoryType, opt => opt.MapFrom(src => src.CategoryType.ToString()));

            CreateMap<Category, CreateCategoryRespDTO>()
              .ForMember(dest => dest.CategoryType, opt => opt.MapFrom(src => src.CategoryType.ToString()));

            CreateMap<Category, UpdateCategoryRespDTO>()
                .ForMember(dest => dest.CategoryType, opt => opt.MapFrom(src => src.CategoryType.ToString()));

            CreateMap<Category, UpdateCategoryPatchRespDto>()
             .ForMember(dest => dest.CategoryType, opt => opt.MapFrom(src => src.CategoryType.ToString()));

            CreateMap<CategoryRespDto, UpdateCategoryPatchRespDto>().ReverseMap();

            CreateMap<CategoryRespDto, UpdateCategoryRespDTO>().ReverseMap();

            CreateMap<UpdateCategoryReqDTO, Category>();
        }
    }
}
