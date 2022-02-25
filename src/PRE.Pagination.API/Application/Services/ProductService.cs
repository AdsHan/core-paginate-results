using AspNetCore.IQueryable.Extensions;
using Coezzion.Common.Pagination;
using Microsoft.EntityFrameworkCore;
using PRE.Pagination.API.Application.InputModels;
using PRE.Pagination.API.Data;
using PRE.Pagination.API.Data.Entities;

namespace PRE.Pagination.API.Application.Services;

public class ProductService : IProductService
{
    private readonly CatalogDbContext _dbContext;

    public ProductService(CatalogDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<List<ProductModel>> GetAllAsync()
    {
        return _dbContext.Products.AsNoTracking().OrderBy(x => x.Price).ToListAsync();
    }

    public async Task<PagedList<ProductModel>> GetAllPagedAsync(FindAllListInputModel query)
    {
        return PagedList<ProductModel>.ToPagedList(_dbContext.Products.AsNoTracking().OrderBy(on => on.Price), query.PageNumber, query.PageSize);
    }

    public Task<List<ProductModel>> GetAllQueryableAsync(FindAllQueryableInputModel query)
    {
        //return _dbContext.Products.AsQueryable().Filter(query).Paginate(query).Sort(query).ToListAsync();
        return _dbContext.Products.AsNoTracking().Apply(query).ToListAsync();
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }

}