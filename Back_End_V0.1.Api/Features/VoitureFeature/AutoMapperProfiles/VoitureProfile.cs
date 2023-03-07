using AutoMapper;
using BackEnd.Api.Models;

namespace BackEnd.Api.Api.Features.VoitureFeature.AutoMapperProfiles
{
    public class VoitureProfile : Profile
    {
        public VoitureProfile()
        {
            CreateMap<GetVoitureDTO, Voiture>().ReverseMap();
            CreateMap<Voiture, GetVoitureDTO>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id_Voiture));
        }
    }
}
