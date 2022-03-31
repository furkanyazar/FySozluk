using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;

namespace Business.ValidationRules
{
    public class ContentValidator : AbstractValidator<Content>
    {
        public ContentValidator()
        {
            RuleFor(x => x.HeadingId).NotEmpty().WithMessage(Messages.HeadingIdNotEmpty);
            RuleFor(x => x.HeadingId).GreaterThan(0).WithMessage(Messages.HeadingIdGreaterThan);
            RuleFor(x => x.WriterId).NotEmpty().WithMessage(Messages.WriterIdNotEmpty);
            RuleFor(x => x.WriterId).GreaterThan(0).WithMessage(Messages.WriterIdGreaterThan);
            RuleFor(x => x.ContentDate).NotEmpty().WithMessage(Messages.DateNotEmpty);
            RuleFor(x => x.ContentText).NotEmpty().WithMessage(Messages.ContentTextNotEmpty);
            RuleFor(x => x.ContentText).MinimumLength(2).WithMessage(Messages.ContentTextMinimumLength);
            RuleFor(x => x.ContentText).MaximumLength(1000).WithMessage(Messages.ContentTextMaximumLength);
        }
    }
}
