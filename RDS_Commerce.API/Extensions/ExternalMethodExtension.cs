namespace RDS_Commerce.API.Extensions;

public static class ExternalMethodExtension
{
    public static bool IsMethodGet(dynamic context) => context.HttpContext.Request.Method == HttpMethod.Get;
}
