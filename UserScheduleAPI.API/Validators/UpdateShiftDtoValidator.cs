using FluentValidation;
using UserScheduleAPI.API.DTOs;

namespace UserScheduleAPI.API.Validators
{
    public class UpdateShiftDtoValidator : AbstractValidator<UpdateShiftDto>
    {
        public UpdateShiftDtoValidator()
        {
            RuleFor(x => x.StartTime)
                .LessThan(x => x.EndTime!.Value)
                .When(x => x.StartTime.HasValue && x.EndTime.HasValue)
                .WithMessage("Start time must be earlier than end time");

            RuleFor(x => x.Notes)
                .MaximumLength(200)
                .When(x => !string.IsNullOrEmpty(x.Notes));
        }
    }
}
