using System.Data;
using csharp_stocks.Data;
using csharp_stocks.Models;
using Dapper;

namespace csharp_stocks.DAL;

public class StockRepositroy : IStockRepository
{
    private readonly IDbConnection _dbConnection;
    public StockRepositroy(DatabaseConnection databaseConnection)
    {
        _dbConnection = databaseConnection.CreateConnection();
    }
    public async Task<IEnumerable<Stock>> GetAllAsync()
    {
        const string sql = "SELECT * FROM stocks";
        return await _dbConnection.QueryAsync<Stock>(sql);
    }

    public async Task<IEnumerable<Stock>> GetByFilter(Filters filters)
    {

        const string sql = "SELECT * FROM stocks";
        var whereString = " WHERE ";

        if (filters.Fuel != null && filters.Fuel.Count > 0)
        {
            whereString += "Fuel IN @Fuel AND ";
        }
        if (filters.MinBudget != null)
        {
            whereString += "price >= @MinBudget AND ";
        }
        if (filters.MaxBudget != null)
        {
            whereString += "price <= @MaxBudget AND ";
        }
        whereString = Utils.TrimEnd(whereString, " AND ");
        whereString = Utils.TrimEnd(whereString, " WHERE ");
        return await _dbConnection.QueryAsync<Stock>(sql + whereString, new
        {
            filters.MaxBudget,
            filters.MinBudget,
            Fuel = filters.Fuel?.Select(x => (int)x).ToList()
        });
    }
}