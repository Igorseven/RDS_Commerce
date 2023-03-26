using FluentValidation;
using RDS_Commerce.Business.Extensions;
using RDS_Commerce.Domain.Entities;
using RDS_Commerce.Domain.Enums;

namespace RDS_Commerce.Business.Handler.ValidationSettings.EntitiesValidation;
public sealed class ManagerValidation : Validate<Manager>
{
	public ManagerValidation()
	{
		SetRules();
	}

	private void SetRules()
	{
        RuleFor(m => m.AccountIdentity).SetValidator(new AccountIdentityValidation());

        RuleFor(m => m.FullName).Length(3, 150)
            .WithMessage(p => string.IsNullOrWhiteSpace(p.FullName)
            ? EMessage.Required.GetDescription().FormatTo("Nome")
            : EMessage.MoreExpected.GetDescription().FormatTo("Nome", "entre {MinLength} e {MaxLength}"));

        RuleFor(m => m.Role).IsInEnum().WithMessage(EMessage.Required.GetDescription().FormatTo("Permissão"));
    }
}
