using FluentValidation;
using UserScheduleAPI.API.DTOs;

namespace UserScheduleAPI.API.Validators
{
    public class UpdateShiftRestrictionDtoValidator : AbstractValidator<UpdateShiftRestrictionDto>
    {
        public UpdateShiftRestrictionDtoValidator()
        {
            RuleFor(x => x.StartTime)
                .LessThan(x => x.EndTime)
                .When(x => x.StartTime.HasValue && x.EndTime.HasValue)
                .WithMessage("Start time must be earlier than end time");
            RuleFor(x => x.Reason)
                .MaximumLength(200)
                .When(x => !string.IsNullOrEmpty(x.Reason)); ;
        }
    }
}
