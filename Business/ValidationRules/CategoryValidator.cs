using Business.Constants;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage(Messages.CategoryNameNotEmpty);
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage(Messages.CategoryNameMinimumLength);
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage(Messages.CategoryNameMaximumLength);
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage(Messages.CategoryDescriptionNotEmpty);
        }
    }
}
