using DeveloperTest.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeveloperTest.Business.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerModel>> GetCustomersAsync(CancellationToken token);
        Task<CustomerModel> GetCustomerAsync(int id, CancellationToken token);
        Task<CustomerModel> CreateCustomerAsync(BaseCustomerModel model, CancellationToken token);

        //Added for manual testing purposes
        Task<bool> DeleteCustomer(int id, CancellationToken token);
    }
}
