using FluentValidation;
using UserScheduleAPI.API.DTOs;

namespace UserScheduleAPI.API.Validators
{
    public class CreateShiftDtoValidator : AbstractValidator<CreateShiftDto>
    {
        public CreateShiftDtoValidator() 
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserId is required");
            RuleFor(x => x.StartTime)
                .NotNull().WithMessage("Start time is required.");
            RuleFor(x => x.EndTime)
                .NotNull().WithMessage("End time is required.")
                .GreaterThan(x => x.StartTime)
                .WithMessage("End time must be later than start time.");
            RuleFor(x => x.Date)
                .NotNull().WithMessage("You need to insert Date");
            RuleFor(x => x.Notes)
                .MaximumLength(200)
                .WithMessage("Notes cannot exceed 200 characters");
        }
    }
}
