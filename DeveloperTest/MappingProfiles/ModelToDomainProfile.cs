using AutoMapper;
using DeveloperTest.Database.Models;
using DeveloperTest.Enums;
using DeveloperTest.Models;

namespace DeveloperTest.MappingProfiles
{
    public class ModelToDomainProfile : Profile
    {
        public ModelToDomainProfile()
        {
            CreateMap<CustomerModel, Customer>();
            CreateMap<BaseCustomerModel, Customer>()
                .ForMember(dest => dest.Type, opt => 
                opt.MapFrom(src => (CustomerTypeEnum)src.Type));

            CreateMap<CustomerTypeModel, CustomerType>();
        }
    }
}
