using AutoMapper;
using DeveloperTest.Database.Models;
using DeveloperTest.Models;

namespace DeveloperTest.MappingProfiles
{
    public class DomainToModelProfile : Profile
    {
        public DomainToModelProfile()
        {
            CreateMap<Customer, BaseCustomerModel>()
                .ForMember(dest => dest.Type, opt => 
                opt.MapFrom(src => src.CustomerType.Name));

            CreateMap<Customer, CustomerModel>()
                .ForMember(dest => dest.Type, opt =>
                opt.MapFrom(src => src.CustomerType.Id))
                .ForMember(dest => dest.TypeName, opt => 
                opt.MapFrom(src => src.CustomerType.Name));

            CreateMap<CustomerType, CustomerTypeModel>();
        }
    }
}
