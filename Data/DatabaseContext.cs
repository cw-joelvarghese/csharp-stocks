using csharp_stocks.Models;
using Microsoft.EntityFrameworkCore;
namespace csharp_stocks.Data;

public class DatabaseContext : DbContext
{
    static readonly string connectionString = "Server=localhost; User ID=root; Password=root; Database=stocks";

    public DbSet<Stock> Stocks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }
}
