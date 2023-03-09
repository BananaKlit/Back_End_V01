using System.ComponentModel.DataAnnotations;


namespace BackEnd.Api.Api.Features.VoitureFeature.AutoMapperProfiles
{

    public class GetVoitureDTO
    {   
        [Required]
        public int Id { get; set; }
       
        public string ?Matricule { get;set; }
      
        public string ?Modele { get; set; }
       
        public string ?Carburant { get; set; }
    }


}
