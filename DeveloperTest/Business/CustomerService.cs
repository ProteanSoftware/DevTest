using DeveloperTest.Business.Interfaces;
using DeveloperTest.Database;
using DeveloperTest.Database.Models;
using DeveloperTest.Enums;
using DeveloperTest.Models;
using System.Linq;

namespace DeveloperTest.Business
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext context;

        public CustomerService(ApplicationDbContext context)
        {
            //Set db context
            this.context = context;
        }

        /// <summary>
        /// Create a new customer, and return with Id number.
        /// </summary>
        /// <param name="model">Customer to be created.</param>
        /// <returns></returns>
        public CustomerModel CreateCustomer(BaseCustomerModel model)
        {
            var addedCustomer = context.Customers.Add(new Customer
            {
                CustomerType = model.CustomerType,
                Name = model.Name
            });

            context.SaveChanges();

            return new CustomerModel
            {
                CustomerId = addedCustomer.Entity.CustomerId,
                CustomerType = addedCustomer.Entity.CustomerType,
                Name = addedCustomer.Entity.Name
            };
        }

        /// <summary>
        /// Get a SINGLE customer
        /// </summary>
        /// <param name="id">Customer Id</param>
        /// <returns></returns>
        public CustomerModel GetCustomer(int id)
        {
            //Will return null if no customer found for provided Id.
            return context.Customers.Where(x => x.CustomerId == id).Select(x => new CustomerModel
            {
                CustomerId = x.CustomerId,
                CustomerType = x.CustomerType,
                Name = x.Name
            }).SingleOrDefault();
        }

        /// <summary>
        /// Get ALL customers
        /// </summary>
        /// <returns></returns>        
        public CustomerModel[] GetCustomers()
        {
            return context.Customers.Select(x => new CustomerModel
            {
                CustomerId = x.CustomerId,
                CustomerType = x.CustomerType,
                Name = x.Name
            }).ToArray();
        }
    }
}
