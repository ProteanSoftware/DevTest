using DeveloperTest.Enums;

namespace DeveloperTest.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public CustomerTypeEnum Type { get; set; }

        public string TypeName { get; set; }
    }
}
