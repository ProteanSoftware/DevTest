using DeveloperTest.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeveloperTest.Business.Interfaces
{
    public interface ICustomerTypeService
    {
        Task<IEnumerable<CustomerTypeModel>> GetCustomerTypesAsync(CancellationToken token);
    }
}
