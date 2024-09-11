using AutoMapper;
using csharp_stocks.DAL;
using csharp_stocks.Models;

namespace csharp_stocks.BAL;

public class StockService : IStockService
{
    private readonly IStockRepository _stockRepository;
    private readonly IMapper _mapper;

    public StockService(IStockRepository stockRepository, IMapper mapper)
    {
        _stockRepository = stockRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<Stock>> GetAllAsync()
    {
        return await _stockRepository.GetAllAsync();
    }
    public async Task<IEnumerable<Stock>> GetByFilterAsync(Filters filters)
    {
        return await _stockRepository.GetByFilter(filters);
    }
}