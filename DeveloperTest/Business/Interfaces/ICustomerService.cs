using DeveloperTest.Models;
using System.Threading.Tasks;

namespace DeveloperTest.Business.Interfaces
{
    public interface ICustomerService
    {
        public Task<CustomerModel[]> GetCustomersAsync();
        public Task<CustomerModel> GetCustomerAsync(int id);
        public Task<CustomerModel> CreateCustomerAsync(BaseCustomerModel model);
    }
}
