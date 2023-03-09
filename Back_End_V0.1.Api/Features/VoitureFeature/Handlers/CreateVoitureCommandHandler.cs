using AutoMapper;
using BackEnd.Api.Api.Features.VoitureFeature.Commands;
using BackEnd.Api.Api.Features.VoitureFeature.VoitureRepository;
using BackEnd.Api.DAL.DataAccess;
using BackEnd.Api.Models;
using MediatR;

namespace BackEnd.Api.Api.Features.VoitureFeature.Handlers
{
    public class CreateVoitureCommandHandler : IRequestHandler<CreateVoitureCommand, Voiture>
    {
        
        private readonly IMapper mapper;
        private IVoitureRepo voitureRepo;
        public CreateVoitureCommandHandler(IVoitureRepo vrepo, IMapper mapper)
        {
            this.voitureRepo = vrepo;
            this.mapper = mapper;
        }


        public async Task<Voiture> Handle(CreateVoitureCommand request, CancellationToken cancellationToken)
        {
            
            var toAdd = mapper.Map<Voiture>(request.Voiture);
            voitureRepo.AddVoiture(toAdd);
            await voitureRepo.Save();
            return toAdd;
        }
    }
}
