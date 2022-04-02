using AutoMapper;
using Domain.Core.Entities;
using Domain.Core.RequestEntities;

namespace GB__U_SaveDev.Mapper
{
    public class MappingBankCardProfile:Profile
    {
        public MappingBankCardProfile()
        {
            CreateMap<BankCardRequest, BankCard>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.CardNumber, opt => opt.MapFrom(src => src.CardNumber));
        }
    }
}
