using DeveloperTest.Exceptions.Base;

namespace DeveloperTest.Exceptions;

public sealed class CustomerNotFoundException : NotFoundException
{
    public CustomerNotFoundException(int customerId)
        : base($"Customer with id {customerId} doesn't exits.")
    { }
}