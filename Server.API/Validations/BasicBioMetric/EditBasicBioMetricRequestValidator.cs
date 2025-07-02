using FluentValidation;
using Server.Application.Abstractions.RequestAndResponse.BasicBioMetric;

namespace Server.API.Validations.BasicBioMetric
{
    public class EditBasicBioMetricRequestValidator : AbstractValidator<EditBasicBioMetricRequest>
    {
        public EditBasicBioMetricRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("BBM ID is required.");

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

            RuleFor(x => x.Notes)
                .MaximumLength(500).WithMessage("Notes must not exceed 500 characters.");
        }
    }
}
