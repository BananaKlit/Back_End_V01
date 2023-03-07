
using System.ComponentModel.DataAnnotations;

namespace BackEnd.Api.Models
{
    public class Voiture
    {
        [Key]
        [Required]
        public int Id_Voiture { get; set; }
        [Required]
        public string? Matricule { get; set; }
        [Required]
        public string? Modele { get; set; }
        [Required]
        public string? Carburant { get; set; }

        public void UpdateVoiture(string matricule, string modele,String carburant)
        {
            Matricule = matricule; Modele= modele; Carburant = carburant; 
        }
    }
}
