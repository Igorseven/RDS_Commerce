using System.Text.RegularExpressions;

namespace RDS_Commerce.Business.Extensions;
public static class PasswordExtension
{
    public static bool ValidatePassword(this string password)
    {
        var regex = new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,20}$");
        var match = regex.Match(password);
        return match.Success;
    }
}
