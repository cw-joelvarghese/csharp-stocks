using AutoMapper;
using csharp_stocks.Models;
namespace csharp_stocks.Mapping;

public class MappingProfile : Profile
{
    List<int> validateFuel(string fuel)
    {
        return Array.ConvertAll(fuel.Split(" "), int.Parse).ToList();
    }
    public MappingProfile()
    {
        CreateMap<Request, Filters>()
              .ForMember(dest => dest.Fuel, opt => opt.MapFrom(src =>
                  validateFuel(src.Fuel)))
              .ForMember(dest => dest.MinBudget, opt => opt.MapFrom(src => src.MinBudget))
              .ForMember(dest => dest.MaxBudget, opt => opt.MapFrom(src => src.MaxBudget));
        CreateMap<Stock, StockDTO>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
              .ForMember(dest => dest.Fuel, opt => opt.MapFrom(src => src.Fuel))
              .ForMember(dest => dest.MakeName, opt => opt.MapFrom(src => src.MakeName))
              .ForMember(dest => dest.MakeYear, opt => opt.MapFrom(src => src.MakeYear))
              .ForMember(dest => dest.ModelName, opt => opt.MapFrom(src => src.ModelName))
              .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
              .ForMember(dest => dest.Km, opt => opt.MapFrom(src => src.Km))
              .ForMember(dest => dest.FormattedPrice, opt => opt.MapFrom(src => Utils.FormatNumber(src.Price)))
              .ForMember(dest => dest.IsValueForMoney, opt => opt.MapFrom(src => Utils.IsValueForMoney(src)));
    }
}
