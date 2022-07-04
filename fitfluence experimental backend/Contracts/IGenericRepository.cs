using fitfluence_experimental_backend.Models;
using HotelListing.API.Core.Models;

namespace fitfluence_experimental_backend.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(int? id);
        Task<TResult> GetAsync<TResult>(int? id);
        Task<List<T>> GetAllAsync();
        Task<List<TResult>> GetAllAsync<TResult>();
        Task<PagedResult<TResult>> GetAllAsync<TResult>(QueryParameters queryParameters);
        Task<T> AddAsync(T entity);
        Task<TResult> AddAsync<TSource, TResult>(TSource entity);
        Task DeleteAsync(int id);
        Task UpdateAsync(T entity);
        Task UpdateAsync<TSource>(int id, TSource source) where TSource : IBaseDto;
        Task<bool> Exists(int id);
    }
}
