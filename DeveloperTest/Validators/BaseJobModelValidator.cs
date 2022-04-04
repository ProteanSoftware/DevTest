using DeveloperTest.Models;
using FluentValidation;
using System;

namespace DeveloperTest.Validators
{
    public class BaseJobModelValidator : AbstractValidator<BaseJobModel>
    {
        public BaseJobModelValidator()
        {
            RuleFor(x => x.CustomerId)
                .GreaterThan(0);

            RuleFor(x => x.When.Date)
                .GreaterThan(DateTime.Now.Date);
        }
    }
}
