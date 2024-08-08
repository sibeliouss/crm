using Application.Features.Dtos;
using Application.Repositories;
using Domain.Entities;
using Domain.Pages;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ActivityRepository(BaseDbContext dbContext) : Repository<Activity>(dbContext), IActivityRepository
{
    public async Task<IList<Activity>> ListAsync(ActivityDto criteria)
    {
        return await BuildQuery(criteria).ToListAsync();
    }

    public async Task<IPagedList<Activity>> ListAsync(ActivityDto criteria, int pageSize, int pageNumber)
    {
        return await BuildQuery(criteria).ToListAsync(pageSize, pageNumber);
    }

    protected IQueryable<Activity> BuildQuery(ActivityDto criteria)
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

