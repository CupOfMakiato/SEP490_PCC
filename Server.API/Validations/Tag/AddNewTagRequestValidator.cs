using FluentValidation;
using Server.Application.Abstractions.RequestAndResponse.Tag;

namespace Server.API.Validations.Tag
{
    public class AddNewTagRequestValidator : AbstractValidator<AddNewTagRequest>
    {
        public AddNewTagRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Tag name is required.")
                .MaximumLength(50).WithMessage("Tag name must not exceed 50 characters.");
        }
    }
}
