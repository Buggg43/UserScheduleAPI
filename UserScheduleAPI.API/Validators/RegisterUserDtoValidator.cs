using FluentValidation;
using UserScheduleAPI.API.DTOs;

namespace UserScheduleAPI.API.Validators
{
    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserDtoValidator() 
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required")
                .MaximumLength(50)
                .Matches(@"^[a-zA-Z]+$");
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required")
                .MaximumLength(50);
            RuleFor(x => x.Address)
                .MaximumLength(100);
            RuleFor(x => x.Age)
                .InclusiveBetween(0, 120)
                .When(x => x.Age.HasValue);
        }
    }   
}
