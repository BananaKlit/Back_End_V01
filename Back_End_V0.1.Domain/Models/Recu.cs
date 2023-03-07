using System.ComponentModel.DataAnnotations;

namespace BackEnd.Api.Models
{
    public class Recu
    {
        [Key]
        [Required]
        public int Id_recu { get; set; }
        [Required]
        public Reservation? reservation { get; set; }



    }
}
