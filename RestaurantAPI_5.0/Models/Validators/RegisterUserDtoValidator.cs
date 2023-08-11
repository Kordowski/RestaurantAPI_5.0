using FluentValidation;
using RestaurantAPI_5._0.Entities;
using System.Linq;

namespace RestaurantAPI_5._0.Models.Validators
{
    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserDtoValidator(RestaurantDbContext dbContext)
        {
            RuleFor(x=> x.Email)
                .NotEmpty()
                .EmailAddress();
            RuleFor(x=> x.Password)
                .MinimumLength(6)
                .NotEmpty();
            RuleFor(x=>x.ConfirmPassword).Equal(e=> e.Password);

            RuleFor(x => x.Email)
                .Custom((value, context) =>
                {
                    var emailInUse = dbContext.Users.Any(u => u.Email == value);
                    if (emailInUse)
                    {
                        context.AddFailure("Email", "Email is taken");
                    }
                });
        }
    }
}
