using DeveloperTest.Business.Interfaces;
using DeveloperTest.Database;
using DeveloperTest.Database.Models;
using DeveloperTest.Mappers;
using DeveloperTest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperTest.Business
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext context;

        public CustomerService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async ValueTask<CustomerModel> CreateCustomerAsync(BaseCustomerModel model)
        {
            if (!Enum.TryParse(value: model.Type, ignoreCase: true, out CustomerType result))
            {
                throw new ArgumentException($"{nameof(CustomerType)} must be valid.");
            }

            var customer = context.Customers.Add(new Customer
            {
                Name = model.Name,
                Type = result
            });

            await context.SaveChangesAsync();

            return customer
                .Entity
                .ToModel();
        }

        public async Task<CustomerModel> GetCustomerAsync(int id)
        {
            var customer = await context.Customers.FindAsync(id);
            return customer?.ToModel();
        }

        public async Task<CustomerModel[]> GetCustomersAsync()
        {
            return await context.Customers
                .Select(customer => new CustomerModel
                { 
                    CustomerId = customer.CustomerId,
                    Name = customer.Name,
                    Type = customer.Type
                })
                .ToArrayAsync();
        }

        public string[] GetTypes()
        {
            return typeof(CustomerType).GetEnumNames();
        }
    }
}
