

using FluentValidation;
using Geziyoruz.Entities.Concrete;

namespace Geziyoruz.Business.ValidationRules.FluentValidation
{
    public class BlogPostValidator : AbstractValidator<BlogPost>
    {
        public BlogPostValidator()
        {
            RuleFor(x => x.Title).MaximumLength(50);
        }
    }
}
