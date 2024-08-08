using Application.Features.Dtos;
using Application.Repositories;
using Domain.Entities;
using Domain.Pages;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ContactRepository(BaseDbContext dbContext) : Repository<Contact>(dbContext), IContactRepository
{
    public async Task<IList<Contact>> ListAsync(ContactDto criteria)
    {
        return await BuildQuery(criteria).ToListAsync();
    }

    public async Task<IPagedList<Contact>> ListAsync(ContactDto criteria, int pageSize, int pageNumber)
    {
        return await BuildQuery(criteria).ToListAsync(pageSize, pageNumber);
    }

    protected IQueryable<Contact> BuildQuery(ContactDto criteria)
    {
        var query = DbContext.Set<Contact>().AsQueryable();

        if (criteria.CustomerId != null)
        {
            query = query.Where(e => e.Customer.Id == criteria.CustomerId);
        }

        if (criteria.Email != null)
        {
            query = query.Where(e => e.Email.Contains(criteria.Email));
        }

        query = query
            .Include(p => p.Customer)
            .OrderBy(p => p.FirstName);

        return query;
    }
}
