using Coezzion.Common.Pagination;
using PRE.Pagination.API.Application.InputModels;
using PRE.Pagination.API.Data.Entities;

namespace PRE.Pagination.API.Application.Services;

public interface IProductService : IService<ProductModel>
{
    Task<PagedList<ProductModel>> GetAllPagedAsync(FindAllListInputModel query);
    Task<List<ProductModel>> GetAllQueryableAsync(FindAllQueryableInputModel query);
}
