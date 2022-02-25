using AspNetCore.IQueryable.Extensions.Pagination;
using AspNetCore.IQueryable.Extensions.Sort;

namespace PRE.Pagination.API.Application.InputModels;

public class FindAllQueryableInputModel : IQueryPaging, IQuerySort
{
    public FindAllQueryableInputModel() { }

    public int? Offset { get; set; }
    public int? Limit { get; set; } = 50;
    public string Sort { get; set; } = "Price";
}


