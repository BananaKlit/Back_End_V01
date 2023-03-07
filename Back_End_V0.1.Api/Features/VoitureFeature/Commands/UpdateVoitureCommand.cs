using MediatR;

namespace BackEnd.Api.Api.Features.VoitureFeature.Commands
{
    public class UpdateVoitureCommand :IRequest
    {
        public int Id { get; init; }
        public string? Matricule { get; init; }   
        public string? Modele { get; init; }

        public string? Carburant { get; init; }

    }
}
