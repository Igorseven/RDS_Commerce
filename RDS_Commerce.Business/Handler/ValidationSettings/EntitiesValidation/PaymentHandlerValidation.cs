using FluentValidation;
using RDS_Commerce.Business.Extensions;
using RDS_Commerce.Domain.Entities;
using RDS_Commerce.Domain.Enums;

namespace RDS_Commerce.Business.Handler.ValidationSettings.EntitiesValidation;
public sealed class PaymentHandlerValidation : Validate<PaymentHandler>
{
	public PaymentHandlerValidation()
	{
		SetRules();
	}

	private void SetRules()
	{
        RuleFor(ph => ph.PaymentDescription).NotEmpty().Length(3, 100)
           .WithMessage(a => !string.IsNullOrWhiteSpace(a.PaymentDescription)
           ? EMessage.MoreExpected.GetDescription().FormatTo("Descrição do pagamento", "entre {MinLength} e {MaxLength}")
           : EMessage.Required.GetDescription().FormatTo("Descrição do pagamento"));


         RuleFor(ph => ph.PixKey).NotEmpty().Length(3, 250)
           .WithMessage(a => !string.IsNullOrWhiteSpace(a.PixKey)
           ? EMessage.MoreExpected.GetDescription().FormatTo("Chave Pix", "entre {MinLength} e {MaxLength}")
           : EMessage.Required.GetDescription().FormatTo("Chave Pix"));

        When(ph => ph.Discount is not null, () =>
        {
            RuleFor(ph => ph.Discount).GreaterThanOrEqualTo(0)
                .WithMessage(EMessage.ValueExpected.GetDescription().FormatTo("Desconto", "0"));

        });
    }
}
