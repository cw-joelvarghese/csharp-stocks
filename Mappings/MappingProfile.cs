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
              .ForMember(dest => dest.MinBudget, opt => opt.MapFrom(src => src.MinBudget));
    }
}
