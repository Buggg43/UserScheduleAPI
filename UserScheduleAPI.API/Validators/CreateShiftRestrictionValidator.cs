using FluentValidation;
using UserScheduleAPI.API.DTOs;

namespace UserScheduleAPI.API.Validators
{
    public class CreateShiftRestrictionValidator : AbstractValidator<CreateShiftRestrictionDto>
    {
        public CreateShiftRestrictionValidator() 
        {
            RuleFor(x => x.StartTime)
                .NotNull().WithMessage("You need to insert time");
            RuleFor(x => x.EndTime)
                .NotNull().WithMessage("You need to insert time");
            RuleFor(x => x.Reason)
                .MaximumLength(200);
        }
    }
}
