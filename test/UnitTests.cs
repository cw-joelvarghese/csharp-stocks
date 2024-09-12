using System.Runtime.InteropServices.Marshalling;
using AutoMapper;
using csharp_stocks.BAL;
using csharp_stocks.Controllers;
using csharp_stocks.Models;
using MySqlX.XDevAPI.Common;
using Org.BouncyCastle.Ocsp;

namespace CsharpStocks.Tests;

public class StocksControllerTest
{
    [Fact]
    public void FormatNumberTest()
    {
        string formattedNumber = Utils.FormatNumber(1000);
        Assert.Equal("1,000", formattedNumber);
    }

    [Fact]
    public void IsValueForMoneyTest()
    {
        var stock = new Stock {
            Fuel=FuelType.PETROL,
            Km=2000,
            Id=1,
            MakeName="Suzuki",
            MakeYear=2023,
            Price= 100000,
            ModelName="Desire"
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
}