using Application.Features.Dtos;
using Application.Repositories;
using Domain.Entities;
using Domain.Pages;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CustomerRepository(BaseDbContext dbContext) : Repository<Customer>(dbContext), ICustomerRepository
{
    public async Task<IList<Customer>> ListAsync(CustomerDto criteria)
    {
        return await BuildQuery(criteria).ToListAsync();
    }

    public async Task<IPagedList<Customer>> ListAsync(CustomerDto criteria, int pageSize, int pageNumber)
    {
        return await BuildQuery(criteria).ToListAsync(pageSize, pageNumber);
    }

    protected IQueryable<Customer> BuildQuery(CustomerDto criteria)
    {
        var query = DbContext.Set<Customer>().AsQueryable();

        if (criteria.Name != null)
        {
            query = query.Where(e => e.Name.Contains(criteria.Name));
        }

        query = query
            // .Include(p => p.Contacts)
            .OrderBy(p => p.Name);

        return query;
    }
}