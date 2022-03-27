using Domain.Core.Entities;
using FluentValidation;

namespace GB__U_SaveDev.Validations
{
    public class BankCardValidator : AbstractValidator<BankCard>
    {
        public BankCardValidator()
        {
            RuleFor(v => v.UserName)
                .NotEmpty().WithMessage("Empty user name")
                .Length(2, 10).WithMessage("Wrong user name");
            RuleFor(t => t.CardNumber)
                .NotEmpty()
                .GreaterThan(1000);
        }
    }
}
