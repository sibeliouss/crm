using Application.Repositories;
using Domain.Entities;
using Domain.Pages;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ActivityRepository(BaseDbContext dbContext) : Repository<Activity>(dbContext), IActivityRepository
{
    public async Task<IList<Activity>> ListAsync(ActivityCriteria criteria)
    {
        return await BuildQuery(criteria).ToListAsync();
    }

    public async Task<IPagedList<Activity>> ListAsync(ActivityCriteria criteria, int pageSize, int pageNumber)
    {
        return await BuildQuery(criteria).ToListAsync(pageSize, pageNumber);
    }

    protected IQueryable<Activity> BuildQuery(ActivityCriteria criteria)
    {
        var query = DbContext.Set<Activity>().AsQueryable();

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

