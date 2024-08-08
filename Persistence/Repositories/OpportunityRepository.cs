using Application.Repositories;
using Domain.Entities;
using Domain.Pages;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class OpportunityRepository : Repository<Opportunity>, IOpportunityRepository
{
    public OpportunityRepository(BaseDbContext dbContext) : base(dbContext) { }

    public async Task<IList<Opportunity>> ListAsync(OpportunityCriteria criteria)
    {
        return await BuildQuery(criteria).ToListAsync();
    }

    public async Task<IPagedList<Opportunity>> ListAsync(OpportunityCriteria criteria, int pageSize, int pageNumber)
    {
        return await BuildQuery(criteria).ToListAsync(pageSize, pageNumber);
    }

    protected IQueryable<Opportunity> BuildQuery(OpportunityCriteria criteria)
    {
        var query = DbContext.Set<Opportunity>().AsQueryable();

        if (criteria.CustomerId != null)
        {
            query = query.Where(e => e.Customer.Id == criteria.CustomerId);
        }

        query = query
            .Include(p => p.Customer)
            .OrderBy(p => p.CreateDate);

        return query;
    }
}