using DeveloperTest.Business.Interfaces;
using DeveloperTest.Database;
using DeveloperTest.Database.Models;
using DeveloperTest.Mappers;
using DeveloperTest.Models;
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

        public async Task<CustomerModel> CreateCustomerAsync(BaseCustomerModel model)
        {
            var customer = context.Customers.Add(new Customer
            {
                Name = model.Name,
                Type = model.Type
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

        public Task<CustomerModel[]> GetCustomersAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
