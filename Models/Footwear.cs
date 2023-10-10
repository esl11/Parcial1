using System.Runtime.ConstrainedExecution;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace parcial1.Models;

//Validar solo las empresas disponibles
public enum BrandEnum
{
    Nike,
    Adidas,
    Puma
}


public class Footwear
{
    public int Id { get; set; }

    [DisplayName("Tipo de calzado")]
    public string Type { get; set; }
    
    [DisplayName("Marca")]
    [EnumDataType(typeof(BrandEnum))]
    public BrandEnum Brand { get; set; }
 
    [DisplayName("Modelo")]
    public string Model { get; set; }
 
    [DisplayName("Genero")]
    public string Gender { get; set; }

    [DisplayName("Talle")]
    public int Size { get; set; }
 
    [DisplayName("Precio")]
    public decimal Price { get; set; }

    [DisplayName("Ahora 12")]
    public bool PayInInstallments { get; set; }
 
    [DisplayName("URL de imagen")]
    public string ImageUrl { get; set; }
        
     public Store? Store { get; set; }
 }
