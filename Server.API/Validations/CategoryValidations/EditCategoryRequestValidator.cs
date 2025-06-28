using FluentValidation;
using Server.Application.Abstractions.RequestAndResponse.Category;

namespace Server.API.Validations.CategoryValidations
{
    public class EditCategoryRequestValidator : AbstractValidator<EditCategoryRequest>
    {
        public EditCategoryRequestValidator()
        {
            //RuleFor(x => x.UserId).NotEmpty().WithMessage("User ID is required.");
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Category name is required.")
                .MaximumLength(100).WithMessage("Category name cannot exceed 100 characters.");
            RuleFor(x => x.IsActive).NotNull().WithMessage("IsActive status is required.");
        }
    }
}
