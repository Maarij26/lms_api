using FluentValidation;
using LibraryManagementSystemAPI.DTOs;

namespace LibraryManagementSystemAPI.Validators
{
    public class CreateBookValidator : AbstractValidator<CreateBookDTo>
    {
        public CreateBookValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title cannot be empty")
                .MinimumLength(2).WithMessage("Title too short")
                .MaximumLength(200).WithMessage("Title too long");

            RuleFor(x => x.ISBN)
                .NotEmpty().WithMessage("ISBN cannot be empty")
                .Length(10, 13).WithMessage("ISBN must be 10 to 13 characters");

            RuleFor(x => x.PublicationYear)
                .InclusiveBetween(1000, DateTime.UtcNow.Year)
                .WithMessage($"Publication year must be between 1000 and {DateTime.UtcNow.Year}");

            RuleFor(x => x.AuthorId)
                .GreaterThan(0).WithMessage("A valid AuthorId is required");
        }
    }
}