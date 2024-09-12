namespace csharp_stocks.Models;
public class Filters
{
    public int? MinBudget { get; set; }
    public int? MaxBudget { get; set; }
    public List<FuelType>? Fuel { get; set; }
}

