using FluentValidation;
using Server.Application.Abstractions.RequestAndResponse.GrowthData;
using Server.Application.DTOs.GrowthData;
using Server.Application.Interfaces;
using Server.Application.Mappers.GrowthDataExtentions;

namespace Server.API.Validations.GrowthData
{
    public class EditNewGrowthDataProfileRequestValidator : AbstractValidator<EditGrowthDataProfileRequest>
    {
        private readonly ICurrentTime _currentTime;

        public EditNewGrowthDataProfileRequestValidator(ICurrentTime currentTime)
        {
            _currentTime = currentTime;

            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Growth data profile ID is required.");
            RuleFor(x => x.PreWeight)
                .GreaterThan(0)
                .LessThan(300)
                .WithMessage("Weight must be between 1 and 299 kg.");

            RuleFor(x => x.FirstDayOfLastMenstrualPeriod)
                .NotEmpty()
                .WithMessage("First day of last menstrual period is required.")
                .Must(BeValidLMPDate)
                .WithMessage("Last menstrual period date must be between 1 week and 42 weeks ago.");

            RuleFor(x => x.EstimatedDueDate)
                .NotEmpty()
                .WithMessage("Estimated due date is required.");

            RuleFor(x => x)
                .Must(BeValidDueDateRange)
                .WithMessage("Estimated due date must be within 2 weeks of the calculated due date.")
                .Must(HaveValidGestationalAge)
                .WithMessage("Gestational age must be between 0 and 42 weeks.");
        }

        private bool BeValidLMPDate(DateTime lmpDate)
        {
            var today = _currentTime.GetCurrentTime().Date;
            var maxLMPDate = today.AddDays(-7); // At least 1 week ago
            var minLMPDate = today.AddDays(-294); // Not more than 42 weeks ago

            return lmpDate >= minLMPDate && lmpDate <= maxLMPDate;
        }

        private bool BeValidDueDateRange(EditGrowthDataProfileRequest request)
        {
            var EditGrowthDataProfileRequest = request.ToEditGrowthDataProfileDTO(_currentTime);
            return EditGrowthDataProfileRequest.IsValidDueDateRange();
        }

        private bool HaveValidGestationalAge(EditGrowthDataProfileRequest request)
        {
            var EditGrowthDataProfileRequest = request.ToEditGrowthDataProfileDTO(_currentTime);
            return EditGrowthDataProfileRequest.IsValidGestationalAge(_currentTime);
        }
    }
}
