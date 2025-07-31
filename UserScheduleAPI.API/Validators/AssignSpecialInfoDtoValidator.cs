using FluentValidation;
using UserScheduleAPI.API.DTOs;

namespace UserScheduleAPI.API.Validators
{
    public class AssignSpecialInfoDtoValidator : AbstractValidator<AssignSpecialInfoDto>
    {
        public AssignSpecialInfoDtoValidator() 
        {
            RuleFor(x => x.SpecialInfoId)
                .NotNull()
                .GreaterThan(0).WithMessage("SpecialInfoId must be greater than 0");
        }
    }
}
