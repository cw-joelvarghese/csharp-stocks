namespace csharp_stocks.Models;

public class Stock
{
    public int MakeYear { get; set; }
    public string MakeName { get; set; }
    public string ModelName { get; set; }
    public int Price { get; set; }
    public int Id { get; set; }
    public int Km { get; set; }
    public FuelType Fuel { get; set; }
}