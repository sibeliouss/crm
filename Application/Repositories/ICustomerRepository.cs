using Domain.Entities;
using Domain.Pages;

namespace Application.Repositories;

public interface ICustomerRepository : IRepository<Customer>
{
    Task<IList<Customer>> ListAsync(CustomerCriteria criteria);
    Task<IPagedList<Customer>> ListAsync(CustomerCriteria criteria, int pageSize, int pageNumber);
}

public abstract class CustomerCriteria
{
    public string? Name { get; set; }
}