using BackEnd.Api.Api.Features.VoitureFeature.AutoMapperProfiles;
using BackEnd.Api.Models;
using MediatR;

namespace BackEnd.Api.Api.Features.VoitureFeature.Queries
{
    public class GetAllVoituresQuery : IRequest<List<GetVoitureDTO>>
    {
    }
}
