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
    public class DebitAccountMappingProfile : Profile
    {
        public DebitAccountMappingProfile()
        {
            CreateMap<CreateDebitAccountReqDTO, DebitAccount>()
                 .ForMember(dest => dest.CurrencyType, opt => opt.MapFrom(src => Enum.Parse(typeof(CurrencyType), src.CurrencyType)));

            CreateMap<DebitAccount, DebitAccountRespDto>()
                .ForMember(dest => dest.CurrencyType, opt => opt.MapFrom(src => src.CurrencyType.ToString()));

            CreateMap<DebitAccount, CreateDebitAccountRespDTO>()
              .ForMember(dest => dest.CurrencyType, opt => opt.MapFrom(src => src.CurrencyType.ToString()));

            CreateMap<DebitAccount, UpdateDebitAccountRespDTO>()
                .ForMember(dest => dest.CurrencyType, opt => opt.MapFrom(src => src.CurrencyType.ToString()));

            CreateMap<DebitAccount, UpdateDebitAccountPatchRespDto>()
                .ForMember(dest => dest.CurrencyType, opt => opt.MapFrom(src => src.CurrencyType.ToString()));

            CreateMap<UpdateDebitAccountReqDTO, DebitAccount>();
        }
    }
}
