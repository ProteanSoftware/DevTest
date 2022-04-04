using DeveloperTest.Models;
using FluentValidation;

namespace DeveloperTest.Validators
{
    public class BaseCustomerModelValidator : AbstractValidator<BaseCustomerModel>
    {
        public BaseCustomerModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(5);

            RuleFor(x => x.Type)
                .NotNull();
        }
    }
}
