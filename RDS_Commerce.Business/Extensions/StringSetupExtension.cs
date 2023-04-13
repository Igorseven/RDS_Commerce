using System.Text.RegularExpressions;

namespace RDS_Commerce.Business.Extensions;
public static class StringSetupExtension
{
    public static string RemoveCaracters(this string value)
    {
        if (!string.IsNullOrWhiteSpace(value))
            return Regex.Replace(value, @"[^0-9]+", "");
        else
            return string.Empty;
    }

    public static string RemoveAlphaNumeric(this string value)
    {
        if (!string.IsNullOrWhiteSpace(value))
            return Regex.Replace(value, @"[^0-9a-zA-Z]+", "");
        else
            return string.Empty;
    }

    public static string XmlSafeString(this string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return string.Empty;

        return value
            .Replace("&", "&amp;")
            .Replace("<", "&lt;")
            .Replace(">", "&gt;")
            .Replace("\"", "&quot;")
            .Replace("'", "&apos;");
    }

}
