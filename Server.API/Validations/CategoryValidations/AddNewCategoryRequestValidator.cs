using FluentValidation;
using Server.Application.Abstractions.RequestAndResponse.Category;

namespace Server.WebAPI.Validations.CategoryValidations
{
    public class AddNewCategoryRequestValidator : AbstractValidator<AddNewCategoryRequest>
    {
        public AddNewCategoryRequestValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.CategoryName).MaximumLength(100).WithMessage("Name must not exceed 100 characters");
        }
    }
}
