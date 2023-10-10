using System.Runtime.ConstrainedExecution;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace parcial1.Models;

public class Store
{
    public int Id { get; set; }

    [DisplayName("Nombre de fabricante")]
    public string Fname { get; set; }

    [DisplayName("Nombre de empresa")]
    public string Sname { get; set; }

    [DisplayName("N° Sucursal")]
    public int Suc { get; set; }

    [DisplayName("Dirección")]
    public string Adress { get; set; }

    [DisplayName("Teléfono")]
    public string Phone { get; set; }

    [DisplayName("Pagina web")]
    public string Web { get; set; }
    
 }
