using Domain.Entities;
using Domain.Pages;

namespace Application.Repositories;

public interface IActivityRepository : IRepository<Activity>
{
    Task<IList<Activity>> ListAsync(ActivityCriteria criteria);
    Task<IPagedList<Activity>> ListAsync(ActivityCriteria criteria, int pageSize, int pageNumber);
}

public class ActivityCriteria
{
    public Guid? CustomerId { get; set; }
}