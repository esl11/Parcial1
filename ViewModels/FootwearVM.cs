using System.ComponentModel.DataAnnotations;

namespace parcial1.ViewModels;

public class FootwearVM
{
     public int Id { get; set; }

    [Display(Name = "Tipo de calzado")]
    public string Type { get; set; }
    
    [Display(Name = "Marca")]
    public string Brand { get; set; }
 
    [Display(Name = "Modelo")]
    public string Model { get; set; }
 
    [Display(Name = "Precio")]
    public decimal Price { get; set; }

    [Display(Name = "Conseguilos en")]
     public string? Storename { get; set; }
}