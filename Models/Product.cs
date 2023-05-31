using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicShopWebAppMVC.Models;

public class Product
{
    [Key]
    [Required]
    public int Id { get; set; }
    
    [Required]
    [ForeignKey("TypeProduct")]
    public string? TypeProduct { get; set; }
    
    [Required]
    [ForeignKey("Label")]
    public string? Label { get; set; }
    
    [Required]
    [ForeignKey("Style")]
    public string? Style { get; set; }
    
    [Required]
    [ForeignKey("Album")]
    public int Album { get; set; }
    
    [Required]
    [ForeignKey("Performer")]
    public int Performer { get; set; }
    
    [Required]
    [ForeignKey("Condition")]
    public string? Condition { get; set; }
    
    [Required]
    public int Cost { get; set; }
}