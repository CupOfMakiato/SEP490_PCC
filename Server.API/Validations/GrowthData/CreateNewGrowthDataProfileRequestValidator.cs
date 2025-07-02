using FluentValidation;
using Server.Application.Abstractions.RequestAndResponse.GrowthData;
using Server.Application.Interfaces;

namespace Server.API.Validations.GrowthData
{
    public class CreateNewGrowthDataProfileRequestValidator : AbstractValidator<CreateNewGrowthDataProfileRequest>
    {

        public CreateNewGrowthDataProfileRequestValidator()
        {

            RuleFor(x => x.FirstDayOfLastMenstrualPeriod)
                .NotEmpty().WithMessage("First day of last menstrual period is required.")
                .LessThanOrEqualTo(DateTime.UtcNow.AddDays(1)).WithMessage("Date cannot be in the future.");

            RuleFor(x => x.PreWeight)
                .NotEmpty()
                .GreaterThan(0)
                .LessThan(300)
                .WithMessage("Weight must be between 1 and 299 kg.");
        }


    }
}
