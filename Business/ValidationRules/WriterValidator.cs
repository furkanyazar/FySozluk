using Business.Constants;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterEmail).NotEmpty().WithMessage(Messages.EmailNotEmpty);
            RuleFor(x => x.WriterEmail).MaximumLength(200).WithMessage(Messages.EmailMaximumLength);
            RuleFor(x => x.WriterEmail).EmailAddress().WithMessage(Messages.InvalidEmailAddress);
            RuleFor(x => x.WriterFirstName).NotEmpty().WithMessage(Messages.WriterFirstNameNotEmpty);
            RuleFor(x => x.WriterFirstName).MinimumLength(2).WithMessage(Messages.WriterFirstNameMinimumLength);
            RuleFor(x => x.WriterFirstName).MaximumLength(50).WithMessage(Messages.WriterFirstNameMaximumLength);
            RuleFor(x => x.WriterLastName).NotEmpty().WithMessage(Messages.WriterLastNameNotEmpty);
            RuleFor(x => x.WriterLastName).MinimumLength(2).WithMessage(Messages.WriterLastNameMinimumLength);
            RuleFor(x => x.WriterLastName).MaximumLength(50).WithMessage(Messages.WriterLastNameMaximumLength);
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage(Messages.WriterPasswordNotEmpty);
            RuleFor(x => x.WriterPassword).MinimumLength(8).WithMessage(Messages.WriterPasswordMinimumLength);
            RuleFor(x => x.WriterPassword).MaximumLength(50).WithMessage(Messages.WriterPasswordMaximumLength);
            RuleFor(x => x.WriterAbout).MaximumLength(100).WithMessage(Messages.WriterAboutMaximumLength);
            RuleFor(x => x.WriterTitle).MaximumLength(50).WithMessage(Messages.WriterTitleMaximumLength);
            RuleFor(x => x.WriterImageUrl).MaximumLength(250).WithMessage(Messages.WriterImageUrlMaximumLength);
        }
    }
}
