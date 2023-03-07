using BackEnd.Api.Api.Abstractions;
using BackEnd.Api.Api.Features.VoitureFeature.AutoMapperProfiles;
using BackEnd.Api.Api.Features.VoitureFeature.Commands;
using MediatR;

namespace BackEnd.Api.Api.Features.VoitureFeature.Endpoints
{
    public class WriteVoituresEndpoint : IEndpoints
    {
        private readonly IMediator _mediator;
    public WriteVoituresEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }
        public IEndpointRouteBuilder RegisterRoutes(IEndpointRouteBuilder endpoint) {

            endpoint.MapPost("/Voiture",async (GetVoitureDTO voitureDto)=>
            {
                await CreateVoiture(voitureDto);
            }
            );
            endpoint.MapPut("/Voiture/{Id}", async (int id, GetVoitureDTO updatevoitureDTO) =>

            {
                await UpdateVoiture(id,updatevoitureDTO) ;

            });
            endpoint.MapDelete("backend/Voiture/{Id}", async (int id) =>
            await DeleteVoiture(id)); return endpoint; 
        }

        private async Task<IResult> CreateVoiture(GetVoitureDTO voitureDTO)
        {
            var result = await _mediator.Send(new CreateVoitureCommand());
            return Results.Ok(result);
        }

        private async Task<IResult> UpdateVoiture(int Id,GetVoitureDTO voitureDTO)
        {
            var command = new UpdateVoitureCommand
            {
                Id = Id,
                Matricule = voitureDTO.Matricule,
                Modele = voitureDTO.Modele,
                Carburant = voitureDTO.Carburant
            };
            await _mediator.Send(command);
            return Results.NoContent();

           }
        private async Task<IResult> DeleteVoiture(int id)
        {
            await _mediator.Send(new RemoveVoitureCommand { RmVId = id });
            return Results.NoContent();
        }
       
        }
    }
   

