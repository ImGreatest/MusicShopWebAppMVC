using System.ComponentModel.DataAnnotations;

namespace MusicShopWebAppMVC.Models;

public class Country
{
    [Key]
    [Required]
    public string? NameCountry { get; set; }
}