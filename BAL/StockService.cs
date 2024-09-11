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
    public async Task<IEnumerable<StockDTO>> GetByFilterAsync(Request request)
    {
        var filters = _mapper.Map<Filters>(request);
        var stocks = await _stockRepository.GetByFilter(filters);
        var stocksDto = _mapper.Map<List<StockDTO>>(stocks);
        return stocksDto;
    }
}