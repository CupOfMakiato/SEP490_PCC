using FluentValidation;
using Server.Application.Abstractions.RequestAndResponse.CustomChecklist;

namespace Server.API.Validations.CustomChecklist
{
    public class CreateNewCustomChecklistRequestValidator : AbstractValidator<CreateNewCustomChecklistRequest>
    {
        public CreateNewCustomChecklistRequestValidator()
        {
            RuleFor(x => x.GrowthDataId)
                .NotEmpty().WithMessage("Growth Data ID is required.")
                .Must(x => x != Guid.Empty).WithMessage("Growth Data ID must be a valid GUID.");
            RuleFor(x => x.TaskName)
                .NotEmpty().WithMessage("Task name is required.")
                .MaximumLength(100).WithMessage("Task name must not exceed 100 characters.");
            RuleFor(x => x.Trimester)
                .InclusiveBetween(1, 3).WithMessage("Trimester must be between 1 and 3.");
        }
    }
}
