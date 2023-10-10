namespace parcial1.ViewModels;

public class FootwearListVM
{
    public List<FootwearVM> Products { get; set; } = new List<FootwearVM>();
    public string? Filter { get; set; }
}