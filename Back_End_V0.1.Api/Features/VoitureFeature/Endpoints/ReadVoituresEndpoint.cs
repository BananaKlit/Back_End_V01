using AutoMapper;
using BackEnd.Api.Api.Abstractions;
using BackEnd.Api.Api.Features.VoitureFeature.Queries;
using BackEnd.Api.DAL.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Api.Api.Features.VoitureFeature.Endpoints
{
    public class ReadVoituresEndpoint : IEndpoints 
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
      public ReadVoituresEndpoint(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public IEndpointRouteBuilder RegisterRoutes (IEndpointRouteBuilder endpoints)
        {

            endpoints.MapGet("/Voitures", async ()
                =>
            {
                return await GetAllVoitures();

            });
            endpoints.MapGet("/Voiture/{id}", async (int id) =>
            {
                return await GetVoitureById(id);
            });
            return endpoints;
        }
          private async Task<IResult> GetAllVoitures()
        {
            var result = await _mediator.Send(new GetAllVoituresQuery());
            return Results.Ok(result);
        }
        private async Task<IResult> GetVoitureById(int id)
        {
            var result =await _mediator.Send(new GetVoitureByIdQuery() { Id=id});
            return Results.Ok(result);
        }
    }
}
