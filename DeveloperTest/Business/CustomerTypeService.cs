using AutoMapper;
using DeveloperTest.Business.Interfaces;
using DeveloperTest.Database;
using DeveloperTest.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeveloperTest.Business
{
    public class CustomerTypeService : ICustomerTypeService
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public CustomerTypeService(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<CustomerTypeModel>> GetCustomerTypesAsync(CancellationToken token)
        {
            return mapper.Map<IEnumerable<CustomerTypeModel>>(await context.CustomerTypes.ToListAsync(token));
        }
    }
}
