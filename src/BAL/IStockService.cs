using csharp_stocks.Models;

namespace csharp_stocks.BAL;

public interface IStockService
{
    Task<IEnumerable<Stock>> GetAllAsync();
    Task<IEnumerable<StockDTO>> GetByFilterAsync(Request request);
}