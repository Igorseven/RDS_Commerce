using FluentValidation;
using RDS_Commerce.Business.Extensions;
using RDS_Commerce.Domain.Entities;
using RDS_Commerce.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS_Commerce.Business.Handler.ValidationSettings.EntitiesValidation;
public sealed class ClientValidation : Validate<Client>
{
	public ClientValidation()
	{
		SetRules();
	}

	private void SetRules()
	{
        RuleFor(c => c.FullName).Length(3, 500)
            .WithMessage(p => string.IsNullOrWhiteSpace(p.FullName)
            ? EMessage.Required.GetDescription().FormatTo("Nome")
            : EMessage.MoreExpected.GetDescription().FormatTo("Nome", "entre {MinLength} e {MaxLength}"));

        RuleFor(c => c.Role).IsInEnum().WithMessage(EMessage.Required.GetDescription().FormatTo("Permissão"));
    }
}
