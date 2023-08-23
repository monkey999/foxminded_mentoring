using AutoMapper;
using C_Logic.DTO_Contracts.Requests;
using C_Logic.DTO_Contracts.Requests.Update;
using C_Logic.DTO_Contracts.Responses;
using Domain;

namespace C_Logic.Mapping_Profiles
{
    public class GroupMappingProfile : Profile
    {
        public GroupMappingProfile()
        {
            CreateMap<Group, GroupGetDto>();
            CreateMap<GroupGetDto, Group>();

            CreateMap<GroupCreateDto, Group>();
            CreateMap<Group, GroupCreateDto>();

            CreateMap<GroupGetDto, GroupCreateDto>();
            CreateMap<GroupCreateDto, GroupGetDto>();

            CreateMap<GroupUpdateDto, Group>();
            CreateMap<Group, GroupUpdateDto>();

            CreateMap<GroupGetDto, GroupUpdateDto>();
            CreateMap<GroupUpdateDto, GroupGetDto>();
        }
    }
}
