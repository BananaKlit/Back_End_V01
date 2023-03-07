using System.ComponentModel.DataAnnotations;

namespace BackEnd.Api.Models;

public class Admin
{
    [Key]
    [Required]
    public int id_admin { get; set; }
    [Required]
    public string? log { get; set; }
    [Required]
    public string? pass { get; set; }
}
