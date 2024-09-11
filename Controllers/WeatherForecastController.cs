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

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IActionResult> Get([FromQuery] Request request)
    {
        var filter = _mapper.Map<Filters>(request);
        var a = await _stockService.GetByFilterAsync(filter);
        return Ok(a);
        // Console.WriteLine(a[0].price);
        // return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        // {
        //     Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        //     TemperatureC = Random.Shared.Next(-20, 55),
        //     Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        // })
        // .ToArray();
    }
}
