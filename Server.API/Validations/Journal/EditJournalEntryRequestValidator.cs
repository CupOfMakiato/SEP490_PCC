using FluentValidation;
using Server.Application.Abstractions.RequestAndResponse.Journal;

namespace Server.API.Validations.Journal
{
    public class EditJournalEntryRequestValidator : AbstractValidator<EditJournalEntryRequest>
    {
        private readonly long _maxFileSize = 5 * 1024 * 1024; // 5MB
        private readonly string[] _allowedExtensions =
            { ".jpg", ".jpeg", ".png", ".webp" };
        public EditJournalEntryRequestValidator()
        {
            RuleFor(x => x.Note)
                .NotEmpty().WithMessage("Note is required.")
                .MaximumLength(500).WithMessage("Note cannot exceed 500 characters.");
            RuleFor(x => x.CurrentWeight)
                .NotEmpty().WithMessage("Current weight is required.")
                .GreaterThan(0).WithMessage("Current weight must be greater than 0.");
            RuleFor(x => x.SymptomNames)
                .NotEmpty().WithMessage("SymptomNames are required.");
            RuleFor(x => x.MoodNotes)
                .NotEmpty().WithMessage("Mood notes are required.");

            RuleFor(x => x.RelatedImages)
                .Must(images => images == null || images.Count <= 2)
                .WithMessage("Maximum 2 images allowed");
            RuleFor(x => x.UltraSoundImages)
                .Must(images => images == null || images.Count <= 2)
                .WithMessage("Maximum 2 images allowed");

            // Validate each individual file in the Images list
            RuleForEach(x => x.RelatedImages)
                .Must(BeAValidFile)
                .WithMessage($"Each file must be one of the allowed types: {string.Join(", ", _allowedExtensions)} and less than 5MB.");

            // Validate each individual file in the Images list
            RuleForEach(x => x.UltraSoundImages)
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
