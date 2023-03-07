using System.ComponentModel.DataAnnotations;

namespace BackEnd.Api.Models
{
    public class Client
    {
        [Key]
        [Required]
        public int id_client { get; set; }
        [Required]

        public string? nom { get; set; }
        [Required]
        public string? tel { get; set; }
        [Required]
        public string? email { get; set; }


    }
}
