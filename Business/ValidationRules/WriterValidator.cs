using Business.Constants;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterEmail).NotEmpty().WithMessage(Messages.WriterEmailNotEmpty);
            RuleFor(x => x.WriterEmail).EmailAddress().WithMessage(Messages.WriterEmailEmailAddress);
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
        }
    }
}
