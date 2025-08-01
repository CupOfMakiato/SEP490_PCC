using FluentValidation;
using Server.Application.Abstractions.RequestAndResponse.CheckupReminder;

namespace Server.API.Validations.CheckupReminder
{
    public class EditTailoredCheckupReminderRequestValidator : AbstractValidator<EditTailoredCheckupReminderRequest>
    {
        public EditTailoredCheckupReminderRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("ID is required.")
                .Must(x => x != Guid.Empty).WithMessage("Id must be a valid GUID.");

            RuleFor(x => x.Title)
                .MaximumLength(100).WithMessage("Title must not exceed 100 characters.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");

            RuleFor(x => x.RecommendedStartWeek)
                .InclusiveBetween(1, 40).WithMessage("Recommended start week must be between 1 and 40.");

            RuleFor(x => x.RecommendedEndWeek)
                .InclusiveBetween(1, 40).WithMessage("Recommended end week must be between 1 and 40.")
                .GreaterThanOrEqualTo(x => x.RecommendedStartWeek)
                .WithMessage("Recommended end week must be greater than or equal to start week.");

            RuleFor(x => x.ScheduledDate)
                .Must(date => date >= DateTime.Now.Date)
                .WithMessage("Scheduled date must not be in the past!");


            RuleFor(x => x.Note)
                .Length(0, 500).WithMessage("Note must not exceed 500 characters.");

        }
    }
}
