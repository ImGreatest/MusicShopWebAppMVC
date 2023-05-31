using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicShopWebAppMVC.Models;

public class Album
{
    [Key]
    [Required]
    public int Id { get; set; }
    
    [Required]
    public string? NameAlbum { get; set; }
    
    [Required]
    [ForeignKey("Country")]
    public string? CountryIssue { get; set; }
    
    [Required]
    public int CountSongs { get; set; }
    
    [Required]
    public DateTime Issue { get; set; }
}