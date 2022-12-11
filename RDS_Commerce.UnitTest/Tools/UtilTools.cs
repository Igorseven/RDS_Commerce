using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Query;
using Moq;
using RDS_Commerce.Business.Handler.PaginationSettings;
using System.Linq.Expressions;
using System.Security.Claims;
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

    public static PageList<T> BuildPageList<T>(List<T> entityList, int nextPage = 1) where T : class
    {
        return new PageList<T>
        {
            CurrentPage = nextPage,
            PageSize = 10,
            Result = entityList,
            TotalCount = entityList.Count,
            TotalPages = 1
        };
    }

    public static PageParams BuildPageParams(int pageNumber = 1, int pageSize = 10)
    {
        return new PageParams
        {
            PageNumber = pageNumber,
            PageSize = pageSize,
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

    public static Func<IQueryable<T>, IIncludableQueryable<T, object>> BuildQueryableIncludeFunc<T>() where T : class =>
           It.IsAny<Func<IQueryable<T>, IIncludableQueryable<T, object>>>();
    
    public static Expression<Func<T, bool>> BuildPredicateFunc<T>() where T : class =>
           It.IsAny<Expression<Func<T, bool>>>();
}
