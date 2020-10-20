using AutoMapper;
using Simple.Game.Contract.Play;
using Simple.Game.Domain.Entities;

namespace Simple.Game.Services.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PersonEntity, PlayResponse>().ForMember(d => d.Value, opt => opt.MapFrom(s => s.Mass.ToString()));
            CreateMap<StarsShipEntity, PlayResponse>().ForMember(d => d.Value, opt => opt.MapFrom(s => s.Crew.ToString()));
        }
    }
}
