using Application.Repositories;
using Domain.Entities;
using Domain.Pages;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class LeadRepository : Repository<Lead>, ILeadRepository
{
    public LeadRepository(BaseDbContext dbContext) : base(dbContext) { }

    public async Task<IList<Lead>> ListAsync(LeadCriteria criteria)
    {
        return await BuildQuery(criteria).ToListAsync();
    }

    public async Task<IPagedList<Lead>> ListAsync(LeadCriteria criteria, int pageSize, int pageNumber)
    {
        return await BuildQuery(criteria).ToListAsync(pageSize, pageNumber);
    }

    protected IQueryable<Lead> BuildQuery(LeadCriteria criteria)
    {
        var query = DbContext.Set<Lead>().AsQueryable();

        if (criteria.Email != null)
        {
            query = query.Where(e => e.Email.Contains(criteria.Email));
        }

        query = query
            .OrderBy(p => p.FirstName);

        return query;
    }
}