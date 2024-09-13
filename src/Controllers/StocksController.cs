using AutoMapper;
using csharp_stocks.BAL;
using csharp_stocks.Models;
using Microsoft.AspNetCore.Mvc;

namespace csharp_stocks.Controllers;


[ApiController]
[Route("[controller]")]
public class StocksController : ControllerBase
{
    private readonly IStockService _stockService;
    public StocksController(IStockService stockService)
    {
        _stockService = stockService;
    }

    [HttpGet(Name = "GetStocks")]
    public async Task<IActionResult> Get([FromQuery] Request request)
    {
        
        var stocks = await _stockService.GetByFilterAsync(request);
        
        
        return Ok(stocks);
    }
}
