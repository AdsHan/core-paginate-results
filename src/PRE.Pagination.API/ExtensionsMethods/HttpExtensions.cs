using Coezzion.Common.Pagination;
using Newtonsoft.Json;

namespace PRE.Pagination.API.ExtensionsMethods;

public static class HttpExtensions
{
    public static void AddPagination<T>(this HttpResponse response, object result)
    {
        var pagedList = (PagedList<T>)result;

        var metadata = new
        {
            pagedList.TotalCount,
            pagedList.PageSize,
            pagedList.CurrentPage,
            pagedList.TotalPages,
            pagedList.HasNext,
            pagedList.HasPrevious
        };

        response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
    }
}
