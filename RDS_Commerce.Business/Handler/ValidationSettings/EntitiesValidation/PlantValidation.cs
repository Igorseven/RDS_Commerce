using FluentValidation;
using RDS_Commerce.Business.Extensions;
using RDS_Commerce.Domain.Entities;
using RDS_Commerce.Domain.Enums;

namespace RDS_Commerce.Business.Handler.ValidationSettings.EntitiesValidation;
public sealed class PlantValidation : Validate<Plant>
{

    public PlantValidation()
    {
        SetRules();
    }

    private void SetRules()
    {
        RuleForEach(p => p.Images).SetValidator(new PlantImageValidation());


        When(p => !string.IsNullOrWhiteSpace(p.Description), () =>
        {
            RuleFor(p => p.Description).Length(3, 500)
                .WithMessage(p => string.IsNullOrWhiteSpace(p.Description)
                ? EMessage.Required.GetDescription().FormatTo("Descrição")
                : EMessage.MoreExpected.GetDescription().FormatTo("descrição", "entre {MinLength} e {MaxLength}"));
        });

        RuleFor(p => p.Name).Length(2, 60)
            .WithMessage(p => string.IsNullOrWhiteSpace(p.Name)
            ? EMessage.Required.GetDescription().FormatTo("Nome")
            : EMessage.MoreExpected.GetDescription().FormatTo("nome", "entre {MinLength} e {MaxLength}"));

        RuleFor(p => p.Specie).Length(2, 60)
            .WithMessage(p => string.IsNullOrWhiteSpace(p.Specie)
            ? EMessage.Required.GetDescription().FormatTo("Espécie")
            : EMessage.MoreExpected.GetDescription().FormatTo("espécie", "entre {MinLength} e {MaxLength}"));
        
        RuleFor(p => p.Amount).GreaterThanOrEqualTo(0)
            .WithMessage(EMessage.ValueExpected.GetDescription().FormatTo("Quantidade", " ou igual 0"));
        
        RuleFor(p => p.Price).GreaterThanOrEqualTo(0)
            .WithMessage(EMessage.ValueExpected.GetDescription().FormatTo("Preço", "0"));
        
        RuleFor(p => p.PlantType).NotNull()
            .WithMessage(EMessage.Required.GetDescription().FormatTo("Tipo do produto"));
            
    }
}
