using Application.Features.Dtos;
using Domain.Entities;
using Domain.Pages;

namespace Application.Repositories;

public interface IProductRepository : IRepository<Product>
{
    Task<IList<Product>> ListAsync(ProductDto criteria);
    Task<IPagedList<Product>> ListAsync(ProductDto criteria, int pageSize, int pageNumber);
}
