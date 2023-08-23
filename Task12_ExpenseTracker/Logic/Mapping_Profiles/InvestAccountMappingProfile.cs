using AutoMapper;
using Domain.Enums;
using Domain.Models.Accounts;
using Logic.DTO_Contracts.Requests.Create;
using Logic.DTO_Contracts.Requests.Update;
using Logic.DTO_Contracts.Responses.Create;
using Logic.DTO_Contracts.Responses.Get;
using Logic.DTO_Contracts.Responses.Update;

namespace Logic.Mapping_Profiles
{
    public class InvestAccountMappingProfile : Profile
    {
        public InvestAccountMappingProfile()
        {
            CreateMap<CreateInvestAccountReqDTO, InvestAccount>()
                .ForMember(dest => dest.CurrencyType, opt => opt.MapFrom(src => Enum.Parse(typeof(CurrencyType), src.CurrencyType)));

            CreateMap<InvestAccount, GetInvestAccountRespDto.InvestAccountRespDto>()
                .ForMember(dest => dest.CurrencyType, opt => opt.MapFrom(src => src.CurrencyType.ToString()));

            CreateMap<InvestAccount, CreateInvestAccountRespDTO>()
              .ForMember(dest => dest.CurrencyType, opt => opt.MapFrom(src => src.CurrencyType.ToString()));

            CreateMap<InvestAccount, UpdateInvestAccountRespDTO>()
                .ForMember(dest => dest.CurrencyType, opt => opt.MapFrom(src => src.CurrencyType.ToString()));

            CreateMap<UpdateInvestAccountReqDTO, InvestAccount>()
                .ForMember(dest => dest.CurrencyType, opt => opt.MapFrom(src => Enum.Parse(typeof(CurrencyType), src.CurrencyType)));
        }
    }
}
