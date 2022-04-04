using DeveloperTest.Database.Models;
using DeveloperTest.Models;
using System;

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
                Type = Enum.TryParse(source.Type, out CustomerType type) 
                    ? type 
                    : throw new ArgumentException("Invalid customer type. Cannot parse the customer type."),
            };
        }

        public static CustomerModel ToModel(this Customer source)
        {
            return new CustomerModel()
            {
                CustomerId = source.CustomerId,
                Name = source.Name,
                Type = source.Type.ToString()
            };
        }
    }
}
