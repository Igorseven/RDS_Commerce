using RDS_Commerce.Business.Extensions;

namespace RDS_Commerce.Business.Handler.ValidationSettings.ValidationTools;
public class CnpjValidation
{
    public const int CNPJSize = 14;

    public static bool Validate(string cnpj)
    {
        var cnpjNumeros = cnpj.RemoveCaracters();

        if (!HaslengthValid(cnpjNumeros))
            return false;

        return !HasRepeatedDigits(cnpjNumeros) && HasValidDigits(cnpjNumeros);
    }

    private static bool HaslengthValid(string valor)
    {
        return valor.Length == CNPJSize;
    }

    private static bool HasRepeatedDigits(string valor)
    {
        string[] invalidNumbers =
        {
                "00000000000000",
                "11111111111111",
                "22222222222222",
                "33333333333333",
                "44444444444444",
                "55555555555555",
                "66666666666666",
                "77777777777777",
                "88888888888888",
                "99999999999999"
            };
        return invalidNumbers.Contains(valor);
    }

    private static bool HasValidDigits(string value)
    {
        var number = value[..(CNPJSize - 2)];

        var digitChecker = new DigitChecker(number)
            .WithMultipliersUpTo(2, 9)
            .Replacing("0", 10, 11);
        var firstDigit = digitChecker.CalculeteDigit();
        digitChecker.AddDigit(firstDigit);
        var secondDigit = digitChecker.CalculeteDigit();

        return string.Concat(firstDigit, secondDigit) == value.Substring(CNPJSize - 2, 2);
    }
}