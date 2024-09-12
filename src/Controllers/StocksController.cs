using AutoMapper;
using csharp_stocks.BAL;
using csharp_stocks.Models;
using Microsoft.AspNetCore.Mvc;

namespace csharp_stocks.Controllers;


[ApiController]
[Route("[controller]")]
public class StocksController : ControllerBase
{

    private readonly ILogger<StocksController> _logger;

    private readonly IMapper _mapper;
    private readonly IStockService _stockService;
    public StocksController(ILogger<StocksController> logger, IMapper mapper, IStockService stockService)
    {
        _mapper = mapper;
        _logger = logger;
        _stockService = stockService;
    }

    [HttpGet(Name = "GetStocks")]
    public async Task<IActionResult> Get([FromQuery] Request request)
    {
        
        var stocks = await _stockService.GetByFilterAsync(request);
        
        return Ok(stocks);
    }
}
