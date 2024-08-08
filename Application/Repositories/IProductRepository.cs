using Domain.Entities;
using Domain.Pages;

namespace Application.Repositories;

public interface IProductRepository : IRepository<Product>
{
    Task<IList<Product>> ListAsync(ProductCriteria criteria);
    Task<IPagedList<Product>> ListAsync(ProductCriteria criteria, int pageSize, int pageNumber);
}

public class ProductCriteria
{
    public string? Name { get; set; }
}