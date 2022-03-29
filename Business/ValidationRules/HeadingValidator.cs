using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;

namespace Business.ValidationRules
{
    public class HeadingValidator : AbstractValidator<Heading>
    {
        public HeadingValidator()
        {
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage(Messages.CategoryIdNotEmpty);
            RuleFor(x => x.CategoryId).GreaterThan(0).WithMessage(Messages.CategoryIdGreaterThan);
            RuleFor(x => x.WriterId).NotEmpty().WithMessage(Messages.WriterIdNotEmpty);
            RuleFor(x => x.WriterId).GreaterThan(0).WithMessage(Messages.WriterIdGreaterThan);
            RuleFor(x => x.HeadingName).NotEmpty().WithMessage(Messages.HeadingNameNotEmpty);
            RuleFor(x => x.HeadingName).MinimumLength(3).WithMessage(Messages.HeadingNameMinimumLength);
            RuleFor(x => x.HeadingName).MaximumLength(50).WithMessage(Messages.HeadingNameMaximumLength);
            RuleFor(x => x.HeadingDate).NotEmpty().WithMessage(Messages.HeadingDateNotEmpty);
            RuleFor(x => x.HeadingDate).GreaterThan(DateTime.Today).WithMessage(Messages.HeadingDateGreaterThan);
        }
    }
}
