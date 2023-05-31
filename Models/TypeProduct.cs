using System.ComponentModel.DataAnnotations;

namespace MusicShopWebAppMVC.Models;

public class TypeProduct
{
    [Key]
    [Required]
    public string? TypeName { get; set; }
}