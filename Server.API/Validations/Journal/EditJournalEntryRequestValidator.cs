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
                .MaximumLength(500).WithMessage("Note cannot exceed 500 characters.");

            RuleFor(x => x.CurrentWeight)
                .InclusiveBetween(30, 250).WithMessage("Current weight must be greater than 0.");

            //RuleFor(x => x.SymptomNames)
            //    .NotEmpty().WithMessage("SymptomNames are required.");

            //RuleFor(x => x.MoodNotes)
            //    .NotEmpty().WithMessage("Mood notes are required.");

            RuleFor(x => x.SystolicBP)
                .InclusiveBetween(50, 250)
                .WithMessage("Systolic BP must be between 50 and 250 mmHg.");

            RuleFor(x => x.DiastolicBP)
                .InclusiveBetween(30, 150)
                .WithMessage("Diastolic BP must be between 30 and 150 mmHg.");

            RuleFor(x => x.HeartRateBPM)
                .InclusiveBetween(30, 200)
                .WithMessage("Heart Rate must be between 30 and 200 bpm.");

            RuleFor(x => x.BloodSugarLevelMgDl)
                .InclusiveBetween(30, 500)
                .WithMessage("Blood Sugar Level must be between 30 and 500 mg/dL.");


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
