using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Business.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage(Messages.MessageContentNotEmpty);
            RuleFor(x => x.MessageContent).MaximumLength(1000).WithMessage(Messages.MessageContentMaximumLength);
            RuleFor(x => x.MessageSubject).MinimumLength(3).WithMessage(Messages.MessageSubjectMinimumLength);
            RuleFor(x => x.MessageSubject).MaximumLength(100).WithMessage(Messages.MessageSubjectMaximumLength);
            RuleFor(x => x.ReceiverEmail).NotEmpty().WithMessage(Messages.EmailNotEmpty);
            RuleFor(x => x.ReceiverEmail).EmailAddress().WithMessage(Messages.InvalidEmailAddress);
            RuleFor(x => x.ReceiverEmail).MaximumLength(50).WithMessage(Messages.EmailMaximumLength);
            RuleFor(x => x.SenderEmail).NotEmpty().WithMessage(Messages.EmailNotEmpty);
            //RuleFor(x => x.SenderEmail).EmailAddress().WithMessage(Messages.InvalidEmailAddress);
            RuleFor(x => x.SenderEmail).MaximumLength(50).WithMessage(Messages.EmailMaximumLength);
        }
    }
}
