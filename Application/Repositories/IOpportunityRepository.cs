using Domain.Entities;
using Domain.Pages;

namespace Application.Repositories;

public interface IOpportunityRepository : IRepository<Opportunity>
{
    Task<IList<Opportunity>> ListAsync(OpportunityCriteria criteria);
    Task<IPagedList<Opportunity>> ListAsync(OpportunityCriteria criteria, int pageSize, int pageNumber);
}

public class OpportunityCriteria
{
    public Guid? CustomerId { get; set; }
}