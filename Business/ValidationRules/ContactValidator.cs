using Business.Constants;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.ContactMessage).NotEmpty().WithMessage(Messages.ContactMessageNotEmpty);
            RuleFor(x => x.ContactMessage).MinimumLength(25).WithMessage(Messages.ContactMessageMinimumLength);
            RuleFor(x => x.ContactMessage).MaximumLength(1000).WithMessage(Messages.ContactMessageMaximumLength);
            RuleFor(x => x.ContactSubject).NotEmpty().WithMessage(Messages.ContactSubjectNotEmpty);
            RuleFor(x => x.ContactSubject).MinimumLength(3).WithMessage(Messages.ContactSubjectMinimumLength);
            RuleFor(x => x.ContactSubject).MaximumLength(50).WithMessage(Messages.ContactSubjectMaximumLength);
            RuleFor(x => x.ContactUserEmail).NotEmpty().WithMessage(Messages.ContactUserEmailNotEmpty);
            RuleFor(x => x.ContactUserEmail).MaximumLength(50).WithMessage(Messages.ContactUserEmailMaximumLength);
            RuleFor(x => x.ContactUserEmail).EmailAddress().WithMessage(Messages.ContactUserEmailEmailAddress);
            RuleFor(x => x.ContactUserName).NotEmpty().WithMessage(Messages.ContactUserNameNotEmpty);
            RuleFor(x => x.ContactUserName).MinimumLength(2).WithMessage(Messages.ContactUserNameMinimumLength);
            RuleFor(x => x.ContactUserName).MaximumLength(50).WithMessage(Messages.ContactUserNameMaximumLength);
        }
    }
}
