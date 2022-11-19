using FluentValidation.Results;

namespace RDS_Commerce.Business.Extensions;
public static class ValidationExtension
{
    public static Dictionary<string, string> ToDictionary(this IList<ValidationFailure> errors)
    {
        var result = new Dictionary<string, string>();

        foreach (var error in errors)
        {
            if (!result.ContainsKey(error.PropertyName))
                result.Add(error.PropertyName, error.ErrorMessage);
        }

        return result;
    }
}
