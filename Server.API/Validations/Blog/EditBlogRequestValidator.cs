using FluentValidation;
using Server.Application.Abstractions.RequestAndResponse.Blog;

namespace Server.API.Validations.Blog
{
    public class EditBlogRequestValidator : AbstractValidator<EditBlogRequest>
    {
        private readonly long _maxFileSize = 5 * 1024 * 1024; // 5MB
        private readonly string[] _allowedExtensions =
            { ".jpg", ".jpeg", ".png", ".webp" };

        public EditBlogRequestValidator()
        {
            RuleFor(x => x.Title)
                .MaximumLength(100).WithMessage("Title must not exceed 100 characters.");

            RuleFor(x => x.Body)
                .MaximumLength(500).WithMessage("Body must not exceed 500 characters.");

            RuleFor(x => x.Tags)
                .Must(tags => tags == null || tags.Count <= 10)
                .WithMessage("Maximum 10 tags allowed");

            RuleFor(x => x.Images)
                .Must(images => images == null || images.Count <= 4)
                .WithMessage("Maximum 4 images allowed");

            // Validate each individual file in the Images list
            RuleForEach(x => x.Images)
                .Must(BeAValidFile)
                .WithMessage($"Each file must be one of the allowed types: {string.Join(", ", _allowedExtensions)} and less than 5MB.");
        }

        private bool BeAValidFile(IFormFile file)
        {
            if (file == null)
                return false;

            var fileExtension = Path.GetExtension(file.FileName).ToLower();
            if (!_allowedExtensions.Contains(fileExtension))
                return false;

            if (file.Length > _maxFileSize)
                return false;

            return true;
        }
    }
}
