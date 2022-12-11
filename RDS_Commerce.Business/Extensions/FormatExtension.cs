using Microsoft.AspNetCore.Http;
using RDS_Commerce.Domain.Entities;

namespace RDS_Commerce.Business.Extensions;
public static class FormatExtension
{
    public static string FormatTo(this string message, params object[] args)
    {
        return string.Format(message, args);
    }
}
