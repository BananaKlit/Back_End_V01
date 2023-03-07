using BackEnd.Api.Models;
using MediatR;

namespace BackEnd.Api.Api.Features.VoitureFeature.Commands
{
    public class RemoveVoitureCommand : IRequest{
        public int RmVId { get; set; }


    }
}
