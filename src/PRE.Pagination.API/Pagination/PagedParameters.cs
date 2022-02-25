namespace Coezzion.Common.Pagination;

public abstract class PagedParameters
{
    private const int MaxPageSize = 100;
    private int _pageSize = 50;

    public int PageNumber { get; set; } = 1;

    public int PageSize
    {
        get { return _pageSize; }
        set { _pageSize = (int)((value > MaxPageSize) ? MaxPageSize : value); }
    }

}
