using System.Runtime.InteropServices.Marshalling;
using AutoMapper;
using csharp_stocks.BAL;
using csharp_stocks.Controllers;
using csharp_stocks.DAL;
using csharp_stocks.Mapping;
using csharp_stocks.Models;
using Moq;
using MySqlX.XDevAPI.Common;
using Org.BouncyCastle.Ocsp;
using Xunit.Abstractions;

namespace CsharpStocks.Tests;

public class Test
{
    private readonly Mock<IStockService> _stockServiceMock;
    private readonly Mock<IStockRepository> _stockRepositoryMock;
    private readonly ITestOutputHelper _testOutputHelper;

    // private readonly Mock<Mapper> _mapper;
    [Fact]
    public void FormatNumberTest()
    {
        string formattedNumber = Utils.FormatNumber(1000);
        Assert.Equal("1,000", formattedNumber);
    }

    public Test(ITestOutputHelper testOutputHelper)
    {
        _stockRepositoryMock = new Mock<IStockRepository>();
        _stockServiceMock = new Mock<IStockService>();
        _testOutputHelper = testOutputHelper;
        // _mapper = new Mock<Mapper>();
    }

    [Fact]
    public void IsValueForMoneyTest()
    {
        var stock = new Stock
        {
            Fuel = FuelType.PETROL,
            Km = 2000,
            Id = 1,
            MakeName = "Suzuki",
            MakeYear = 2023,
            Price = 100000,
            ModelName = "Desire"
        };
        bool isValueForMoney = Utils.IsValueForMoney(stock);
        Assert.True(isValueForMoney);
    }

    [Fact]
    public void TrimEndTest()
    {
        var testString = "TestString";
        string result = Utils.TrimEnd(testString, "String");
        Assert.Equal("Test", result);
    }

    [Fact]
    public async void StocksControllerTest()
    {
        Request request = new Request
        {
            Fuel = "1 2",
            MaxBudget = 1000000,
            MinBudget = 0
        };

        var expected = new List<StockDTO> {
            new StockDTO {
                FormattedPrice = "50,000",
                Fuel = FuelType.PETROL,
                Id = 1,
                IsValueForMoney = true,
                Km = 20,
                MakeName = "",
                MakeYear = 2002,
                ModelName = "",
                Price = 12
            },
        };

        var toReturnstocks = new List<Stock> {
            new Stock {
                Fuel = FuelType.PETROL,
                Id = 2,
                Km = 5000,
                MakeName = "",
                MakeYear = 2002,
                ModelName = "",
                Price = 50000
            },
        };
        var config = new MapperConfiguration(cfg => 
        cfg.AddProfile(new MappingProfile()));
        var mapper = new Mapper(config);
        Filters filters = mapper.Map<Filters>(request);
        _stockRepositoryMock.Setup(s => s.GetByFilter(It.IsAny<Filters>())).Returns(Task.FromResult<IEnumerable<Stock>>(toReturnstocks));
        StockService stockService = new StockService(_stockRepositoryMock.Object, mapper);
        var stockDTOs = await stockService.GetByFilterAsync(request);
        Assert.Equal(expected[0].FormattedPrice, stockDTOs.ToList()[0].FormattedPrice);
        Assert.Equal(expected[0].IsValueForMoney, stockDTOs.ToList()[0].IsValueForMoney);
    }
}