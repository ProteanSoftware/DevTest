using DeveloperTest.Database.Models;
using DeveloperTest.Models;

namespace DeveloperTest.Mappers
{
    public static class CustomerMappingExtensions
    {
        public static Customer ToCustomerDbEntity(this CustomerModel source)
        {
            return new Customer()
            {
                CustomerId = source.CustomerId,
                Name = source.Name,
                Type = source.Type,
            };
        }

        public static BaseCustomerModel ToBaseCustomerModel(this CustomerModel source)
        {
            return new BaseCustomerModel()
            {
                Name = source.Name,
                Type = source.Type
            };
        }

        public static CustomerModel ToModel(this Customer source)
        {
            return new CustomerModel()
            {
                CustomerId = source.CustomerId,
                Name = source.Name,
                Type = source.Type
            };
        }
    }
}
