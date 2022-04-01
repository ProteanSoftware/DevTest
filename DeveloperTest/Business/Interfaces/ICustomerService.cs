using DeveloperTest.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeveloperTest.Business.Interfaces
{
    public interface ICustomerService
    {
        ValueTask<IEnumerable<CustomerModel>> GetCustomersAsync();
        ValueTask<CustomerModel> GetCustomerAsync(int id);
        ValueTask<CustomerModel> CreateCustomerAsync(BaseCustomerModel model);
        IEnumerable<string> GetTypes();
    }
}
