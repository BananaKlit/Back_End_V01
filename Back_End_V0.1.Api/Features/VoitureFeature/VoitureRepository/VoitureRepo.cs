using AutoMapper;
using BackEnd.Api.Api.Features.VoitureFeature.AutoMapperProfiles;
using BackEnd.Api.DAL.DataAccess;
using BackEnd.Api.Models;
using MediatR;

namespace BackEnd.Api.Api.Features.VoitureFeature.VoitureRepository
{
    public class VoitureRepo:IVoitureRepo
    {
        protected readonly MyContext _mycontext;
        protected IMapper _mapper;
         private readonly ILogger<VoitureRepo> _logger;
       
       public VoitureRepo(MyContext mycontext, IMapper mapper, ILogger<VoitureRepo> logger)
{
    _mycontext = mycontext ?? throw new ArgumentNullException(nameof(mycontext));
    _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
}

        public void AddVoiture(Voiture voiture)
        {
            if (voiture == null)
            {
                throw new ArgumentNullException(nameof(voiture));
            }

            _mycontext.Add(voiture);
        }
           public async Task Save()
        {
            try
            {
                await _mycontext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving changes to database");
                throw;
            }
        }
         public void DeleteVoiture(int id)
        {
            var voiture = _mycontext.Voitures?.FirstOrDefault(a => a.Id_Voiture == id);

            if (voiture == null)
            {
                throw new ArgumentException($"No voiture found with ID {id}", nameof(id));
            }

            _mycontext.Remove(voiture);
        }

          public void Dispose()
        {
            _mycontext.Dispose();
        }

         public IEnumerable<VoitureDTO> GetAllVoitures()
        {
            return _mycontext.Set<VoitureDTO>();
        }

        public Voiture GetVoitureById(int id)
{
    var voiture = _mycontext?.Voitures?.Find(id);
    
    if (voiture == null)
    {
        throw new ArgumentException($"Invalid voiture ID: {id}");
    }
    
    return voiture;
}


           public void UpdateVoiture(Voiture voiture, int id)
{
    var mycontext =  _mycontext ?? throw new ArgumentNullException(nameof(_mycontext), "DbContext is null");

    var existingVoiture = mycontext.Voitures!.Find(id);

    if (existingVoiture == null)
    {
        throw new ArgumentException($"No voiture found with ID {id}", nameof(id));
    }

    mycontext.Update(existingVoiture);
}
    
    }
}
