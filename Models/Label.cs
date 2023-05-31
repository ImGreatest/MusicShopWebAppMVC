using System.ComponentModel.DataAnnotations;

namespace MusicShopWebAppMVC.Models;

public class Label
{
    [Key]
    [Required]
    public string? NameLabel { get; set; }
}