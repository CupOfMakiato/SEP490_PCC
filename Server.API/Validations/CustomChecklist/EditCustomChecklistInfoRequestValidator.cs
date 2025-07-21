using FluentValidation;
using Server.Application.Abstractions.RequestAndResponse.CustomChecklist;

namespace Server.API.Validations.CustomChecklist
{
    public class EditCustomChecklistInfoRequestValidator : AbstractValidator<EditCustomChecklistInfoRequest>
    {
        public EditCustomChecklistInfoRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("ID is required.")
                .Must(x => x != Guid.Empty).WithMessage("ID must be a valid GUID.");
            RuleFor(x => x.TaskName)
                .MaximumLength(100).WithMessage("Task name must not exceed 100 characters.");
            RuleFor(x => x.Trimester)
                .InclusiveBetween(1, 3).WithMessage("Trimester must be between 1 and 3.");
        }
    }
}
