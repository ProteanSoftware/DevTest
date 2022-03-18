using DeveloperTest.Business;
using DeveloperTest.Business.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DeveloperTest.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureBusinessServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IJobService, JobService>();
        serviceCollection.AddTransient<ICustomerService, CustomerService>();
    }
}