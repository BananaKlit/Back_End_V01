using BackEnd.Api.Api.Features.VoitureFeature.AutoMapperProfiles;
using BackEnd.Api.Models;
using MediatR;

namespace BackEnd.Api.Api.Features.VoitureFeature.Commands
{
    public class CreateVoitureCommand : IRequest<Voiture>
    {
        public GetVoitureDTO? Voiture { get; set; }
    }
}
