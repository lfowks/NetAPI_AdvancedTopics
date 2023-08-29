using Domain;
using FluentValidation;

namespace RepositoryPattern.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Password).MinimumLength(5);
            //RuleFor(x => x.Surname).NotEmpty();
            //RuleFor(x => x.Forename).NotEmpty().WithMessage("Please specify a first name");
            //RuleFor(x => x.Discount).NotEqual(0).When(x => x.HasDiscount);
            //RuleFor(x => x.Address).Length(20, 250);
            //RuleFor(x => x.Postcode).Must(BeAValidPostcode).WithMessage("Please specify a valid postcode");
        }
    }
}
