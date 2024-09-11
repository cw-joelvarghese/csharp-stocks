using csharp_stocks.Models;
using Microsoft.EntityFrameworkCore;

namespace csharp_stocks.DAL;

public class StockRepositroy : IStockRepository
{
    private readonly DatabaseContext _context;
    public StockRepositroy(DatabaseContext databaseContext)
    {
        _context = databaseContext;
    }
    public async Task<IEnumerable<Stock>> GetAllAsync()
    {
        return await _context.Stocks.ToListAsync();
    }
    public async Task<IEnumerable<Stock>> GetByFilter(Filters filters)
    {
        IQueryable<Stock> items = _context.Stocks;
        if (filters.Fuel != null && filters.Fuel.Count > 0)
        {
            items = items.Where(s => filters.Fuel.Contains(s.Fuel));
        }
        if (filters.MinBudget != null)
        {
            items = items.Where(s => s.Price >= filters.MinBudget);
        }
        if (filters.MaxBudget != null)
        {
            items = items.Where(s => s.Price <= filters.MaxBudget);
        }
        return await items.ToListAsync();
    }
}