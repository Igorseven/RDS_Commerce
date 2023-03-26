using FluentValidation;
using RDS_Commerce.Business.Extensions;
using RDS_Commerce.Domain.Entities;
using RDS_Commerce.Domain.Enums;

namespace RDS_Commerce.Business.Handler.ValidationSettings.EntitiesValidation;
internal class AccountIdentityValidation : Validate<AccountIdentity>
{
    public AccountIdentityValidation()
    {
        SetRules();
    }

    private void SetRules()
    {
        RuleFor(a => a.UserName).EmailAddress()
            .WithMessage(a => !string.IsNullOrWhiteSpace(a.UserName)
            ? EMessage.MoreExpected.GetDescription().FormatTo("Login", "entre {MinLength} e {MaxLength}")
            : EMessage.Required.GetDescription().FormatTo("Login"));

        RuleFor(a => a.PasswordHash).Length(8, 20).Must(password => password.ValidatePassword())
            .WithMessage("Senha não atende as especificações");

        When(a => a.PhoneNumber is not null, () =>
        {
            RuleFor(a => a.PhoneNumber).NotEmpty().Length(8, 20)
                 .WithMessage(a => !string.IsNullOrWhiteSpace(a.PhoneNumber)
                 ? EMessage.MoreExpected.GetDescription().FormatTo("Cell phone", "entre {MinLength} e {MaxLength}")
                 : EMessage.Required.GetDescription().FormatTo("Cell phone"));
        });
    }


}
