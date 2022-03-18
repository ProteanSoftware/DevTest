using AutoMapper;
using DeveloperTest.Database.Models;
using DeveloperTest.DTO.Customer;

namespace DeveloperTest;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Customer, CustomerDto>()
            .ReverseMap();

        CreateMap<CreateCustomerDto, Customer>()
            .ForMember(x => x.CustomerTypeId, 
                opt => opt.MapFrom(x => (byte)x.TypeId));

        CreateMap<CustomerType, CustomerTypeDto>();
    }
}