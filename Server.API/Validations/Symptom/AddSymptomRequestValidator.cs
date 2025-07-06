using FluentValidation;
using Server.Application.Abstractions.RequestAndResponse.Symptom;

namespace Server.API.Validations.Symptom
{
    public class AddSymptomRequestValidator : AbstractValidator<AddSymptomRequest>
    {
        public AddSymptomRequestValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is required");
            RuleFor(x => x.SymptomName).NotEmpty().WithMessage("Symptom name is required");
        }
    }
}