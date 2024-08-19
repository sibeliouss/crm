using Core.Entities;
using Domain.Pages;

namespace Application.Repositories;

public interface IRepository<T> where T : class
{
    Task<T> CreateAsync(T entity);
    ValueTask<T?> LoadAsync(Guid id);
    ValueTask<T?> GetAsync(Guid? id);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<IList<T>> ListAsync();
    Task<IPagedList<T>> ListAsync(int pageSize, int pageNumber);
}