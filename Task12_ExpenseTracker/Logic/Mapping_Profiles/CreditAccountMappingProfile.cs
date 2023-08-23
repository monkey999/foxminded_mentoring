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
    public class CreditAccountMappingProfile : Profile
    {
        public CreditAccountMappingProfile()
        {
            CreateMap<CreateCreditAccountReqDTO, CreditAccount>()
                .ForMember(dest => dest.CurrencyType, opt => opt.MapFrom(src => Enum.Parse(typeof(CurrencyType), src.CurrencyType)));

            CreateMap<CreditAccount, GetCreditAccountRespDto.CreditAccountRespDto>()
                .ForMember(dest => dest.CurrencyType, opt => opt.MapFrom(src => src.CurrencyType.ToString()));

            CreateMap<CreditAccount, CreateCreditAccountRespDTO>()
              .ForMember(dest => dest.CurrencyType, opt => opt.MapFrom(src => src.CurrencyType.ToString()));

            CreateMap<CreditAccount, UpdateCreditAccountRespDTO>()
                .ForMember(dest => dest.CurrencyType, opt => opt.MapFrom(src => src.CurrencyType.ToString()));

            CreateMap<UpdateCreditAccountReqDTO, CreditAccount>()
                .ForMember(dest => dest.CurrencyType, opt => opt.MapFrom(src => Enum.Parse(typeof(CurrencyType), src.CurrencyType)));
        }
    }
}
