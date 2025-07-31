using FluentValidation;
using UserScheduleAPI.API.DTOs;

namespace UserScheduleAPI.API.Validators
{
    public class UpdateUserDtoValidator : AbstractValidator<UpdateUserDto>
    {
        public UpdateUserDtoValidator() 
        {
            RuleFor(x => x.FirstName)
                .Matches(@"^[a-zA-Z]+$")
                .MaximumLength(20)
                .When(x => !string.IsNullOrEmpty(x.FirstName));
            RuleFor(x => x.LastName)
                .Matches(@"^[a-zA-Z]+$")
                .MaximumLength(20)
                .When(x => !string.IsNullOrEmpty(x.LastName));
            RuleFor(x => x.Address)
                .MaximumLength(100)
                .When(x => !string.IsNullOrEmpty(x.Address));
            RuleFor(x => x.Age)
                .InclusiveBetween(0, 120)
                .When(x => x.Age.HasValue);

        }
    }
}
