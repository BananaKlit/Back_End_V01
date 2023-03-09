using AutoMapper;
using BackEnd.Api.Api.Features.VoitureFeature.Commands;
using BackEnd.Api.DAL.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Api.Api.Features.VoitureFeature.Handlers
{
    public class UpdateVoitureHandler : IRequestHandler<UpdateVoitureCommand>
    {
        private readonly MyContext _myContext;
       
        public UpdateVoitureHandler(MyContext myContext)
        {
            _myContext = myContext;

        }
            public async Task<Unit> Handle(UpdateVoitureCommand request, CancellationToken cancellationToken)
            {
                var voiture = await _myContext.Voitures!.FirstOrDefaultAsync(a => a.Id_Voiture == request.Id);
                if (voiture != null){
                    voiture.UpdateVoiture(request.Matricule!, request.Modele!, request.Carburant!);
                await _myContext.SaveChangesAsync();
                }return new Unit();
            }
    }
}
 