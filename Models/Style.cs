using System.ComponentModel.DataAnnotations;


namespace MusicShopWebAppMVC.Models;

public class Style
{
    [Key]
    [Required]
    public string? NameStyle { get; set; }
}