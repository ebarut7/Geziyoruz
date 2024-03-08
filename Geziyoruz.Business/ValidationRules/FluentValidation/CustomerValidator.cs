

using FluentValidation;
using Geziyoruz.Entities.Concrete;

namespace Geziyoruz.Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x=>x.CreateDate).NotNull();
        }
    }
}
