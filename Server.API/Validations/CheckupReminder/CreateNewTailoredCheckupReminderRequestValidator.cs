using FluentValidation;
using Server.Application.Abstractions.RequestAndResponse.CheckupReminder;

namespace Server.API.Validations.CheckupReminder
{
    public class CreateNewTailoredCheckupReminderRequestValidator : AbstractValidator<CreateNewTailoredCheckupReminderRequest>
    {
        public CreateNewTailoredCheckupReminderRequestValidator()
        {
            RuleFor(x => x.GrowthDataId)
                .NotEmpty().WithMessage("Growth Data ID is required.")
                .Must(x => x != Guid.Empty).WithMessage("Growth Data ID must be a valid GUID.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(100).WithMessage("Title must not exceed 100 characters.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");

            RuleFor(x => x.RecommendedStartWeek)
                .InclusiveBetween(1, 40).WithMessage("Recommended start week must be between 1 and 40.");

            RuleFor(x => x.RecommendedEndWeek)
                .InclusiveBetween(1, 40).WithMessage("Recommended end week must be between 1 and 40.")
                .GreaterThanOrEqualTo(x => x.RecommendedStartWeek)
                .WithMessage("Recommended end week must be greater than or equal to start week.");

            RuleFor(x => x.Type)
                .NotEmpty().WithMessage("Type is required.");

            RuleFor(x => x.Note)
                .Length(0, 500).WithMessage("Note must not exceed 500 characters.");

        }
    }
}
