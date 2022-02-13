using System.Linq;
using DeveloperTest.Business.Interfaces;
using DeveloperTest.Database;
using DeveloperTest.Database.Models;
using DeveloperTest.Models;

namespace DeveloperTest.Business
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext context;

        public CustomerService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public CustomerModel[] GetCustomers()
        {
            return context.Customers.Select(x => new CustomerModel
            {
                CustomerId = x.CustomerId,
                Customer = x.CustomerName,
                Type = x.Type
            }).ToArray();
        }

        public CustomerModel GetCustomer(int Id)
        {
            return context.Customers.Where(x => x.CustomerId == Id).Select(x => new CustomerModel
            {
                 CustomerId = x.CustomerId,
                  Customer = x.CustomerName,
                   Type = x.Type
            }).SingleOrDefault();
        }

        public CustomerModel CreateCustomer(BaseCustomerModel model)
        {
            var addedCustomer = context.Customers.Add(new Customer
            {
                 CustomerName = model.Customer,
                  Type = model.Type
            });

            context.SaveChanges();

            return new CustomerModel
            {
                 CustomerId = addedCustomer.Entity.CustomerId,
                  Customer = addedCustomer.Entity.CustomerName,
                   Type = addedCustomer.Entity.Type
            };
        }
    }
}
