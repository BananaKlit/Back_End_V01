
using AutoMapper;
using BackEnd.Api.Abstractions;
using BackEnd.Api.Api.Features.VoitureFeature.AutoMapperProfiles;
using BackEnd.Api.Api.Features.VoitureFeature.Commands;
using BackEnd.Api.Api.Features.VoitureFeature.Endpoints;
using BackEnd.Api.Api.Features.VoitureFeature.Queries;
using BackEnd.Api.DAL.DataAccess;
using BackEnd.Api.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Api.Api.Features.VoitureFeature
{
    public class VoitureModule : IModule
    {
        private IMediator ?_mediator;
        private IMapper ?_mapper;
        public IEndpointRouteBuilder MapEnpoints(IEndpointRouteBuilder endpoints)
        {
            if (_mediator == null)
            {
                throw new ArgumentNullException(nameof(_mediator));
            }

            if (_mapper == null)
            {
                throw new ArgumentNullException(nameof(_mapper));
            }

            new ReadVoituresEndpoint(_mediator, _mapper).RegisterRoutes(endpoints);
            new WriteVoituresEndpoint(_mediator).RegisterRoutes(endpoints);
            return endpoints;    
        }


        public WebApplicationBuilder RegisterModule(WebApplicationBuilder builder)
        {
            var provider = builder.Services.BuildServiceProvider();
            _mediator = provider.GetRequiredService<IMediator>();
            _mapper = provider.GetRequiredService<IMapper>();
            return builder;
        }
    }
}
