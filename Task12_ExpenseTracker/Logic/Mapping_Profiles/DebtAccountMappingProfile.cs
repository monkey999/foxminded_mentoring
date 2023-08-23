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
    public class DebtAccountMappingProfile : Profile
    {
        public DebtAccountMappingProfile()
        {
            CreateMap<CreateDebtAccountReqDTO, DebtAccount>()
                .ForMember(dest => dest.CurrencyType, opt => opt.MapFrom(src => Enum.Parse(typeof(CurrencyType), src.CurrencyType)));

            CreateMap<DebtAccount, GetDebtAccountRespDto.DebtAccountRespDto>()
                .ForMember(dest => dest.CurrencyType, opt => opt.MapFrom(src => src.CurrencyType.ToString()));

            CreateMap<DebtAccount, CreateDebtAccountRespDTO>()
              .ForMember(dest => dest.CurrencyType, opt => opt.MapFrom(src => src.CurrencyType.ToString()));

            CreateMap<DebtAccount, UpdateDebtAccountRespDTO>()
                .ForMember(dest => dest.CurrencyType, opt => opt.MapFrom(src => src.CurrencyType.ToString()));

            CreateMap<UpdateDebtAccountReqDTO, DebtAccount>()
                .ForMember(dest => dest.CurrencyType, opt => opt.MapFrom(src => Enum.Parse(typeof(CurrencyType), src.CurrencyType)));
        }
    }
}
