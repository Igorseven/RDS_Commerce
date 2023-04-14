using FluentValidation;
using RDS_Commerce.Business.Extensions;
using RDS_Commerce.Business.Handler.ValidationSettings.ValidationTools;
using RDS_Commerce.Domain.Entities;
using RDS_Commerce.Domain.Enums;

namespace RDS_Commerce.Business.Handler.ValidationSettings.EntitiesValidation;
public sealed class ClientValidation : Validate<Client>
{
	public ClientValidation()
	{
		SetRules();
	}

	private void SetRules()
	{
        RuleFor(c => c.AccountIdentity).SetValidator(new AccountIdentityValidation());

        RuleFor(c => c.FullName).Length(3, 150)
            .WithMessage(p => string.IsNullOrWhiteSpace(p.FullName)
            ? EMessage.Required.GetDescription().FormatTo("Nome")
            : EMessage.MoreExpected.GetDescription().FormatTo("Nome", "entre {MinLength} e {MaxLength}"));
        
        RuleFor(c => CpfValidation.Validate(c.DocumentNumber)).Equal(true).WithMessage("Valor logico do cpf está inválido.");
            

        RuleFor(c => c.Role).IsInEnum().WithMessage(EMessage.Required.GetDescription().FormatTo("Permissão"));

        RuleFor(c => c.AcceptTermsAndPolicy).Equal(true).WithMessage(EMessage.Required.GetDescription().FormatTo("Aceite dos termos e politicas."));
    }
}
