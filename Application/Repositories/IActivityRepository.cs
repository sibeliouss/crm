
using Application.Features.Dtos;
using Domain.Entities;
using Domain.Pages;

namespace Application.Repositories;

public interface IActivityRepository : IRepository<Activity>
{
    Task<IList<Activity>> ListAsync(ActivityDto criteria);
    Task<IPagedList<Activity>> ListAsync(ActivityDto criteria, int pageSize, int pageNumber);
}

