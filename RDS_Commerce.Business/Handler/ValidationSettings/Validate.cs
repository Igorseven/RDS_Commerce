using FluentValidation;
using FluentValidation.Results;
using RDS_Commerce.Business.Extensions;
using RDS_Commerce.Business.Interfaces.OthersContracts;

namespace RDS_Commerce.Business.Handler.ValidationSettings;
public abstract class Validate<T> : AbstractValidator<T>, IValidate<T> where T : class
{
    private ValidationResult _validationResult { get; set; }



    private Dictionary<string, string> GetErros() => _validationResult.Errors.ToDictionary();

    private async Task CreateResultAsync(T entity)  => _validationResult = await base.ValidateAsync(entity);

    public async Task<ValidationResponse> ValidationAsync(T entity)
    {
        await CreateResultAsync(entity);
        return ValidationResponse.CreateResponse(GetErros());
    }
}
