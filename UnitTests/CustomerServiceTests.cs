using AutoMapper;
using DeveloperTest.Business;
using DeveloperTest.Database;
using DeveloperTest.Database.Models;
using DeveloperTest.Enums;
using DeveloperTest.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections;
using Xunit;

namespace UnitTests
{

    /// <summary>
    /// This is only an example of creating unit tests for my application because it wasn't required in the task. 
    /// This is more of showing how I would approach unit tests rather than writing them.
    /// U can see used libraries and usage of mocks.
    /// Thank you :)
    /// </summary>
    public class CustomerServiceTests
    {
        private readonly Mock<DbSet<Customer>> _customerDbSetMock = new Mock<DbSet<Customer>>();
        private readonly Mock<ApplicationDbContext> _applicationDbContextMock = new Mock<ApplicationDbContext>();
        private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();

        private readonly CustomerService _customerService;

        public CustomerServiceTests()
        {
            _customerDbSetMock.Setup(x => x.AddAsync(It.IsAny<Customer>(), It.IsAny<CancellationToken>())).Returns((Customer c) => c);
            _applicationDbContextMock.Setup(x => x.Customers).Returns(_customerDbSetMock.Object);
            _mapperMock.Setup(x => x.Map<BaseCustomerModel, Customer>(It.IsAny<BaseCustomerModel>())).Returns(new Customer());

            _customerService = new CustomerService(_applicationDbContextMock.Object, _mapperMock.Object);
        }

        [Theory, MemberData(nameof(CustomerCreateData))]
        public async Task AddCustomer_Invoke_CustomerCreatedOnce(BaseCustomerModel input, Customer expectedData)
        {
            var user = await _customerService.CreateCustomerAsync(input, It.IsAny<CancellationToken>());

            Assert.NotNull(user);

            _customerDbSetMock.Verify(x => x.Add(It.Is<Customer>(u => u.Name == expectedData.Name && u.Type == expectedData.Type && u.Id != 0)), Times.Once);
            _applicationDbContextMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
    }

    public class CustomerCreateData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                new BaseCustomerModel { Name = "customer 1", Type = CustomerTypeEnum.Small },
                new Customer { Name = "customer 1", Type = CustomerTypeEnum.Small }
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}