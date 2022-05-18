using DeveloperTest.Enums;

namespace DeveloperTest.Database.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public CustomerType CustomerType { get; set; }
    }

}
