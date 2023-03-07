using System.ComponentModel.DataAnnotations;

namespace BackEnd.Api.Models
{
    public class Reservation
    {
        [Required]
        [Key]
        public int Id_Reservation { get; set; }
        [Required]
        public DateTime? date_reservation { get; set; }
        [Required]
        public Voiture? voiture { get; set; }
        [Required]
        public Client? client { get; set; }
        [Required]
        public float? montant { get; set; }


    }
}
