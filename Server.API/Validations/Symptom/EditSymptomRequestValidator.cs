using FluentValidation;
using Server.Application.Abstractions.RequestAndResponse.Symptom;

namespace Server.API.Validations.Symptom
{
    public class EditSymptomRequestValidator : AbstractValidator<EditSymptomRequest>
    {
        public EditSymptomRequestValidator()
        {
            RuleFor(x => x.SymptomId)
                .NotEmpty().WithMessage("Symptom ID is required.")
                .NotEqual(Guid.Empty).WithMessage("Symptom ID cannot be empty.");
            RuleFor(x => x.SymptomName)
                .NotEmpty().WithMessage("Symptom name is required.")
                .MaximumLength(50).WithMessage("Symptom name cannot exceed 50 characters.");
            //RuleFor(x => x.IsActive)
            //    .Must(value => value == true || value == false).WithMessage("IsActive must be a boolean value.");
        }
    }
}
