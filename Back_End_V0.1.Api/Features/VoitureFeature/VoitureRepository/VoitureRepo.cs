using AutoMapper;
using BackEnd.Api.Api.Features.VoitureFeature.AutoMapperProfiles;
using BackEnd.Api.DAL.DataAccess;
using BackEnd.Api.Models;
using MediatR;

namespace BackEnd.Api.Api.Features.VoitureFeature.VoitureRepository
{
    public class VoitureRepo:IVoitureRepo
    {
        protected readonly MyContext myContext;
        protected IMapper mapper;
        public VoitureRepo(MyContext myContext)=>this.myContext=myContext;

        public void AddVoiture(Voiture voiture)=>myContext.Add(voiture);
        public void Save() => myContext.SaveChangesAsync();
        public void DeleteVoiture(int id)=> myContext.Voitures.FirstOrDefault(a => a.Id_Voiture == id);

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VoitureDTO> GetAllVoitures() => myContext.Set<VoitureDTO>();

        public Voiture GetVoitureById(int id)
        {

            return myContext.Voitures.Find(id);
        }

        public void UpdateVoiture(Voiture voiture, int id)
        {
            throw new NotImplementedException();
        }
    }
}
