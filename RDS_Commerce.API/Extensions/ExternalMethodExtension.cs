namespace RDS_Commerce.API.Extensions;

public static class ExternalMethodExtension
{
    private const string METHOD_NAME = "GET";
    public static bool IsMethodGet(dynamic context) => context.HttpContext.Request.Method == METHOD_NAME;
}
