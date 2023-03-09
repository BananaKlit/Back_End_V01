using AutoMapper;
using BackEnd.Api.Api.Features.VoitureFeature.AutoMapperProfiles;
using BackEnd.Api.Api.Features.VoitureFeature.Queries;
using BackEnd.Api.DAL.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Api.Api.Features.VoitureFeature.Handlers
{
    public class GetVoitureByIdHandler : IRequestHandler<GetVoitureByIdQuery, GetVoitureDTO>
    {

        private readonly MyContext _myContext;
        private readonly IMapper _mapper;
        public GetVoitureByIdHandler(MyContext myContext, IMapper mapper)
        {
            _myContext = myContext;
            _mapper = mapper;
        }



public async Task<GetVoitureDTO> Handle(GetVoitureByIdQuery request, CancellationToken cancellationToken)
{
    if (_myContext == null)
    {
        // handle the case where _myContext is null
        throw new Exception("_myContext is null.");
    }

        var voiture = await _myContext.Voitures
            ?.Where(b => b.Id_Voiture == request.Id)
            ?.FirstOrDefaultAsync(cancellationToken);

        if (voiture == null)
        {
            // log the error or throw a custom exception
            throw new Exception($"Could not find voiture with ID '{request.Id}'.");
    }

    return _mapper.Map<GetVoitureDTO>(voiture);
}



    }
}
