using csharp_stocks.Models;

namespace csharp_stocks.DAL;

public interface IStockRepository
{
    Task<IEnumerable<Stock>> GetAllAsync();
    Task<IEnumerable<Stock>> GetByFilter(Filters filters);

}