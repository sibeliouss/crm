using Domain.Entities;
using Domain.Pages;

namespace Application.Repositories;

public interface ILeadRepository : IRepository<Lead>
{
    Task<IList<Lead>> ListAsync(LeadCriteria criteria);
    Task<IPagedList<Lead>> ListAsync(LeadCriteria criteria, int pageSize, int pageNumber);
}

public class LeadCriteria
{
    public string? Email { get; set; }
}