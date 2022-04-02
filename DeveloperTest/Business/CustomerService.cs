using AutoMapper;
using DeveloperTest.Business.Interfaces;
using DeveloperTest.Database;
using DeveloperTest.Database.Models;
using DeveloperTest.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeveloperTest.Business
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public CustomerService(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<CustomerModel>> GetCustomersAsync(CancellationToken token)
        {
            return mapper.Map<IEnumerable<CustomerModel>>(await context.Customers.Include(x => x.CustomerType).ToListAsync(token));
        }

        public async Task<CustomerModel> GetCustomerAsync(int id, CancellationToken token)
        {
            return mapper.Map<CustomerModel>(await context.Customers.Include(x => x.CustomerType).SingleOrDefaultAsync(x => x.Id == id, token));
        }

        public async Task<CustomerModel> CreateCustomerAsync(BaseCustomerModel model, CancellationToken token)
        {
            var addedCustomer = await context.Customers.AddAsync(mapper.Map<Customer>(model));

            await context.SaveChangesAsync();
            
            return mapper.Map<CustomerModel>(await context.Customers.Include(x => x.CustomerType).SingleOrDefaultAsync(x => x.Id == addedCustomer.Entity.Id, token));
        }

        //Added for manual testing purposes
        public async Task<bool> DeleteCustomer(int id, CancellationToken token)
        {
            var customerToDelete = await context.Customers.SingleOrDefaultAsync(x => x.Id == id, token);
            if (customerToDelete is null)
            {
                return false;
            }

            context.Customers.Remove(customerToDelete);
            await context.SaveChangesAsync(token);
            return true;
        }
    }
}
