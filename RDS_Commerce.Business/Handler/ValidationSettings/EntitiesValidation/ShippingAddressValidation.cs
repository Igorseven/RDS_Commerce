using FluentValidation;
using RDS_Commerce.Business.Extensions;
using RDS_Commerce.Domain.Entities;
using RDS_Commerce.Domain.Enums;

namespace RDS_Commerce.Business.Handler.ValidationSettings.EntitiesValidation;
public sealed class ShippingAddressValidation : Validate<ShippingAddress>
{
	public ShippingAddressValidation()
	{
		SetRules();
	}

	private void SetRules()
	{
        RuleFor(sa => sa.Street).Length(3, 100)
            .WithMessage(sa => string.IsNullOrWhiteSpace(sa.Street)
            ? EMessage.Required.GetDescription().FormatTo("Rua")
            : EMessage.MoreExpected.GetDescription().FormatTo("Rua", "entre {MinLength} e {MaxLength}"));

        RuleFor(sa => sa.District).Length(3, 70)
            .WithMessage(sa => string.IsNullOrWhiteSpace(sa.District)
           ? EMessage.Required.GetDescription().FormatTo("Bairro")
           : EMessage.MoreExpected.GetDescription().FormatTo("Bairro", "entre {MinLength} e {MaxLength}"));

        RuleFor(sa => sa.City).Length(3, 70)
            .WithMessage(sa => string.IsNullOrWhiteSpace(sa.City)
           ? EMessage.Required.GetDescription().FormatTo("Cidade")
           : EMessage.MoreExpected.GetDescription().FormatTo("Cidade", "entre {MinLength} e {MaxLength}"));

        RuleFor(sa => sa.State).Length(2)
            .WithMessage(sa => string.IsNullOrWhiteSpace(sa.State)
           ? EMessage.Required.GetDescription().FormatTo("UF")
           : EMessage.MoreExpected.GetDescription().FormatTo("UF", "2"));

        RuleFor(sa => sa.Country).Length(3, 50)
            .WithMessage(sa => string.IsNullOrWhiteSpace(sa.Country)
           ? EMessage.Required.GetDescription().FormatTo("País")
           : EMessage.MoreExpected.GetDescription().FormatTo("País", "entre {MinLength} e {MaxLength}"));

        RuleFor(sa => sa.ZipCode).Length(8, 10)
            .WithMessage(sa => string.IsNullOrWhiteSpace(sa.ZipCode)
           ? EMessage.Required.GetDescription().FormatTo("CEP")
           : EMessage.MoreExpected.GetDescription().FormatTo("CEP", "entre {MinLength} e {MaxLength}"));

        RuleFor(sa => sa.Number).Length(1, 10)
            .WithMessage(sa => string.IsNullOrWhiteSpace(sa.Number)
           ? EMessage.Required.GetDescription().FormatTo("Número")
           : EMessage.MoreExpected.GetDescription().FormatTo("Número", "entre {MinLength} e {MaxLength}"));

        When(a => !string.IsNullOrEmpty(a.Complement), () =>
        {
            RuleFor(sa => sa.Complement).Length(1, 100)
            .WithMessage(sa => string.IsNullOrWhiteSpace(sa.Complement)
                ? EMessage.Required.GetDescription().FormatTo("Complemento")
                : EMessage.MoreExpected.GetDescription().FormatTo("Complemento", "entre {MinLength} e {MaxLength}"));
        });
    }
}
