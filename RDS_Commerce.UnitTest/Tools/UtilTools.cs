using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Query;
using RDS_Commerce.Business.Handler.PaginationSettings;
using System.Security.Claims;
using Moq;
using System.Text;

namespace RDS_Commerce.UnitTest.Tools;
public sealed class UtilTools
{
    public static IFormFile BuildIFormFile(string extension = "pdf")
    {
        var bytes = Encoding.UTF8.GetBytes("This is a dummy file");

        return new FormFile(new MemoryStream(bytes), 0, bytes.Length, "Data", $"image.{extension}")
        {
            Headers = new HeaderDictionary(),
            ContentType = "image/jpeg",
            ContentDisposition = $"form-data; name=\"Image\"; filename=\"image.{extension}\""
        };
    }

    public static PageList<TEntity> BuildPageList<TEntity>(List<TEntity> entityList, int nextPage = 1) where TEntity : class
    {
        return new PageList<TEntity>
        {
            CurrentPage = nextPage,
            PageSize = 10,
            Result = entityList,
            TotalCount = entityList.Count,
            TotalPages = 1
        };
    }

    public static ClaimsPrincipal BuildClaimPrincipal(string name, Guid userId, string actor)
    {
        return new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
                new (ClaimTypes.Name, name),
                new (ClaimTypes.NameIdentifier, userId.ToString()),
                new (ClaimTypes.Actor, actor),
        }));
    }

    public static Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> BuildQueryableIncludeFunc<TEntity>() where TEntity : class =>
           It.IsAny<Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>>();
}
