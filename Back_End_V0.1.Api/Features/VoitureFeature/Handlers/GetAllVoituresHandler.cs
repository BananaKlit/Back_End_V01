using AutoMapper;
using BackEnd.Api.Api.Features.VoitureFeature.AutoMapperProfiles;
using BackEnd.Api.Api.Features.VoitureFeature.Queries;
using BackEnd.Api.DAL.DataAccess;
using BackEnd.Api.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Api.Api.Features.VoitureFeature.Handlers
{
    public class GetAllVoituresHandler : IRequestHandler<GetAllVoituresQuery, List<GetVoitureDTO>>
    {
        private readonly MyContext _context;
        private readonly IMapper _mapper;

        public GetAllVoituresHandler(MyContext myContext, IMapper mapper)
        {
            _context = myContext;
            _mapper = mapper;

        }
        public async Task<List<GetVoitureDTO>> Handle(GetAllVoituresQuery request, CancellationToken cancellationToken)
        {

            var voitures = await _context.Voitures!.ToListAsync();
            return _mapper.Map<List<GetVoitureDTO>>(voitures);
        }
    }
}
