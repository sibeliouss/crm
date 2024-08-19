using Application.Features.Dtos;
using Domain.Entities;
using Domain.Pages;

namespace Application.Repositories;

public interface IOpportunityRepository : IRepository<Opportunity>
{
    Task<IList<Opportunity>> ListAsync(OpportunityDto criteria);
    Task<IPagedList<Opportunity>> ListAsync(OpportunityDto criteria, int pageSize, int pageNumber);
}

