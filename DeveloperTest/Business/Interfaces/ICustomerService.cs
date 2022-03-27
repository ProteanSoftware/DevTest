using DeveloperTest.Models;
using System.Threading.Tasks;

namespace DeveloperTest.Business.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerModel[]> GetCustomersAsync();
        Task<CustomerModel> GetCustomerAsync(int id);
        ValueTask<CustomerModel> CreateCustomerAsync(BaseCustomerModel model);
        string[] GetTypes();
    }
}
