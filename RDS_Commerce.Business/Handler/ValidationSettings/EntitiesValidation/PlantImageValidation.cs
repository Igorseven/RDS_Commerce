using FluentValidation;
using RDS_Commerce.Business.Extensions;
using RDS_Commerce.Domain.Entities;
using RDS_Commerce.Domain.Enums;

namespace RDS_Commerce.Business.Handler.ValidationSettings.EntitiesValidation;
public sealed class PlantImageValidation : Validate<PlantImage>
{
	public PlantImageValidation()
	{
		SetRules();
	}

	private void SetRules()
	{
        RuleFor(p => p.FileName).Length(2, 40)
            .WithMessage(p => string.IsNullOrWhiteSpace(p.FileName)
            ? EMessage.Required.GetDescription().FormatTo("Nome do arquivo")
            : EMessage.MoreExpected.GetDescription().FormatTo("nome do arquivo", "entre {MinLength} e {MaxLength}"));

        RuleFor(p => p.FileExtension).Length(2, 10)
            .WithMessage(p => string.IsNullOrWhiteSpace(p.FileExtension)
            ? EMessage.Required.GetDescription().FormatTo("Extensão do arquivo")
            : EMessage.MoreExpected.GetDescription().FormatTo("extensão do arquivo", "entre {MinLength} e {MaxLength}"));
    }
}
