using csharp_stocks.BAL;
using csharp_stocks.DAL;
using csharp_stocks.Data;
using csharp_stocks.Mapping;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddControllers();
builder.Services.AddSingleton(new DatabaseConnection("Server=localhost; User ID=root; Password=root; Database=stocks"));
// builder.Services.AddDbContext<DatabaseContext>(options => options.UseMySQL("Server=localhost; User ID=root; Password=root; Database=stocks")); 
builder.Services.AddScoped<IStockRepository, StockRepositroy>();
builder.Services.AddScoped<IStockService, StockService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
