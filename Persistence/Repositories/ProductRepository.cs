using Application.Repositories;
using Domain.Entities;
using Domain.Pages;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ProductRepository(BaseDbContext dbContext) : Repository<Product>(dbContext), IProductRepository
{
    public async Task<IList<Product>> ListAsync(ProductCriteria criteria)
    {
        return await BuildQuery(criteria).ToListAsync();
    }

    public async Task<IPagedList<Product>> ListAsync(ProductCriteria criteria, int pageSize, int pageNumber)
    {
        return await BuildQuery(criteria).ToListAsync(pageSize, pageNumber);
    }

    protected IQueryable<Product> BuildQuery(ProductCriteria criteria)
    {
        var query = DbContext.Set<Product>().AsQueryable();

        if (criteria.Name != null)
        {
            query = query.Where(e => e.Name.Contains(criteria.Name));
        }

        query = query
            .OrderBy(p => p.Name);

        return query;
    }
}
