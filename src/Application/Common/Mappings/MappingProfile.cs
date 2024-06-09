using AutoMapper;
using FinalProject14231.Application.Common.Dtos;
using FinalProject14231.Domain.Entities;

namespace FinalProject14231.Application.Common.Mappings;
public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<Rental, RentalDto>();
        CreateMap<RentalDto, Rental>();
        CreateMap<Customer, CustomerDto>();
        CreateMap<CustomerDto, Customer>();
        CreateMap<Bike, BikeDto>();
        CreateMap<BikeDto, Bike>();
    }
}
