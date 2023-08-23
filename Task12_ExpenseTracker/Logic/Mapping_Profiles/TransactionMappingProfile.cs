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
    public class TransactionMappingProfile : Profile
    {
        public TransactionMappingProfile()
        {
            CreateMap<CreateTransactionReqDTO, Transaction>()
                .ForMember(dest => dest.TransactionType, opt => opt.MapFrom(src => Enum.Parse(typeof(TransactionType), src.TransactionType)));

            CreateMap<Transaction, GetTransactionRespDto.TransactionRespDto>()
                .ForMember(dest => dest.TransactionType, opt => opt.MapFrom(src => src.TransactionType.ToString()));

            CreateMap<Transaction, CreateTransactionRespDTO>()
                .ForMember(dest => dest.TransactionType, opt => opt.MapFrom(src => src.TransactionType.ToString()));

            CreateMap<Transaction, UpdateTransactionRespDTO>()
                .ForMember(dest => dest.TransactionType, opt => opt.MapFrom(src => src.TransactionType.ToString()));

            CreateMap<UpdateTransactionReqDTO, Transaction>()
                .ForMember(dest => dest.TransactionType, opt => opt.MapFrom(src => Enum.Parse(typeof(TransactionType), src.TransactionType)));
        }
    }
}
