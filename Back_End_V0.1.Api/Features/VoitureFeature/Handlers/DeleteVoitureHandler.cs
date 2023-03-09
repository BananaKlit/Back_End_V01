
using BackEnd.Api.Api.Features.VoitureFeature.Commands;
using BackEnd.Api.Api.Features.VoitureFeature.VoitureRepository;
using BackEnd.Api.DAL.DataAccess;
using MediatR;

namespace BackEnd.Api.Api.Features.VoitureFeature.Handlers
{
    public class DeleteVoitureHandler : IRequestHandler<RemoveVoitureCommand>
    {
       
        private IVoitureRepo _voitureRepo;
        public DeleteVoitureHandler(IVoitureRepo vrepo)
        {
            
       this._voitureRepo = vrepo;
        }

        public async Task<Unit> Handle(RemoveVoitureCommand request, CancellationToken cancellationToken)
        {
            var voiture = _voitureRepo.GetVoitureById(request.RmVId);
            if (!(voiture == null))
                _voitureRepo.DeleteVoiture(voiture.Id_Voiture);
            await _voitureRepo.Save();
            return new Unit();
        }
    }
}
