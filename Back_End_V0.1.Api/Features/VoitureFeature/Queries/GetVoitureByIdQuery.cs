using BackEnd.Api.Api.Features.VoitureFeature.AutoMapperProfiles;
using MediatR;

namespace BackEnd.Api.Api.Features.VoitureFeature.Queries
{
    public class GetVoitureByIdQuery : IRequest<GetVoitureDTO>
    {
        public int Id { get; init; }
    }
}
