using FluentValidation;
using Server.Application.Abstractions.RequestAndResponse.GrowthData;

namespace Server.API.Validations.GrowthData
{
    public class CreateNewGrowthDataProfileRequestValidator : AbstractValidator<CreateNewGrowthDataProfileRequest>
    {
        public CreateNewGrowthDataProfileRequestValidator()
        {
            RuleFor(x => x.FirstDayOfLastMenstrualPeriod)
                .NotEmpty().WithMessage("First day of last menstrual period is required.")
                .LessThanOrEqualTo(DateTime.UtcNow.AddDays(1)).WithMessage("Date cannot be in the future.");

            RuleFor(x => x.Height)
                .NotEmpty().WithMessage("Height is required.")
                .Matches(@"^\d+(\.\d{1,2})?$").WithMessage("Height must be a valid number (e.g., 160 or 160.5).");

            RuleFor(x => x.Weight)
                .NotEmpty().WithMessage("Weight is required.")
                .Matches(@"^\d+(\.\d{1,2})?$").WithMessage("Weight must be a valid number (e.g., 50 or 50.75).");
        }
    }
}
