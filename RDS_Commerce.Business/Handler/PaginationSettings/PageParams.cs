namespace RDS_Commerce.Business.Handler.PaginationSettings;
public class PageParams
{
    private const int MaxPageSize = 10;
    private int _pageNumber = 1;
    public int PageNumber
    {
        get => _pageNumber;
        set => _pageNumber = value <= 0 ? _pageNumber : value;
    }

    private int _pageSize = 10;
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
    }
}
