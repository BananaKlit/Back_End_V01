using BackEnd.Api.Api.Features.VoitureFeature.AutoMapperProfiles;
using BackEnd.Api.Models;

namespace BackEnd.Api.Api.Features.VoitureFeature.VoitureRepository
{
    public interface IVoitureRepo :IDisposable
    {
        IEnumerable<VoitureDTO> GetAllVoitures();
        Voiture GetVoitureById(int id);
         Task Save();
        void AddVoiture(Voiture voiture);
        void DeleteVoiture(int id);
        void UpdateVoiture(Voiture voiture, int id);
    
    }
}
