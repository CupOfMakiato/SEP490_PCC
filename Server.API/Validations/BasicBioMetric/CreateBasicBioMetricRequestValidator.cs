using FluentValidation;
using Server.Application.Abstractions.RequestAndResponse.BasicBioMetric;

namespace Server.API.Validations.BasicBioMetric
{
    public class CreateBasicBioMetricRequestValidator : AbstractValidator<CreateBasicBioMetricRequest>
    {
        public CreateBasicBioMetricRequestValidator()
        {
            RuleFor(x => x.GrowthDataId)
                .NotEmpty().WithMessage("Growth Data ID is required.");

            RuleFor(x => x.WeightKg)
                .GreaterThan(0).WithMessage("Weight must be greater than 0.")
                .LessThanOrEqualTo(300).WithMessage("Weight must be less than or equal to 300 kg.");

            RuleFor(x => x.HeightCm)
                .GreaterThan(0).WithMessage("Height must be greater than 0.")
                .LessThanOrEqualTo(300).WithMessage("Height must be less than or equal to 300 cm.");

            RuleFor(x => x.SystolicBP)
                .GreaterThan(0).WithMessage("Systolic BP must be greater than 0.")
                .LessThanOrEqualTo(300).WithMessage("Systolic BP must be less than or equal to 300 mmHg.");

            RuleFor(x => x.DiastolicBP)
                .GreaterThan(0).WithMessage("Diastolic BP must be greater than 0.")
                .LessThanOrEqualTo(200).WithMessage("Diastolic BP must be less than or equal to 200 mmHg.");

            RuleFor(x => x.HeartRateBPM)
                .GreaterThan(0).WithMessage("Heart Rate must be greater than 0.")
                .LessThanOrEqualTo(200).WithMessage("Heart Rate must be less than or equal to 200 bpm.");

            RuleFor(x => x.BloodSugarLevelMgDl)
                .GreaterThanOrEqualTo(0).WithMessage("Blood Sugar Level must be greater than or equal to 0.");
        }
    }
}
