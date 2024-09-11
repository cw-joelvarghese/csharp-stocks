namespace csharp_stocks.Models;
public class StockDTO
{
    public int MakeYear { get; set; }
    public string MakeName { get; set; }
    public string ModelName { get; set; }
    public int Price { get; set; }
    public int Id { get; set; }
    public FuelType Fuel { get; set; }
    public string FormattedPrice {get; set;}
}