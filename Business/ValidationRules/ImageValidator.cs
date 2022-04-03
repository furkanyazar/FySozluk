using Business.Constants;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules
{
    public class ImageValidator : AbstractValidator<Image>
    {
        public ImageValidator()
        {
            RuleFor(x => x.ImageName).MinimumLength(3).WithMessage(Messages.ImageNameMinimumLength);
            RuleFor(x => x.ImageName).MaximumLength(50).WithMessage(Messages.ImageNameMaximumLength);
            RuleFor(x => x.ImagePath).NotEmpty().WithMessage(Messages.ImagePathNotEmpty);
            RuleFor(x => x.ImageName).MinimumLength(5).WithMessage(Messages.ImagePathMinimumLength);
            RuleFor(x => x.ImageName).MaximumLength(250).WithMessage(Messages.ImagePathMaximumLength);
            RuleFor(x => x.ImageDescription).MinimumLength(5).WithMessage(Messages.ImageDescriptionMinimumLength);
            RuleFor(x => x.ImageDescription).MaximumLength(1000).WithMessage(Messages.ImageDescriptionMaximumLength);
        }
    }
}
