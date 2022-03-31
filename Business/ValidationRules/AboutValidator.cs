using Business.Constants;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules
{
    public class AboutValidator : AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x => x.AboutDetails1).NotEmpty().WithMessage(Messages.AboutDetails1NotEmpty);
            RuleFor(x => x.AboutDetails1).MinimumLength(5).WithMessage(Messages.AboutDetails1MinimumLength);
            RuleFor(x => x.AboutDetails1).MaximumLength(250).WithMessage(Messages.AboutDetails1MaximumLength);
            RuleFor(x => x.AboutDetails2).NotEmpty().WithMessage(Messages.AboutDetails2NotEmpty);
            RuleFor(x => x.AboutDetails2).MinimumLength(5).WithMessage(Messages.AboutDetails2MinimumLength);
            RuleFor(x => x.AboutDetails2).MaximumLength(250).WithMessage(Messages.AboutDetails2MaximumLength);
            RuleFor(x => x.AboutImageUrl1).MaximumLength(250).WithMessage(Messages.AboutImageUrl1MaximumLength);
            RuleFor(x => x.AboutImageUrl2).MaximumLength(250).WithMessage(Messages.AboutImageUrl2MaximumLength);
        }
    }
}
