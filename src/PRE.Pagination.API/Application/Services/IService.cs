namespace PRE.Pagination.API.Application.Services;

public interface IService<T> : IDisposable where T : class
{
    Task<List<T>> GetAllAsync();
}
