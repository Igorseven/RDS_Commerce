using FluentValidation;
using RDS_Commerce.Business.Extensions;
using RDS_Commerce.Domain.Entities;
using RDS_Commerce.Domain.Enums;

namespace RDS_Commerce.Business.Handler.ValidationSettings.EntitiesValidation;
public sealed class GenusValidation : Validate<Genus>
{
	public GenusValidation()
	{
		SetRules();
	}

	private void SetRules()
	{
        RuleFor(p => p.GenusName).Length(2, 80)
            .WithMessage(p => string.IsNullOrWhiteSpace(p.GenusName)
            ? EMessage.Required.GetDescription().FormatTo("Nome do Gênero")
            : EMessage.MoreExpected.GetDescription().FormatTo("Nome do Gênero", "entre {MinLength} e {MaxLength}"));

        RuleFor(p => p.Specie).Length(2, 80)
			.WithMessage(p => string.IsNullOrWhiteSpace(p.Specie)
			? EMessage.Required.GetDescription().FormatTo("Espécie")
			: EMessage.MoreExpected.GetDescription().FormatTo("espécie", "entre {MinLength} e {MaxLength}"));
    }
}
