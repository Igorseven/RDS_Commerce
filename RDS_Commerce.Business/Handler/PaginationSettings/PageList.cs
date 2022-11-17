namespace RDS_Commerce.Business.Handler.PaginationSettings;
public sealed class PageList<T> where T : class
{
    public List<T> Result { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }

    public PageList() { }

    public PageList(List<T> items, int count, int pageNumber, int pageSize)
    {
        Result = items;
        TotalCount = count;
        PageSize = pageSize;
        CurrentPage = pageNumber;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
    }
}
